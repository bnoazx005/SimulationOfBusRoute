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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearBusesListMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openDocsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolBoxGroup = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.addBusButton = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.busLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.busVelocitiesBox = new System.Windows.Forms.GroupBox();
            this.busesVelocitiesTable = new System.Windows.Forms.DataGridView();
            this.menu.SuspendLayout();
            this.toolBoxGroup.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.busVelocitiesBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.busesVelocitiesTable)).BeginInit();
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
            this.menu.Size = new System.Drawing.Size(1053, 28);
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
            this.toolBoxGroup.Controls.Add(this.button2);
            this.toolBoxGroup.Controls.Add(this.addBusButton);
            this.toolBoxGroup.Controls.Add(this.quitButton);
            this.toolBoxGroup.Location = new System.Drawing.Point(2, 31);
            this.toolBoxGroup.Name = "toolBoxGroup";
            this.toolBoxGroup.Size = new System.Drawing.Size(1048, 76);
            this.toolBoxGroup.TabIndex = 1;
            this.toolBoxGroup.TabStop = false;
            this.toolBoxGroup.Text = "Панель инструментов";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button2.Location = new System.Drawing.Point(55, 21);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(39, 38);
            this.button2.TabIndex = 13;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // addBusButton
            // 
            this.addBusButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.addBusButton.BackgroundImage = global::SimulationOfBusRoute.Properties.Resources.mAddBusButton;
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
            this.quitButton.Image = global::SimulationOfBusRoute.Properties.Resources.mQuitButton;
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
            this.statusBar.Size = new System.Drawing.Size(1053, 22);
            this.statusBar.TabIndex = 3;
            this.statusBar.Text = "statusStrip1";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.busLayoutPanel);
            this.groupBox1.Location = new System.Drawing.Point(2, 113);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(665, 489);
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
            this.busLayoutPanel.Size = new System.Drawing.Size(659, 468);
            this.busLayoutPanel.TabIndex = 0;
            // 
            // busVelocitiesBox
            // 
            this.busVelocitiesBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.busVelocitiesBox.Controls.Add(this.busesVelocitiesTable);
            this.busVelocitiesBox.Location = new System.Drawing.Point(673, 113);
            this.busVelocitiesBox.Name = "busVelocitiesBox";
            this.busVelocitiesBox.Size = new System.Drawing.Size(377, 486);
            this.busVelocitiesBox.TabIndex = 5;
            this.busVelocitiesBox.TabStop = false;
            this.busVelocitiesBox.Text = "Скорость автобусов на перегонах:";
            // 
            // busesVelocitiesTable
            // 
            this.busesVelocitiesTable.AllowUserToAddRows = false;
            this.busesVelocitiesTable.AllowUserToDeleteRows = false;
            this.busesVelocitiesTable.AllowUserToResizeColumns = false;
            this.busesVelocitiesTable.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.busesVelocitiesTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.busesVelocitiesTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.busesVelocitiesTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.busesVelocitiesTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.busesVelocitiesTable.DefaultCellStyle = dataGridViewCellStyle3;
            this.busesVelocitiesTable.Location = new System.Drawing.Point(3, 18);
            this.busesVelocitiesTable.MultiSelect = false;
            this.busesVelocitiesTable.Name = "busesVelocitiesTable";
            this.busesVelocitiesTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = "0";
            this.busesVelocitiesTable.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.busesVelocitiesTable.RowTemplate.Height = 24;
            this.busesVelocitiesTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.busesVelocitiesTable.Size = new System.Drawing.Size(368, 462);
            this.busesVelocitiesTable.TabIndex = 0;
            // 
            // BusEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 656);
            this.Controls.Add(this.busVelocitiesBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.toolBoxGroup);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.MaximumSize = new System.Drawing.Size(1071, 1674);
            this.MinimumSize = new System.Drawing.Size(1071, 674);
            this.Name = "BusEditor";
            this.Text = "Моделирование пассажирских перевозок [Редактор транспорта]";
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.toolBoxGroup.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.busVelocitiesBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.busesVelocitiesTable)).EndInit();
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
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button addBusButton;
        private System.Windows.Forms.ToolStripMenuItem clearBusesListMenuItem;
        private System.Windows.Forms.GroupBox busVelocitiesBox;
        private System.Windows.Forms.DataGridView busesVelocitiesTable;
    }
}