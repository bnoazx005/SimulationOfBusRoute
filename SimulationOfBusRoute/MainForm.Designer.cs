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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMap = new GMap.NET.WindowsForms.GMapControl();
            this.zoomGroupBox = new System.Windows.Forms.GroupBox();
            this.zoomBar = new System.Windows.Forms.TrackBar();
            this.mapGroupBox = new System.Windows.Forms.GroupBox();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.propertiesGroupBox = new System.Windows.Forms.GroupBox();
            this.toolboxGroupBox = new System.Windows.Forms.GroupBox();
            this.openRouteButton = new System.Windows.Forms.Button();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.FileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QuitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenDocsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveRouteButton = new System.Windows.Forms.Button();
            this.addStationButton = new System.Windows.Forms.Button();
            this.removeStationButton = new System.Windows.Forms.Button();
            this.busEditorButton = new System.Windows.Forms.Button();
            this.startSimulationButton = new System.Windows.Forms.Button();
            this.pauseSimulationButton = new System.Windows.Forms.Button();
            this.stopSimulationButton = new System.Windows.Forms.Button();
            this.statisticsButton = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            this.loadRouteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveRouteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearRouteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simulationMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startSimulationMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopSimulationMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseSimulationMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetSimulationMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetSimulationButton = new System.Windows.Forms.Button();
            this.zoomGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoomBar)).BeginInit();
            this.mapGroupBox.SuspendLayout();
            this.toolboxGroupBox.SuspendLayout();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMap
            // 
            this.mainMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainMap.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mainMap.Bearing = 0F;
            this.mainMap.CanDragMap = true;
            this.mainMap.EmptyTileColor = System.Drawing.Color.Navy;
            this.mainMap.GrayScaleMode = false;
            this.mainMap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.mainMap.LevelsKeepInMemmory = 5;
            this.mainMap.Location = new System.Drawing.Point(6, 28);
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
            this.mainMap.Size = new System.Drawing.Size(639, 471);
            this.mainMap.TabIndex = 0;
            this.mainMap.Zoom = 0D;
            // 
            // zoomGroupBox
            // 
            this.zoomGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zoomGroupBox.AutoSize = true;
            this.zoomGroupBox.Controls.Add(this.zoomBar);
            this.zoomGroupBox.Location = new System.Drawing.Point(659, 111);
            this.zoomGroupBox.MinimumSize = new System.Drawing.Size(68, 505);
            this.zoomGroupBox.Name = "zoomGroupBox";
            this.zoomGroupBox.Size = new System.Drawing.Size(68, 505);
            this.zoomGroupBox.TabIndex = 8;
            this.zoomGroupBox.TabStop = false;
            this.zoomGroupBox.Text = "Zoom";
            // 
            // zoomBar
            // 
            this.zoomBar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zoomBar.LargeChange = 4;
            this.zoomBar.Location = new System.Drawing.Point(3, 28);
            this.zoomBar.Maximum = 4;
            this.zoomBar.Name = "zoomBar";
            this.zoomBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.zoomBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.zoomBar.Size = new System.Drawing.Size(56, 465);
            this.zoomBar.TabIndex = 0;
            this.zoomBar.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.zoomBar.Scroll += new System.EventHandler(this.zoomBar_Scroll);
            // 
            // mapGroupBox
            // 
            this.mapGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mapGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mapGroupBox.Controls.Add(this.mainMap);
            this.mapGroupBox.Location = new System.Drawing.Point(2, 111);
            this.mapGroupBox.MinimumSize = new System.Drawing.Size(651, 505);
            this.mapGroupBox.Name = "mapGroupBox";
            this.mapGroupBox.Size = new System.Drawing.Size(651, 505);
            this.mapGroupBox.TabIndex = 7;
            this.mapGroupBox.TabStop = false;
            this.mapGroupBox.Text = "Карта";
            // 
            // statusBar
            // 
            this.statusBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusBar.Location = new System.Drawing.Point(0, 619);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(966, 22);
            this.statusBar.TabIndex = 9;
            this.statusBar.Text = "hhyhyhy";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // propertiesGroupBox
            // 
            this.propertiesGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertiesGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.propertiesGroupBox.Location = new System.Drawing.Point(733, 111);
            this.propertiesGroupBox.MinimumSize = new System.Drawing.Size(230, 505);
            this.propertiesGroupBox.Name = "propertiesGroupBox";
            this.propertiesGroupBox.Size = new System.Drawing.Size(230, 505);
            this.propertiesGroupBox.TabIndex = 12;
            this.propertiesGroupBox.TabStop = false;
            this.propertiesGroupBox.Text = "Свойства";
            // 
            // toolboxGroupBox
            // 
            this.toolboxGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolboxGroupBox.Controls.Add(this.resetSimulationButton);
            this.toolboxGroupBox.Controls.Add(this.quitButton);
            this.toolboxGroupBox.Controls.Add(this.statisticsButton);
            this.toolboxGroupBox.Controls.Add(this.stopSimulationButton);
            this.toolboxGroupBox.Controls.Add(this.pauseSimulationButton);
            this.toolboxGroupBox.Controls.Add(this.startSimulationButton);
            this.toolboxGroupBox.Controls.Add(this.busEditorButton);
            this.toolboxGroupBox.Controls.Add(this.removeStationButton);
            this.toolboxGroupBox.Controls.Add(this.addStationButton);
            this.toolboxGroupBox.Controls.Add(this.saveRouteButton);
            this.toolboxGroupBox.Controls.Add(this.openRouteButton);
            this.toolboxGroupBox.Location = new System.Drawing.Point(2, 31);
            this.toolboxGroupBox.Name = "toolboxGroupBox";
            this.toolboxGroupBox.Size = new System.Drawing.Size(961, 74);
            this.toolboxGroupBox.TabIndex = 11;
            this.toolboxGroupBox.TabStop = false;
            this.toolboxGroupBox.Text = "Панель инструментов";
            // 
            // openRouteButton
            // 
            this.openRouteButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.openRouteButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.openRouteButton.Image = ((System.Drawing.Image)(resources.GetObject("openRouteButton.Image")));
            this.openRouteButton.Location = new System.Drawing.Point(10, 21);
            this.openRouteButton.Name = "openRouteButton";
            this.openRouteButton.Size = new System.Drawing.Size(39, 38);
            this.openRouteButton.TabIndex = 1;
            this.openRouteButton.UseVisualStyleBackColor = false;
            // 
            // menu
            // 
            this.menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenuItem,
            this.simulationMenuItem,
            this.HelpMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(966, 28);
            this.menu.TabIndex = 13;
            this.menu.Text = "menuStrip1";
            // 
            // FileMenuItem
            // 
            this.FileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadRouteMenuItem,
            this.saveRouteMenuItem,
            this.clearRouteMenuItem,
            this.QuitMenuItem});
            this.FileMenuItem.Name = "FileMenuItem";
            this.FileMenuItem.Size = new System.Drawing.Size(57, 24);
            this.FileMenuItem.Text = "Файл";
            // 
            // QuitMenuItem
            // 
            this.QuitMenuItem.Name = "QuitMenuItem";
            this.QuitMenuItem.Size = new System.Drawing.Size(286, 26);
            this.QuitMenuItem.Text = "Выход";
            this.QuitMenuItem.Click += new System.EventHandler(this.QuitMenuItem_Click);
            // 
            // HelpMenuItem
            // 
            this.HelpMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutMenuItem,
            this.OpenDocsMenuItem});
            this.HelpMenuItem.Name = "HelpMenuItem";
            this.HelpMenuItem.Size = new System.Drawing.Size(81, 24);
            this.HelpMenuItem.Text = "Помощь";
            // 
            // AboutMenuItem
            // 
            this.AboutMenuItem.Name = "AboutMenuItem";
            this.AboutMenuItem.Size = new System.Drawing.Size(185, 26);
            this.AboutMenuItem.Text = "О программе";
            // 
            // OpenDocsMenuItem
            // 
            this.OpenDocsMenuItem.Name = "OpenDocsMenuItem";
            this.OpenDocsMenuItem.Size = new System.Drawing.Size(185, 26);
            this.OpenDocsMenuItem.Text = "Документация";
            // 
            // saveRouteButton
            // 
            this.saveRouteButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.saveRouteButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.saveRouteButton.Image = ((System.Drawing.Image)(resources.GetObject("saveRouteButton.Image")));
            this.saveRouteButton.Location = new System.Drawing.Point(55, 21);
            this.saveRouteButton.Name = "saveRouteButton";
            this.saveRouteButton.Size = new System.Drawing.Size(39, 38);
            this.saveRouteButton.TabIndex = 2;
            this.saveRouteButton.UseVisualStyleBackColor = false;
            // 
            // addStationButton
            // 
            this.addStationButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.addStationButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.addStationButton.Image = ((System.Drawing.Image)(resources.GetObject("addStationButton.Image")));
            this.addStationButton.Location = new System.Drawing.Point(195, 21);
            this.addStationButton.Name = "addStationButton";
            this.addStationButton.Size = new System.Drawing.Size(39, 38);
            this.addStationButton.TabIndex = 3;
            this.addStationButton.UseVisualStyleBackColor = false;
            // 
            // removeStationButton
            // 
            this.removeStationButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.removeStationButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.removeStationButton.Image = ((System.Drawing.Image)(resources.GetObject("removeStationButton.Image")));
            this.removeStationButton.Location = new System.Drawing.Point(240, 21);
            this.removeStationButton.Name = "removeStationButton";
            this.removeStationButton.Size = new System.Drawing.Size(39, 38);
            this.removeStationButton.TabIndex = 4;
            this.removeStationButton.UseVisualStyleBackColor = false;
            // 
            // busEditorButton
            // 
            this.busEditorButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.busEditorButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.busEditorButton.Image = ((System.Drawing.Image)(resources.GetObject("busEditorButton.Image")));
            this.busEditorButton.Location = new System.Drawing.Point(285, 21);
            this.busEditorButton.Name = "busEditorButton";
            this.busEditorButton.Size = new System.Drawing.Size(39, 38);
            this.busEditorButton.TabIndex = 5;
            this.busEditorButton.UseVisualStyleBackColor = false;
            // 
            // startSimulationButton
            // 
            this.startSimulationButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.startSimulationButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.startSimulationButton.Image = ((System.Drawing.Image)(resources.GetObject("startSimulationButton.Image")));
            this.startSimulationButton.Location = new System.Drawing.Point(430, 21);
            this.startSimulationButton.Name = "startSimulationButton";
            this.startSimulationButton.Size = new System.Drawing.Size(39, 38);
            this.startSimulationButton.TabIndex = 6;
            this.startSimulationButton.UseVisualStyleBackColor = false;
            // 
            // pauseSimulationButton
            // 
            this.pauseSimulationButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pauseSimulationButton.Enabled = false;
            this.pauseSimulationButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pauseSimulationButton.Image = ((System.Drawing.Image)(resources.GetObject("pauseSimulationButton.Image")));
            this.pauseSimulationButton.Location = new System.Drawing.Point(475, 21);
            this.pauseSimulationButton.Name = "pauseSimulationButton";
            this.pauseSimulationButton.Size = new System.Drawing.Size(39, 38);
            this.pauseSimulationButton.TabIndex = 7;
            this.pauseSimulationButton.UseVisualStyleBackColor = false;
            // 
            // stopSimulationButton
            // 
            this.stopSimulationButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.stopSimulationButton.Enabled = false;
            this.stopSimulationButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.stopSimulationButton.Image = ((System.Drawing.Image)(resources.GetObject("stopSimulationButton.Image")));
            this.stopSimulationButton.Location = new System.Drawing.Point(520, 21);
            this.stopSimulationButton.Name = "stopSimulationButton";
            this.stopSimulationButton.Size = new System.Drawing.Size(39, 38);
            this.stopSimulationButton.TabIndex = 8;
            this.stopSimulationButton.UseVisualStyleBackColor = false;
            // 
            // statisticsButton
            // 
            this.statisticsButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.statisticsButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.statisticsButton.Image = ((System.Drawing.Image)(resources.GetObject("statisticsButton.Image")));
            this.statisticsButton.Location = new System.Drawing.Point(330, 21);
            this.statisticsButton.Name = "statisticsButton";
            this.statisticsButton.Size = new System.Drawing.Size(39, 38);
            this.statisticsButton.TabIndex = 9;
            this.statisticsButton.UseVisualStyleBackColor = false;
            // 
            // quitButton
            // 
            this.quitButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.quitButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.quitButton.Image = ((System.Drawing.Image)(resources.GetObject("quitButton.Image")));
            this.quitButton.Location = new System.Drawing.Point(100, 21);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(39, 38);
            this.quitButton.TabIndex = 10;
            this.quitButton.UseVisualStyleBackColor = false;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // loadRouteMenuItem
            // 
            this.loadRouteMenuItem.Name = "loadRouteMenuItem";
            this.loadRouteMenuItem.Size = new System.Drawing.Size(286, 26);
            this.loadRouteMenuItem.Text = "Загрузить маршрут";
            // 
            // saveRouteMenuItem
            // 
            this.saveRouteMenuItem.Name = "saveRouteMenuItem";
            this.saveRouteMenuItem.Size = new System.Drawing.Size(286, 26);
            this.saveRouteMenuItem.Text = "Сохранить маршрут";
            // 
            // clearRouteMenuItem
            // 
            this.clearRouteMenuItem.Name = "clearRouteMenuItem";
            this.clearRouteMenuItem.Size = new System.Drawing.Size(224, 26);
            this.clearRouteMenuItem.Text = "Удалить маршрут";
            // 
            // simulationMenuItem
            // 
            this.simulationMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startSimulationMenuItem,
            this.pauseSimulationMenuItem,
            this.stopSimulationMenuItem,
            this.resetSimulationMenuItem});
            this.simulationMenuItem.Name = "simulationMenuItem";
            this.simulationMenuItem.Size = new System.Drawing.Size(136, 24);
            this.simulationMenuItem.Text = "Моделирование";
            // 
            // startSimulationMenuItem
            // 
            this.startSimulationMenuItem.Name = "startSimulationMenuItem";
            this.startSimulationMenuItem.Size = new System.Drawing.Size(181, 26);
            this.startSimulationMenuItem.Text = "Начать";
            // 
            // stopSimulationMenuItem
            // 
            this.stopSimulationMenuItem.Name = "stopSimulationMenuItem";
            this.stopSimulationMenuItem.Size = new System.Drawing.Size(181, 26);
            this.stopSimulationMenuItem.Text = "Остановить";
            // 
            // pauseSimulationMenuItem
            // 
            this.pauseSimulationMenuItem.Name = "pauseSimulationMenuItem";
            this.pauseSimulationMenuItem.Size = new System.Drawing.Size(181, 26);
            this.pauseSimulationMenuItem.Text = "Пауза";
            // 
            // resetSimulationMenuItem
            // 
            this.resetSimulationMenuItem.Name = "resetSimulationMenuItem";
            this.resetSimulationMenuItem.Size = new System.Drawing.Size(181, 26);
            this.resetSimulationMenuItem.Text = "Сброс";
            // 
            // resetSimulationButton
            // 
            this.resetSimulationButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.resetSimulationButton.Enabled = false;
            this.resetSimulationButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.resetSimulationButton.Image = ((System.Drawing.Image)(resources.GetObject("resetSimulationButton.Image")));
            this.resetSimulationButton.Location = new System.Drawing.Point(565, 21);
            this.resetSimulationButton.Name = "resetSimulationButton";
            this.resetSimulationButton.Size = new System.Drawing.Size(39, 38);
            this.resetSimulationButton.TabIndex = 11;
            this.resetSimulationButton.UseVisualStyleBackColor = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(966, 641);
            this.Controls.Add(this.zoomGroupBox);
            this.Controls.Add(this.mapGroupBox);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.propertiesGroupBox);
            this.Controls.Add(this.toolboxGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu;
            this.MinimumSize = new System.Drawing.Size(984, 688);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.zoomGroupBox.ResumeLayout(false);
            this.zoomGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoomBar)).EndInit();
            this.mapGroupBox.ResumeLayout(false);
            this.toolboxGroupBox.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox propertiesGroupBox;
        private System.Windows.Forms.GroupBox toolboxGroupBox;
        private System.Windows.Forms.Button openRouteButton;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem FileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem QuitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HelpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenDocsMenuItem;
        private System.Windows.Forms.Button saveRouteButton;
        private System.Windows.Forms.Button removeStationButton;
        private System.Windows.Forms.Button addStationButton;
        private System.Windows.Forms.Button busEditorButton;
        private System.Windows.Forms.Button stopSimulationButton;
        private System.Windows.Forms.Button pauseSimulationButton;
        private System.Windows.Forms.Button startSimulationButton;
        private System.Windows.Forms.Button statisticsButton;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.ToolStripMenuItem loadRouteMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveRouteMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearRouteMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simulationMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startSimulationMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pauseSimulationMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopSimulationMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetSimulationMenuItem;
        private System.Windows.Forms.Button resetSimulationButton;
    }
}