namespace SimulationOfBusRoute.Views
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.stationsListGroupBox = new System.Windows.Forms.GroupBox();
            this.routeNodesList = new System.Windows.Forms.ListBox();
            this.clearMapButtonAlt = new System.Windows.Forms.Button();
            this.abortChangesButton = new System.Windows.Forms.Button();
            this.submitChangesButton = new System.Windows.Forms.Button();
            this.typeOfNodeProperty = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nodeNameProperty = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.toolboxGroupBox = new System.Windows.Forms.GroupBox();
            this.simulationSettingsButton = new System.Windows.Forms.Button();
            this.moveNodeButton = new System.Windows.Forms.Button();
            this.selectNodeButton = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            this.dataEditorButton = new System.Windows.Forms.Button();
            this.statisticsButton = new System.Windows.Forms.Button();
            this.stopSimulationButton = new System.Windows.Forms.Button();
            this.startSimulationButton = new System.Windows.Forms.Button();
            this.busEditorButton = new System.Windows.Forms.Button();
            this.removeRouteNodeButton = new System.Windows.Forms.Button();
            this.addRouteNodeButton = new System.Windows.Forms.Button();
            this.saveDataButton = new System.Windows.Forms.Button();
            this.loadDataButton = new System.Windows.Forms.Button();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.FileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadDataMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveDataMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveDataAsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearRouteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simulationMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startSimulationMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseSimulationMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopSimulationMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetSimulationMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenDocsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.zoomGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoomBar)).BeginInit();
            this.mapGroupBox.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.propertiesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.stationsListGroupBox.SuspendLayout();
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
            this.mainMap.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
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
            this.mainMap.Size = new System.Drawing.Size(622, 518);
            this.mainMap.TabIndex = 0;
            this.mainMap.Zoom = 0D;
            // 
            // zoomGroupBox
            // 
            this.zoomGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zoomGroupBox.AutoSize = true;
            this.zoomGroupBox.Controls.Add(this.zoomBar);
            this.zoomGroupBox.Location = new System.Drawing.Point(642, 111);
            this.zoomGroupBox.MinimumSize = new System.Drawing.Size(68, 505);
            this.zoomGroupBox.Name = "zoomGroupBox";
            this.zoomGroupBox.Size = new System.Drawing.Size(68, 552);
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
            this.zoomBar.Size = new System.Drawing.Size(56, 512);
            this.zoomBar.TabIndex = 0;
            this.zoomBar.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            // 
            // mapGroupBox
            // 
            this.mapGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mapGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mapGroupBox.Controls.Add(this.mainMap);
            this.mapGroupBox.Location = new System.Drawing.Point(2, 111);
            this.mapGroupBox.Name = "mapGroupBox";
            this.mapGroupBox.Size = new System.Drawing.Size(634, 552);
            this.mapGroupBox.TabIndex = 7;
            this.mapGroupBox.TabStop = false;
            this.mapGroupBox.Text = "Карта";
            // 
            // statusBar
            // 
            this.statusBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusBar.Location = new System.Drawing.Point(0, 666);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(997, 22);
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
            this.propertiesGroupBox.Controls.Add(this.splitContainer1);
            this.propertiesGroupBox.Location = new System.Drawing.Point(716, 111);
            this.propertiesGroupBox.MinimumSize = new System.Drawing.Size(230, 505);
            this.propertiesGroupBox.Name = "propertiesGroupBox";
            this.propertiesGroupBox.Size = new System.Drawing.Size(278, 552);
            this.propertiesGroupBox.TabIndex = 12;
            this.propertiesGroupBox.TabStop = false;
            this.propertiesGroupBox.Text = "Свойства";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Location = new System.Drawing.Point(6, 21);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.stationsListGroupBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.abortChangesButton);
            this.splitContainer1.Panel2.Controls.Add(this.submitChangesButton);
            this.splitContainer1.Panel2.Controls.Add(this.typeOfNodeProperty);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.nodeNameProperty);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Enabled = false;
            this.splitContainer1.Panel2MinSize = 120;
            this.splitContainer1.Size = new System.Drawing.Size(263, 519);
            this.splitContainer1.SplitterDistance = 392;
            this.splitContainer1.TabIndex = 0;
            // 
            // stationsListGroupBox
            // 
            this.stationsListGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.stationsListGroupBox.Controls.Add(this.routeNodesList);
            this.stationsListGroupBox.Controls.Add(this.clearMapButtonAlt);
            this.stationsListGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stationsListGroupBox.Location = new System.Drawing.Point(0, 0);
            this.stationsListGroupBox.Name = "stationsListGroupBox";
            this.stationsListGroupBox.Size = new System.Drawing.Size(261, 390);
            this.stationsListGroupBox.TabIndex = 0;
            this.stationsListGroupBox.TabStop = false;
            this.stationsListGroupBox.Text = "Список узлов:";
            // 
            // routeNodesList
            // 
            this.routeNodesList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.routeNodesList.FormattingEnabled = true;
            this.routeNodesList.ItemHeight = 16;
            this.routeNodesList.Location = new System.Drawing.Point(3, 18);
            this.routeNodesList.Name = "routeNodesList";
            this.routeNodesList.Size = new System.Drawing.Size(255, 342);
            this.routeNodesList.TabIndex = 4;
            // 
            // clearMapButtonAlt
            // 
            this.clearMapButtonAlt.AutoSize = true;
            this.clearMapButtonAlt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.clearMapButtonAlt.Location = new System.Drawing.Point(3, 360);
            this.clearMapButtonAlt.Name = "clearMapButtonAlt";
            this.clearMapButtonAlt.Size = new System.Drawing.Size(255, 27);
            this.clearMapButtonAlt.TabIndex = 3;
            this.clearMapButtonAlt.Text = "Удалить все узлы маршрута";
            this.clearMapButtonAlt.UseVisualStyleBackColor = true;
            // 
            // abortChangesButton
            // 
            this.abortChangesButton.Location = new System.Drawing.Point(133, 75);
            this.abortChangesButton.Name = "abortChangesButton";
            this.abortChangesButton.Size = new System.Drawing.Size(125, 27);
            this.abortChangesButton.TabIndex = 15;
            this.abortChangesButton.Text = "Отмена";
            this.abortChangesButton.UseVisualStyleBackColor = true;
            // 
            // submitChangesButton
            // 
            this.submitChangesButton.Location = new System.Drawing.Point(3, 75);
            this.submitChangesButton.Name = "submitChangesButton";
            this.submitChangesButton.Size = new System.Drawing.Size(124, 27);
            this.submitChangesButton.TabIndex = 14;
            this.submitChangesButton.Text = "Потвердить";
            this.submitChangesButton.UseVisualStyleBackColor = true;
            // 
            // typeOfNodeProperty
            // 
            this.typeOfNodeProperty.FormattingEnabled = true;
            this.typeOfNodeProperty.Items.AddRange(new object[] {
            "Остановка",
            "Перекресток"});
            this.typeOfNodeProperty.Location = new System.Drawing.Point(83, 36);
            this.typeOfNodeProperty.Name = "typeOfNodeProperty";
            this.typeOfNodeProperty.Size = new System.Drawing.Size(175, 24);
            this.typeOfNodeProperty.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Тип узла:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nodeNameProperty
            // 
            this.nodeNameProperty.Location = new System.Drawing.Point(83, 8);
            this.nodeNameProperty.Name = "nodeNameProperty";
            this.nodeNameProperty.Size = new System.Drawing.Size(175, 22);
            this.nodeNameProperty.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Название:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolboxGroupBox
            // 
            this.toolboxGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolboxGroupBox.Controls.Add(this.simulationSettingsButton);
            this.toolboxGroupBox.Controls.Add(this.moveNodeButton);
            this.toolboxGroupBox.Controls.Add(this.selectNodeButton);
            this.toolboxGroupBox.Controls.Add(this.quitButton);
            this.toolboxGroupBox.Controls.Add(this.dataEditorButton);
            this.toolboxGroupBox.Controls.Add(this.statisticsButton);
            this.toolboxGroupBox.Controls.Add(this.stopSimulationButton);
            this.toolboxGroupBox.Controls.Add(this.startSimulationButton);
            this.toolboxGroupBox.Controls.Add(this.busEditorButton);
            this.toolboxGroupBox.Controls.Add(this.removeRouteNodeButton);
            this.toolboxGroupBox.Controls.Add(this.addRouteNodeButton);
            this.toolboxGroupBox.Controls.Add(this.saveDataButton);
            this.toolboxGroupBox.Controls.Add(this.loadDataButton);
            this.toolboxGroupBox.Location = new System.Drawing.Point(2, 31);
            this.toolboxGroupBox.Name = "toolboxGroupBox";
            this.toolboxGroupBox.Size = new System.Drawing.Size(992, 74);
            this.toolboxGroupBox.TabIndex = 11;
            this.toolboxGroupBox.TabStop = false;
            this.toolboxGroupBox.Text = "Панель инструментов";
            // 
            // simulationSettingsButton
            // 
            this.simulationSettingsButton.BackColor = System.Drawing.SystemColors.Control;
            this.simulationSettingsButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.simulationSettingsButton.Image = global::SimulationOfBusRoute.Properties.Resources.mSettingsButtonImage;
            this.simulationSettingsButton.Location = new System.Drawing.Point(700, 21);
            this.simulationSettingsButton.Name = "simulationSettingsButton";
            this.simulationSettingsButton.Size = new System.Drawing.Size(39, 38);
            this.simulationSettingsButton.TabIndex = 16;
            this.simulationSettingsButton.UseVisualStyleBackColor = false;
            // 
            // moveNodeButton
            // 
            this.moveNodeButton.BackColor = System.Drawing.SystemColors.Control;
            this.moveNodeButton.BackgroundImage = global::SimulationOfBusRoute.Properties.Resources.mMoveNodeButtonImage;
            this.moveNodeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.moveNodeButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.moveNodeButton.Location = new System.Drawing.Point(330, 21);
            this.moveNodeButton.Name = "moveNodeButton";
            this.moveNodeButton.Size = new System.Drawing.Size(39, 38);
            this.moveNodeButton.TabIndex = 15;
            this.moveNodeButton.UseVisualStyleBackColor = false;
            // 
            // selectNodeButton
            // 
            this.selectNodeButton.BackColor = System.Drawing.SystemColors.Control;
            this.selectNodeButton.BackgroundImage = global::SimulationOfBusRoute.Properties.Resources.mSelectNodeButtonActiveImage;
            this.selectNodeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.selectNodeButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.selectNodeButton.Location = new System.Drawing.Point(195, 21);
            this.selectNodeButton.Name = "selectNodeButton";
            this.selectNodeButton.Size = new System.Drawing.Size(39, 38);
            this.selectNodeButton.TabIndex = 14;
            this.selectNodeButton.UseVisualStyleBackColor = false;
            // 
            // quitButton
            // 
            this.quitButton.BackColor = System.Drawing.SystemColors.Control;
            this.quitButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.quitButton.Image = global::SimulationOfBusRoute.Properties.Resources.mQuitButtonImage;
            this.quitButton.Location = new System.Drawing.Point(100, 21);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(39, 38);
            this.quitButton.TabIndex = 13;
            this.quitButton.UseVisualStyleBackColor = false;
            // 
            // dataEditorButton
            // 
            this.dataEditorButton.BackColor = System.Drawing.SystemColors.Control;
            this.dataEditorButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataEditorButton.Image = global::SimulationOfBusRoute.Properties.Resources.mDataEditorButtonImage;
            this.dataEditorButton.Location = new System.Drawing.Point(470, 21);
            this.dataEditorButton.Name = "dataEditorButton";
            this.dataEditorButton.Size = new System.Drawing.Size(39, 38);
            this.dataEditorButton.TabIndex = 12;
            this.dataEditorButton.UseVisualStyleBackColor = false;
            // 
            // statisticsButton
            // 
            this.statisticsButton.BackColor = System.Drawing.SystemColors.Control;
            this.statisticsButton.Enabled = false;
            this.statisticsButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.statisticsButton.Image = global::SimulationOfBusRoute.Properties.Resources.mStatisticsViewerButtonImage;
            this.statisticsButton.Location = new System.Drawing.Point(515, 21);
            this.statisticsButton.Name = "statisticsButton";
            this.statisticsButton.Size = new System.Drawing.Size(39, 38);
            this.statisticsButton.TabIndex = 9;
            this.statisticsButton.UseVisualStyleBackColor = false;
            // 
            // stopSimulationButton
            // 
            this.stopSimulationButton.BackColor = System.Drawing.SystemColors.Control;
            this.stopSimulationButton.Enabled = false;
            this.stopSimulationButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.stopSimulationButton.Image = global::SimulationOfBusRoute.Properties.Resources.mStopSimulationButtonImage;
            this.stopSimulationButton.Location = new System.Drawing.Point(655, 21);
            this.stopSimulationButton.Name = "stopSimulationButton";
            this.stopSimulationButton.Size = new System.Drawing.Size(39, 38);
            this.stopSimulationButton.TabIndex = 8;
            this.stopSimulationButton.UseVisualStyleBackColor = false;
            // 
            // startSimulationButton
            // 
            this.startSimulationButton.BackColor = System.Drawing.SystemColors.Control;
            this.startSimulationButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.startSimulationButton.Image = global::SimulationOfBusRoute.Properties.Resources.mStartSimulationButtonImage;
            this.startSimulationButton.Location = new System.Drawing.Point(610, 21);
            this.startSimulationButton.Name = "startSimulationButton";
            this.startSimulationButton.Size = new System.Drawing.Size(39, 38);
            this.startSimulationButton.TabIndex = 6;
            this.startSimulationButton.UseVisualStyleBackColor = false;
            // 
            // busEditorButton
            // 
            this.busEditorButton.BackColor = System.Drawing.SystemColors.Control;
            this.busEditorButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.busEditorButton.Image = global::SimulationOfBusRoute.Properties.Resources.mBusEditorButtonImage;
            this.busEditorButton.Location = new System.Drawing.Point(425, 21);
            this.busEditorButton.Name = "busEditorButton";
            this.busEditorButton.Size = new System.Drawing.Size(39, 38);
            this.busEditorButton.TabIndex = 5;
            this.busEditorButton.UseVisualStyleBackColor = false;
            // 
            // removeRouteNodeButton
            // 
            this.removeRouteNodeButton.BackColor = System.Drawing.SystemColors.Control;
            this.removeRouteNodeButton.BackgroundImage = global::SimulationOfBusRoute.Properties.Resources.mRemoveNodeButtonImage;
            this.removeRouteNodeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.removeRouteNodeButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.removeRouteNodeButton.Location = new System.Drawing.Point(285, 21);
            this.removeRouteNodeButton.Name = "removeRouteNodeButton";
            this.removeRouteNodeButton.Size = new System.Drawing.Size(39, 38);
            this.removeRouteNodeButton.TabIndex = 4;
            this.removeRouteNodeButton.UseVisualStyleBackColor = false;
            // 
            // addRouteNodeButton
            // 
            this.addRouteNodeButton.BackColor = System.Drawing.SystemColors.Control;
            this.addRouteNodeButton.BackgroundImage = global::SimulationOfBusRoute.Properties.Resources.mAddNodeButtonImage;
            this.addRouteNodeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.addRouteNodeButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.addRouteNodeButton.ImageKey = "(none)";
            this.addRouteNodeButton.Location = new System.Drawing.Point(240, 21);
            this.addRouteNodeButton.Name = "addRouteNodeButton";
            this.addRouteNodeButton.Size = new System.Drawing.Size(39, 38);
            this.addRouteNodeButton.TabIndex = 3;
            this.addRouteNodeButton.UseVisualStyleBackColor = false;
            // 
            // saveDataButton
            // 
            this.saveDataButton.BackColor = System.Drawing.SystemColors.Control;
            this.saveDataButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.saveDataButton.Image = global::SimulationOfBusRoute.Properties.Resources.mSaveRouteButtonImage;
            this.saveDataButton.Location = new System.Drawing.Point(55, 21);
            this.saveDataButton.Name = "saveDataButton";
            this.saveDataButton.Size = new System.Drawing.Size(39, 38);
            this.saveDataButton.TabIndex = 2;
            this.saveDataButton.UseVisualStyleBackColor = false;
            // 
            // loadDataButton
            // 
            this.loadDataButton.BackColor = System.Drawing.SystemColors.Control;
            this.loadDataButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.loadDataButton.Image = global::SimulationOfBusRoute.Properties.Resources.mLoadRouteButtonImage;
            this.loadDataButton.Location = new System.Drawing.Point(10, 21);
            this.loadDataButton.Name = "loadDataButton";
            this.loadDataButton.Size = new System.Drawing.Size(39, 38);
            this.loadDataButton.TabIndex = 1;
            this.loadDataButton.UseVisualStyleBackColor = false;
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
            this.menu.Size = new System.Drawing.Size(997, 28);
            this.menu.TabIndex = 13;
            this.menu.Text = "menuStrip1";
            // 
            // FileMenuItem
            // 
            this.FileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadDataMenuItem,
            this.saveDataMenuItem,
            this.saveDataAsMenuItem,
            this.clearRouteMenuItem,
            this.quitMenuItem});
            this.FileMenuItem.Name = "FileMenuItem";
            this.FileMenuItem.Size = new System.Drawing.Size(57, 24);
            this.FileMenuItem.Text = "Файл";
            // 
            // loadDataMenuItem
            // 
            this.loadDataMenuItem.Name = "loadDataMenuItem";
            this.loadDataMenuItem.Size = new System.Drawing.Size(250, 26);
            this.loadDataMenuItem.Text = "Загрузить данные";
            // 
            // saveDataMenuItem
            // 
            this.saveDataMenuItem.Enabled = false;
            this.saveDataMenuItem.Name = "saveDataMenuItem";
            this.saveDataMenuItem.Size = new System.Drawing.Size(250, 26);
            this.saveDataMenuItem.Text = "Сохранить данные";
            this.saveDataMenuItem.Visible = false;
            // 
            // saveDataAsMenuItem
            // 
            this.saveDataAsMenuItem.Name = "saveDataAsMenuItem";
            this.saveDataAsMenuItem.Size = new System.Drawing.Size(250, 26);
            this.saveDataAsMenuItem.Text = "Сохранить данные как...";
            // 
            // clearRouteMenuItem
            // 
            this.clearRouteMenuItem.Name = "clearRouteMenuItem";
            this.clearRouteMenuItem.Size = new System.Drawing.Size(250, 26);
            this.clearRouteMenuItem.Text = "Удалить маршрут";
            // 
            // quitMenuItem
            // 
            this.quitMenuItem.Name = "quitMenuItem";
            this.quitMenuItem.Size = new System.Drawing.Size(250, 26);
            this.quitMenuItem.Text = "Выход";
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
            this.startSimulationMenuItem.Size = new System.Drawing.Size(165, 26);
            this.startSimulationMenuItem.Text = "Начать";
            // 
            // pauseSimulationMenuItem
            // 
            this.pauseSimulationMenuItem.Name = "pauseSimulationMenuItem";
            this.pauseSimulationMenuItem.Size = new System.Drawing.Size(165, 26);
            this.pauseSimulationMenuItem.Text = "Пауза";
            // 
            // stopSimulationMenuItem
            // 
            this.stopSimulationMenuItem.Name = "stopSimulationMenuItem";
            this.stopSimulationMenuItem.Size = new System.Drawing.Size(165, 26);
            this.stopSimulationMenuItem.Text = "Остановить";
            // 
            // resetSimulationMenuItem
            // 
            this.resetSimulationMenuItem.Name = "resetSimulationMenuItem";
            this.resetSimulationMenuItem.Size = new System.Drawing.Size(165, 26);
            this.resetSimulationMenuItem.Text = "Сброс";
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
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "data";
            this.openFileDialog.FileName = "openFileDialog1";
            this.openFileDialog.Filter = "Model data (*.data)|*.data|All Files (*.*)|*.*";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "data";
            this.saveFileDialog.Filter = "Model data (*.data)|*.data|All Files (*.*)|*.*";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(997, 688);
            this.Controls.Add(this.zoomGroupBox);
            this.Controls.Add(this.mapGroupBox);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.propertiesGroupBox);
            this.Controls.Add(this.toolboxGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menu;
            this.MinimumSize = new System.Drawing.Size(984, 688);
            this.Name = "MainForm";
            this.Text = "Моделирование пассажирских перевозок [Редактор маршрута]";
            this.zoomGroupBox.ResumeLayout(false);
            this.zoomGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoomBar)).EndInit();
            this.mapGroupBox.ResumeLayout(false);
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.propertiesGroupBox.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.stationsListGroupBox.ResumeLayout(false);
            this.stationsListGroupBox.PerformLayout();
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
        private System.Windows.Forms.GroupBox propertiesGroupBox;
        private System.Windows.Forms.GroupBox toolboxGroupBox;
        private System.Windows.Forms.Button loadDataButton;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem FileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HelpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenDocsMenuItem;
        private System.Windows.Forms.Button saveDataButton;
        private System.Windows.Forms.Button removeRouteNodeButton;
        private System.Windows.Forms.Button addRouteNodeButton;
        private System.Windows.Forms.Button busEditorButton;
        private System.Windows.Forms.Button stopSimulationButton;
        private System.Windows.Forms.Button startSimulationButton;
        private System.Windows.Forms.Button statisticsButton;
        private System.Windows.Forms.ToolStripMenuItem clearRouteMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simulationMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startSimulationMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pauseSimulationMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopSimulationMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetSimulationMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.GroupBox stationsListGroupBox;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button clearMapButtonAlt;
        private System.Windows.Forms.ListBox routeNodesList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nodeNameProperty;
        private System.Windows.Forms.ToolStripMenuItem loadDataMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveDataMenuItem;
        private System.Windows.Forms.ComboBox typeOfNodeProperty;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button abortChangesButton;
        private System.Windows.Forms.Button submitChangesButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem saveDataAsMenuItem;
        private System.Windows.Forms.Button dataEditorButton;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Button moveNodeButton;
        private System.Windows.Forms.Button selectNodeButton;
        private System.Windows.Forms.Button simulationSettingsButton;
    }
}