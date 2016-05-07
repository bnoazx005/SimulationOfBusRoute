namespace SimulationOfBusRoute.Views
{
    partial class BusEditor
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
            this.menu = new System.Windows.Forms.MenuStrip();
            this.fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearBusesListMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openDocsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolBoxGroup = new System.Windows.Forms.GroupBox();
            this.addBusButton = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.busLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.menu.SuspendLayout();
            this.toolBoxGroup.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem,
            this.helpMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(678, 28);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip";
            // 
            // fileMenuItem
            // 
            this.fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearBusesListMenuItem,
            this.quitMenuItem});
            this.fileMenuItem.Name = "fileMenuItem";
            this.fileMenuItem.Size = new System.Drawing.Size(57, 24);
            this.fileMenuItem.Text = "Файл";
            // 
            // clearBusesListMenuItem
            // 
            this.clearBusesListMenuItem.Name = "clearBusesListMenuItem";
            this.clearBusesListMenuItem.Size = new System.Drawing.Size(200, 26);
            this.clearBusesListMenuItem.Text = "Очистить список";
            // 
            // quitMenuItem
            // 
            this.quitMenuItem.Name = "quitMenuItem";
            this.quitMenuItem.Size = new System.Drawing.Size(200, 26);
            this.quitMenuItem.Text = "Закрыть окно";
            // 
            // helpMenuItem
            // 
            this.helpMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openDocsMenuItem});
            this.helpMenuItem.Name = "helpMenuItem";
            this.helpMenuItem.Size = new System.Drawing.Size(81, 24);
            this.helpMenuItem.Text = "Помощь";
            // 
            // openDocsMenuItem
            // 
            this.openDocsMenuItem.Name = "openDocsMenuItem";
            this.openDocsMenuItem.Size = new System.Drawing.Size(185, 26);
            this.openDocsMenuItem.Text = "Документация";
            // 
            // toolBoxGroup
            // 
            this.toolBoxGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolBoxGroup.Controls.Add(this.addBusButton);
            this.toolBoxGroup.Controls.Add(this.quitButton);
            this.toolBoxGroup.Location = new System.Drawing.Point(2, 31);
            this.toolBoxGroup.Name = "toolBoxGroup";
            this.toolBoxGroup.Size = new System.Drawing.Size(673, 76);
            this.toolBoxGroup.TabIndex = 1;
            this.toolBoxGroup.TabStop = false;
            this.toolBoxGroup.Text = "Панель инструментов";
            // 
            // addBusButton
            // 
            this.addBusButton.BackColor = System.Drawing.SystemColors.Control;
            this.addBusButton.BackgroundImage = global::SimulationOfBusRoute.Properties.Resources.mAddBusButtonImage;
            this.addBusButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.addBusButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.addBusButton.Location = new System.Drawing.Point(100, 21);
            this.addBusButton.Name = "addBusButton";
            this.addBusButton.Size = new System.Drawing.Size(39, 38);
            this.addBusButton.TabIndex = 12;
            this.addBusButton.UseVisualStyleBackColor = false;
            // 
            // quitButton
            // 
            this.quitButton.BackColor = System.Drawing.SystemColors.Control;
            this.quitButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.quitButton.Image = global::SimulationOfBusRoute.Properties.Resources.mQuitButtonImage;
            this.quitButton.Location = new System.Drawing.Point(10, 21);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(39, 38);
            this.quitButton.TabIndex = 11;
            this.quitButton.UseVisualStyleBackColor = false;
            // 
            // statusBar
            // 
            this.statusBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusBar.Location = new System.Drawing.Point(0, 634);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(678, 22);
            this.statusBar.TabIndex = 3;
            this.statusBar.Text = "statusStrip1";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.busLayoutPanel);
            this.groupBox1.Location = new System.Drawing.Point(2, 113);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(673, 489);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Список транспорта:";
            // 
            // busLayoutPanel
            // 
            this.busLayoutPanel.AutoScroll = true;
            this.busLayoutPanel.ColumnCount = 1;
            this.busLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.busLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.busLayoutPanel.Location = new System.Drawing.Point(3, 18);
            this.busLayoutPanel.Name = "busLayoutPanel";
            this.busLayoutPanel.RowCount = 1;
            this.busLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.busLayoutPanel.Size = new System.Drawing.Size(667, 468);
            this.busLayoutPanel.TabIndex = 0;
            // 
            // BusEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 656);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.toolBoxGroup);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.MaximumSize = new System.Drawing.Size(696, 1703);
            this.MinimumSize = new System.Drawing.Size(696, 703);
            this.Name = "BusEditor";
            this.Text = "Моделирование пассажирских перевозок [Редактор транспорта]";
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.toolBoxGroup.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem fileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openDocsMenuItem;
        private System.Windows.Forms.GroupBox toolBoxGroup;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel busLayoutPanel;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Button addBusButton;
        private System.Windows.Forms.ToolStripMenuItem clearBusesListMenuItem;
    }
}