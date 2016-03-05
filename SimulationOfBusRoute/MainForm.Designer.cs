namespace SimulationOfBusRoute
{
    partial class MainForm
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
            this.mainMap = new GMap.NET.WindowsForms.GMapControl();
            this.zoomGroupBox = new System.Windows.Forms.GroupBox();
            this.zoomBar = new System.Windows.Forms.TrackBar();
            this.mapGroupBox = new System.Windows.Forms.GroupBox();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.FileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QuitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propertiesGroupBox = new System.Windows.Forms.GroupBox();
            this.toolboxGroupBox = new System.Windows.Forms.GroupBox();
            this.zoomGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoomBar)).BeginInit();
            this.mapGroupBox.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMap
            // 
            this.mainMap.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.mainMap.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mainMap.Bearing = 0F;
            this.mainMap.CanDragMap = true;
            this.mainMap.EmptyTileColor = System.Drawing.Color.Navy;
            this.mainMap.GrayScaleMode = false;
            this.mainMap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.mainMap.LevelsKeepInMemmory = 5;
            this.mainMap.Location = new System.Drawing.Point(6, 21);
            this.mainMap.MarkersEnabled = true;
            this.mainMap.MaxZoom = 16;
            this.mainMap.MinZoom = 12;
            this.mainMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.mainMap.Name = "mainMap";
            this.mainMap.NegativeMode = false;
            this.mainMap.PolygonsEnabled = true;
            this.mainMap.RetryLoadTile = 0;
            this.mainMap.RoutesEnabled = true;
            this.mainMap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.mainMap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.mainMap.ShowTileGridLines = false;
            this.mainMap.Size = new System.Drawing.Size(647, 465);
            this.mainMap.TabIndex = 0;
            this.mainMap.Zoom = 0D;
            // 
            // zoomGroupBox
            // 
            this.zoomGroupBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.zoomGroupBox.Controls.Add(this.zoomBar);
            this.zoomGroupBox.Location = new System.Drawing.Point(664, 124);
            this.zoomGroupBox.Name = "zoomGroupBox";
            this.zoomGroupBox.Size = new System.Drawing.Size(68, 492);
            this.zoomGroupBox.TabIndex = 8;
            this.zoomGroupBox.TabStop = false;
            this.zoomGroupBox.Text = "Zoom";
            // 
            // zoomBar
            // 
            this.zoomBar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.zoomBar.LargeChange = 4;
            this.zoomBar.Location = new System.Drawing.Point(3, 21);
            this.zoomBar.Maximum = 4;
            this.zoomBar.Name = "zoomBar";
            this.zoomBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.zoomBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.zoomBar.Size = new System.Drawing.Size(56, 465);
            this.zoomBar.TabIndex = 0;
            this.zoomBar.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            // 
            // mapGroupBox
            // 
            this.mapGroupBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.mapGroupBox.Controls.Add(this.mainMap);
            this.mapGroupBox.Location = new System.Drawing.Point(2, 124);
            this.mapGroupBox.Name = "mapGroupBox";
            this.mapGroupBox.Size = new System.Drawing.Size(659, 492);
            this.mapGroupBox.TabIndex = 7;
            this.mapGroupBox.TabStop = false;
            this.mapGroupBox.Text = "Карта";
            // 
            // statusBar
            // 
            this.statusBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusBar.Location = new System.Drawing.Point(0, 619);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(927, 22);
            this.statusBar.TabIndex = 9;
            this.statusBar.Text = "hhyhyhy";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // menu
            // 
            this.menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenuItem,
            this.HelpMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(927, 28);
            this.menu.TabIndex = 10;
            this.menu.Text = "menuStrip1";
            // 
            // FileMenuItem
            // 
            this.FileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.QuitMenuItem});
            this.FileMenuItem.Name = "FileMenuItem";
            this.FileMenuItem.Size = new System.Drawing.Size(57, 24);
            this.FileMenuItem.Text = "Файл";
            // 
            // QuitMenuItem
            // 
            this.QuitMenuItem.Name = "QuitMenuItem";
            this.QuitMenuItem.Size = new System.Drawing.Size(128, 26);
            this.QuitMenuItem.Text = "Выход";
            // 
            // HelpMenuItem
            // 
            this.HelpMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutMenuItem});
            this.HelpMenuItem.Name = "HelpMenuItem";
            this.HelpMenuItem.Size = new System.Drawing.Size(81, 24);
            this.HelpMenuItem.Text = "Помощь";
            // 
            // AboutMenuItem
            // 
            this.AboutMenuItem.Name = "AboutMenuItem";
            this.AboutMenuItem.Size = new System.Drawing.Size(179, 26);
            this.AboutMenuItem.Text = "О программе";
            // 
            // propertiesGroupBox
            // 
            this.propertiesGroupBox.Location = new System.Drawing.Point(736, 124);
            this.propertiesGroupBox.Name = "propertiesGroupBox";
            this.propertiesGroupBox.Size = new System.Drawing.Size(188, 492);
            this.propertiesGroupBox.TabIndex = 12;
            this.propertiesGroupBox.TabStop = false;
            this.propertiesGroupBox.Text = "Свойства";
            // 
            // toolboxGroupBox
            // 
            this.toolboxGroupBox.Location = new System.Drawing.Point(2, 31);
            this.toolboxGroupBox.Name = "toolboxGroupBox";
            this.toolboxGroupBox.Size = new System.Drawing.Size(922, 87);
            this.toolboxGroupBox.TabIndex = 11;
            this.toolboxGroupBox.TabStop = false;
            this.toolboxGroupBox.Text = "Панель инструментов";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 641);
            this.Controls.Add(this.zoomGroupBox);
            this.Controls.Add(this.mapGroupBox);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.propertiesGroupBox);
            this.Controls.Add(this.toolboxGroupBox);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.zoomGroupBox.ResumeLayout(false);
            this.zoomGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoomBar)).EndInit();
            this.mapGroupBox.ResumeLayout(false);
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl mainMap;
        private System.Windows.Forms.GroupBox zoomGroupBox;
        private System.Windows.Forms.TrackBar zoomBar;
        private System.Windows.Forms.GroupBox mapGroupBox;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem FileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem QuitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HelpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutMenuItem;
        private System.Windows.Forms.GroupBox propertiesGroupBox;
        private System.Windows.Forms.GroupBox toolboxGroupBox;
    }
}