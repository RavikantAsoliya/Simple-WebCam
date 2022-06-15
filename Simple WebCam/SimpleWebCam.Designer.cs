namespace Simple_WebCam
{
    partial class SimpleWebCam
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimpleWebCam));
            this.displayPictureBox = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.devicesComboBox = new System.Windows.Forms.ComboBox();
            this.rightClickMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.devicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flipCameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showInTaskbarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.displayPictureBox)).BeginInit();
            this.panel2.SuspendLayout();
            this.rightClickMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // displayPictureBox
            // 
            this.displayPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.displayPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("displayPictureBox.Image")));
            this.displayPictureBox.Location = new System.Drawing.Point(0, 0);
            this.displayPictureBox.Name = "displayPictureBox";
            this.displayPictureBox.Size = new System.Drawing.Size(420, 236);
            this.displayPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.displayPictureBox.TabIndex = 2;
            this.displayPictureBox.TabStop = false;
            this.displayPictureBox.DoubleClick += new System.EventHandler(this.DisplayPictureBox_DoubleClick);
            this.displayPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelAsTitleBar_MouseDown);
            this.displayPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PanelAsTitleBar_MouseMove);
            this.displayPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PanelAsTitleBar_MouseUp);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.displayPictureBox);
            this.panel2.Controls.Add(this.devicesComboBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(420, 236);
            this.panel2.TabIndex = 7;
            // 
            // devicesComboBox
            // 
            this.devicesComboBox.Location = new System.Drawing.Point(37, 125);
            this.devicesComboBox.Name = "devicesComboBox";
            this.devicesComboBox.Size = new System.Drawing.Size(121, 21);
            this.devicesComboBox.TabIndex = 0;
            // 
            // rightClickMenu
            // 
            this.rightClickMenu.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rightClickMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.rightClickMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.devicesToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.pinToolStripMenuItem,
            this.fullScreenToolStripMenuItem,
            this.defaultToolStripMenuItem,
            this.flipCameraToolStripMenuItem,
            this.customSizeToolStripMenuItem,
            this.roundToolStripMenuItem,
            this.showInTaskbarToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.rightClickMenu.Name = "contextMenuStrip1";
            this.rightClickMenu.Size = new System.Drawing.Size(159, 224);
            // 
            // devicesToolStripMenuItem
            // 
            this.devicesToolStripMenuItem.Name = "devicesToolStripMenuItem";
            this.devicesToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.devicesToolStripMenuItem.Text = "Devices";
            this.devicesToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.DevicesToolStripMenuItem_DropDownItemClicked);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Enabled = false;
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.StopToolStripMenuItem_Click);
            // 
            // pinToolStripMenuItem
            // 
            this.pinToolStripMenuItem.Checked = true;
            this.pinToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.pinToolStripMenuItem.Name = "pinToolStripMenuItem";
            this.pinToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.pinToolStripMenuItem.Text = "Pin";
            this.pinToolStripMenuItem.Click += new System.EventHandler(this.PinToolStripMenuItem_Click);
            // 
            // fullScreenToolStripMenuItem
            // 
            this.fullScreenToolStripMenuItem.CheckOnClick = true;
            this.fullScreenToolStripMenuItem.Name = "fullScreenToolStripMenuItem";
            this.fullScreenToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.fullScreenToolStripMenuItem.Text = "Full Screen";
            this.fullScreenToolStripMenuItem.Click += new System.EventHandler(this.FullScreenToolStripMenuItem_Click);
            // 
            // defaultToolStripMenuItem
            // 
            this.defaultToolStripMenuItem.Name = "defaultToolStripMenuItem";
            this.defaultToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.defaultToolStripMenuItem.Text = "Default";
            this.defaultToolStripMenuItem.Visible = false;
            this.defaultToolStripMenuItem.Click += new System.EventHandler(this.DefaultToolStripMenuItem_Click);
            // 
            // flipCameraToolStripMenuItem
            // 
            this.flipCameraToolStripMenuItem.Name = "flipCameraToolStripMenuItem";
            this.flipCameraToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.flipCameraToolStripMenuItem.Text = "Flip Camera";
            this.flipCameraToolStripMenuItem.Click += new System.EventHandler(this.FlipCameraToolStripMenuItem_Click);
            // 
            // customSizeToolStripMenuItem
            // 
            this.customSizeToolStripMenuItem.Name = "customSizeToolStripMenuItem";
            this.customSizeToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.customSizeToolStripMenuItem.Text = "Custom Size";
            this.customSizeToolStripMenuItem.Visible = false;
            this.customSizeToolStripMenuItem.Click += new System.EventHandler(this.CustomSizeToolStripMenuItem_Click);
            // 
            // roundToolStripMenuItem
            // 
            this.roundToolStripMenuItem.CheckOnClick = true;
            this.roundToolStripMenuItem.Name = "roundToolStripMenuItem";
            this.roundToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.roundToolStripMenuItem.Text = "Round Window";
            this.roundToolStripMenuItem.Click += new System.EventHandler(this.RoundToolStripMenuItem_Click);
            // 
            // showInTaskbarToolStripMenuItem
            // 
            this.showInTaskbarToolStripMenuItem.CheckOnClick = true;
            this.showInTaskbarToolStripMenuItem.Name = "showInTaskbarToolStripMenuItem";
            this.showInTaskbarToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.showInTaskbarToolStripMenuItem.Text = "Show In Taskbar";
            this.showInTaskbarToolStripMenuItem.Click += new System.EventHandler(this.ShowInTaskbarToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // SimpleWebCam
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(420, 236);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(200, 113);
            this.Name = "SimpleWebCam";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simple WebCam";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.displayPictureBox)).EndInit();
            this.panel2.ResumeLayout(false);
            this.rightClickMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox displayPictureBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ContextMenuStrip rightClickMenu;
        private System.Windows.Forms.ToolStripMenuItem devicesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fullScreenToolStripMenuItem;
        private System.Windows.Forms.ComboBox devicesComboBox;
        private System.Windows.Forms.ToolStripMenuItem pinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flipCameraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem defaultToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roundToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showInTaskbarToolStripMenuItem;
    }
}

