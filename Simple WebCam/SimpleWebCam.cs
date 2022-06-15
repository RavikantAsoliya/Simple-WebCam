using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using Simple_WebCam.Properties;
using System.Drawing.Drawing2D;

namespace Simple_WebCam
{
    public partial class SimpleWebCam : Form
    {
        #region SomeUseFullVariables
        private FilterInfoCollection devicesList; // To Get List of Availabel Camera Devices
        private VideoCaptureDevice currentDevice = null; // Get One Device from List of Available Devices
        private bool mouseDrag; // To check movement of App
        private Point offset; // Get Current Location of Window
        private bool isFlip; // To check video frame flipped or not
        private readonly ComponentResourceManager resources = new ComponentResourceManager(typeof(SimpleWebCam)); // to use resources

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        public static extern IntPtr CreateRoundRectRgn(int nLeftRect,
                                               int nRightRect,
                                               int nTopRect,
                                               int nBottomRect,
                                               int nWidthEllipse,
                                               int nHeightRectEllipse);
        #endregion

        public SimpleWebCam()
        {
            InitializeComponent();
            ContextMenuStrip = rightClickMenu;
            isFlip = true; //Default value is true, You will see your image on screen as Mirror.
            devicesComboBox.Visible = false;// Hide Combobox
            FindDevices(); // Find All Camera devices and add in Devices Section of ContextMenuStrip Dynamically
        }


        #region Save Default State And Location
        private void Form1_Load(object sender, EventArgs e) // It will capture the previous location of the app. and your app will start at that location.
        {
            WindowState = Settings.Default.F1State;
            if (WindowState == FormWindowState.Maximized)
            {
                fullScreenToolStripMenuItem.Checked = true;
            }

            Location = Settings.Default.F1Location;
        } 

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) // It will capture the current location of your app and will save it in the config file.
        {
            StopToolStripMenuItem_Click(sender, e);

            Settings.Default.F1State = WindowState;
            if (WindowState == FormWindowState.Normal)
            {
                Settings.Default.F1Location = Location;
            }
            else
            {
                Settings.Default.F1Location = RestoreBounds.Location;
            }

            Settings.Default.Save();
        }

        #endregion


        #region Function of ContextMenu ( Right Click Menu )

