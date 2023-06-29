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
        /// Updates the devices menu item with corresponding drop-down items.
        /// </summary>
        private void FindDevices()
        {
            // Clear the items in the devices combo box
            devicesComboBox.Items.Clear();

            // Get the collection of available video input devices
            devicesList = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            // Check if there are any devices found
            if (devicesList.Count > 0)
            {
                // Clear the drop-down items in the devices menu item
                devicesToolStripMenuItem.DropDownItems.Clear();

                // Iterate through each video input device
                foreach (FilterInfo device in devicesList)
                {
                    // Add the device name to the devices combo box
                    devicesComboBox.Items.Add(device.Name);

                    // Create a new drop-down item for the device
                    var menuItem = new ToolStripMenuItem
                    {
                        Name = device.Name + "ToolStripMenuItem",
                        Text = device.Name,
                        Size = new Size(270, 34)
                    };

                    // Add the drop-down item to the devices menu item
                    devicesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menuItem });
                }
            }
        }




        /// <summary>
        /// Sets the selected device based on the clicked item, starts capturing frames, and enables the stop menu item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DevicesToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // Get the name of the clicked device
            string deviceName = e.ClickedItem.Text;

            // Set the selected device in the devices combo box
            devicesComboBox.SelectedIndex = devicesComboBox.Items.IndexOf(deviceName);

            // Create a new VideoCaptureDevice with the selected device's MonikerString
            currentDevice = new VideoCaptureDevice(devicesList[devicesComboBox.SelectedIndex].MonikerString);

            // Disable the devices menu item
            devicesToolStripMenuItem.Enabled = false;

            // Subscribe to the NewFrame event of the current device and specify the event handler
            currentDevice.NewFrame += CurrentDevice_NewFrame;

            // Start capturing frames from the current device
            currentDevice.Start();

            // Enable the stop menu item
            stopToolStripMenuItem.Enabled = true;
        }



        /// <summary>
        /// Clones the captured frame, applies a flip transformation if enabled,
        /// and sets the resulting image as the display picture box's image.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void CurrentDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            // Clone the captured frame to ensure independent image processing
            Bitmap frame = (Bitmap)eventArgs.Frame.Clone();

            // Apply a flip transformation if the flip option is enabled
            if (isFlip)
            {
                frame.RotateFlip(RotateFlipType.RotateNoneFlipX);
            }

            // Set the resulting image as the display picture box's image
            displayPictureBox.Image = frame;
        }



        /// <summary>
        /// Stops the current device, removes the event handler for capturing new frames,
        /// resets the display picture box's image, enables the devices menu item,
        /// disables the stop menu item, and unchecks all devices in the drop-down menu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check if there is a current device
            if (currentDevice != null)
            {
                // Stop the current device
                currentDevice.Stop();

                // Remove the event handler for capturing new frames
                currentDevice.NewFrame -= CurrentDevice_NewFrame;
            }

            // Reset the display picture box's image
            displayPictureBox.Image = resources.GetObject("displayPictureBox.Image") as Image;

            // Enable the devices menu item
            devicesToolStripMenuItem.Enabled = true;

            // Disable the stop menu item
            stopToolStripMenuItem.Enabled = false;

            // Uncheck all devices in the drop-down menu
            foreach (ToolStripMenuItem item in devicesToolStripMenuItem.DropDownItems)
            {
                item.Checked = false;
            }
        }



        /// <summary>
        /// Toggles the TopMost property of the form based on the checked state of the pin menu item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Toggle the TopMost property of the form based on the checked state of the pin menu item
            TopMost = pinToolStripMenuItem.Checked = !pinToolStripMenuItem.Checked;
        }


        /// <summary>
        /// Sets the appropriate properties and state of the form based on the checked state of the full screen menu item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FullScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Set the checked state of the round menu item to false
            roundToolStripMenuItem.Checked = false;

            // Enable or disable the round menu item based on the checked state of the full screen menu item
            roundToolStripMenuItem.Enabled = !fullScreenToolStripMenuItem.Checked;

            // Set the WindowState of the form to Maximized if the full screen menu item is checked, otherwise set it to Normal
            WindowState = fullScreenToolStripMenuItem.Checked ? FormWindowState.Maximized : FormWindowState.Normal;
        }


        /// <summary>
        /// Toggles the flip state of the camera image.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FlipCameraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check if the flip camera menu item is checked
            if (flipCameraToolStripMenuItem.Checked)
            {
                // Set the flip state to true
                isFlip = true;

                // Uncheck the flip camera menu item
                flipCameraToolStripMenuItem.Checked = false;
            }
            else
            {
                // Set the flip state to false
                isFlip = false;

                // Check the flip camera menu item
                flipCameraToolStripMenuItem.Checked = true;
            }
        }



        /// <summary>
        /// Stops the camera and closes the application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StopToolStripMenuItem_Click(sender, e); // Stop the camera
            Close(); // Close the application
        }


        /// <summary>
        /// Toggles the round display mode of the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RoundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check if the round menu item is checked
            if (roundToolStripMenuItem.Checked)
            {
                // Create a graphics path for the circular region
                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(90, 0, displayPictureBox.Height, displayPictureBox.Height);

                // Set the form's region to the circular region
                ActiveForm.Region = new Region(path);

                // Set the picture box's size mode to stretch image
                displayPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

                // Disable the full screen menu item
                fullScreenToolStripMenuItem.Checked = fullScreenToolStripMenuItem.Enabled = false;
            }
            else
            {
                // Set the form's size to the default size
                ActiveForm.Size = new Size(420, 236);

                // Create a rounded rectangular region
                Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, SystemInformation.VirtualScreen.Width, SystemInformation.VirtualScreen.Height, 0, 0));

                // Uncheck the full screen menu item
                fullScreenToolStripMenuItem.Checked = false;

                // Enable the full screen menu item
                fullScreenToolStripMenuItem.Enabled = true;
            }
        }


        /// <summary>
        /// Enable and Disable "Show In Taskbar".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowInTaskbarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Set the value of the ShowInTaskbar property based on the checked state of the menu item.
            ShowInTaskbar = showInTaskbarToolStripMenuItem.Checked;
        }


        #endregion


        #region  Drag Application

        /// <summary>
        /// Gets the current position of the application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PanelAsTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            offset.X = e.X; // Store the X coordinate of the mouse cursor relative to the panel
            offset.Y = e.Y; // Store the Y coordinate of the mouse cursor relative to the panel
            mouseDrag = true; // Enable dragging of the window
        }

        /// <summary>
        /// Changes the mouseDrag flag to false.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PanelAsTitleBar_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDrag = false; // Disable dragging of the window
        }

        /// <summary>
        /// Moves the window to a specific location.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PanelAsTitleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDrag == true) // Check if dragging is enabled
            {
                Point currentScreenPosition = PointToScreen(e.Location); // Get the current position of the mouse cursor on the screen
                Location = new Point(currentScreenPosition.X - offset.X, currentScreenPosition.Y - offset.Y); // Set the new position of the window based on the mouse movement
            }
        }

        #endregion


        /// <summary>
        /// Handles the double-click event on the display picture box to toggle full-screen mode.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisplayPictureBox_DoubleClick(object sender, EventArgs e)
        {
            // Check if the roundToolStripMenuItem is not checked
            if (!roundToolStripMenuItem.Checked)
            {
                // Toggle the window state between Normal and Maximized based on the state of fullScreenToolStripMenuItem
                WindowState = fullScreenToolStripMenuItem.Checked ? FormWindowState.Normal : FormWindowState.Maximized;

                // Toggle the checked state of fullScreenToolStripMenuItem
                fullScreenToolStripMenuItem.Checked = !fullScreenToolStripMenuItem.Checked;

                // Enable or disable the roundToolStripMenuItem based on the checked state of fullScreenToolStripMenuItem
                roundToolStripMenuItem.Enabled = fullScreenToolStripMenuItem.Checked;
            }
        }




    }
}