        /// <summary>
        /// This will find all camera devices that are connected to your computer via WiFi, cable, or that are integrated.
        /// </summary>
        private void FindDevices()
        {
            devicesComboBox.Items.Clear();

            devicesList = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (devicesList.Count > 0)
            {
                devicesToolStripMenuItem.DropDownItems.Clear();
                foreach (FilterInfo device in devicesList)
                {
                    devicesComboBox.Items.Add(device.Name);

                    devicesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
                        new ToolStripMenuItem
                        {
                            Name = device.Name + "ToolStripMenuItem",
                            Text = device.Name,
                            Size = new Size(270, 34),
                        }
                    });
                }
            }
        }

        /// <summary>
        /// It will show you all the available devices and then if you click on one of them, your camera will be triggered.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DevicesToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            void StartCamera()
            {
                if (currentDevice != null)
                {
                    currentDevice = new VideoCaptureDevice(devicesList[devicesComboBox.SelectedIndex].MonikerString);
                    currentDevice.NewFrame += CurrentDevice_NewFrame;
                    currentDevice.Start();
                }
            }
            string menuname = e.ClickedItem.Text;
            devicesComboBox.SelectedIndex = devicesComboBox.Items.IndexOf(menuname);
            currentDevice = new VideoCaptureDevice(devicesList[devicesComboBox.SelectedIndex].MonikerString);
            devicesToolStripMenuItem.Enabled = false;
            StartCamera(); // Start Camera Automatically
            stopToolStripMenuItem.Enabled = true;
        }

        private void CurrentDevice_NewFrame(object sender, NewFrameEventArgs eventArgs) // Get new Images
        {
            Bitmap frame = (Bitmap)eventArgs.Frame.Clone();
            if (isFlip)
            {
                frame.RotateFlip(RotateFlipType.RotateNoneFlipX);
            }
            displayPictureBox.Image = frame;

        }

        private void StopToolStripMenuItem_Click(object sender, EventArgs e) // Stop Camera
        {
            if (currentDevice != null)
            {
                currentDevice.Stop();
                currentDevice.NewFrame -= CurrentDevice_NewFrame;
            }
            displayPictureBox.Image = (Image)resources.GetObject("displayPictureBox.Image");
            devicesToolStripMenuItem.Enabled = true;
            stopToolStripMenuItem.Enabled = false;
            foreach (ToolStripMenuItem item in devicesToolStripMenuItem.DropDownItems)
            {
                //Console.WriteLine(item.Name);
                item.Checked = false;
            }
        }

        private void PinToolStripMenuItem_Click(object sender, EventArgs e) // For Make Top of the Most Window
        {
            if (pinToolStripMenuItem.Checked)
            {
                TopMost = false;
                pinToolStripMenuItem.Checked = false;
            }
            else
            {
                pinToolStripMenuItem.Checked = true;
                TopMost = true;
            }
        }

        private void FullScreenToolStripMenuItem_Click(object sender, EventArgs e) // For FullScreen
        {
            if (fullScreenToolStripMenuItem.Checked)
            {
                roundToolStripMenuItem.Checked = false;
                roundToolStripMenuItem.Enabled = false;
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                roundToolStripMenuItem.Checked = false;
                roundToolStripMenuItem.Enabled = true;
                WindowState = FormWindowState.Normal;
            }
        }

        private void DefaultToolStripMenuItem_Click(object sender, EventArgs e) // this function is not working.
        {
            Console.WriteLine("This Function is not Working.");
        }

        private void FlipCameraToolStripMenuItem_Click(object sender, EventArgs e) // To Mirror Camera Image
        {
            if (flipCameraToolStripMenuItem.Checked)
            {
                isFlip = true;
                flipCameraToolStripMenuItem.Checked = false;
            }
            else
            {
                isFlip = false;
                flipCameraToolStripMenuItem.Checked = true;
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e) // For Exit And Close App 
        {
            StopToolStripMenuItem_Click(sender, e);
            Close();
        }

        private void CustomSizeToolStripMenuItem_Click(object sender, EventArgs e) // This Function is not working.
        {
            Console.WriteLine("This Function is not Working.");
        }

        private void RoundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (roundToolStripMenuItem.Checked)
            {
                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(90, 0, displayPictureBox.Height, displayPictureBox.Height);
                ActiveForm.Region = new Region(path);
                displayPictureBox.SizeMode = PictureBoxSizeMode.StretchImage; //CenterImage
                fullScreenToolStripMenuItem.Checked = fullScreenToolStripMenuItem.Enabled = false;
            }
            else
            {
                ActiveForm.Size = new Size(420, 236);
                Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, SystemInformation.VirtualScreen.Width, SystemInformation.VirtualScreen.Height, 0, 0));
                fullScreenToolStripMenuItem.Checked = false;
                fullScreenToolStripMenuItem.Enabled = true;
            }
        }

        private void ShowInTaskbarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (showInTaskbarToolStripMenuItem.Checked == true)
                ShowInTaskbar = true;
            else
                ShowInTaskbar = false;
        }

        #endregion


        #region  Drag Application
        private void PanelAsTitleBar_MouseDown(object sender, MouseEventArgs e) // Get App Current Position
        {
            offset.X = e.X;
            offset.Y = e.Y;
            mouseDrag = true;
        }

        private void PanelAsTitleBar_MouseUp(object sender, MouseEventArgs e) // Change mouseDrag = false
        {
            mouseDrag = false;
        }

        private void PanelAsTitleBar_MouseMove(object sender, MouseEventArgs e) // To Move window in specific location
        {
            if (mouseDrag == true)
            {
                Point currentScreenPosition = PointToScreen(e.Location);
                Location = new Point(currentScreenPosition.X - offset.X, currentScreenPosition.Y - offset.Y);
            }
        }
        #endregion


        private void DisplayPictureBox_DoubleClick(object sender, EventArgs e)
        {
            if (roundToolStripMenuItem.Checked)
            {

            }
            else
            {
                if (fullScreenToolStripMenuItem.Checked)
                {
                    ActiveForm.WindowState = FormWindowState.Normal;
                    fullScreenToolStripMenuItem.Checked = false;
                    roundToolStripMenuItem.Checked = false;
                    roundToolStripMenuItem.Enabled = true;
                }
                else
                {
                    ActiveForm.WindowState = FormWindowState.Maximized;
                    fullScreenToolStripMenuItem.Checked = true;
                    roundToolStripMenuItem.Checked = false;
                    roundToolStripMenuItem.Enabled = false;
                }
            }
        }

    }
}
