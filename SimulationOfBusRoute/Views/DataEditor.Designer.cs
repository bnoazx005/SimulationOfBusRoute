namespace SimulationOfBusRoute.Views
{
    partial class DataEditor
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
            this.menu = new System.Windows.Forms.MenuStrip();
            this.fileMenuGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.closeWindowMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editMenuGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.undoChangesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoChangesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyTextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteTextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutTextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actionsMenuGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.compileDataMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenuGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.docsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolBoxGroup = new System.Windows.Forms.GroupBox();
            this.redoChangesButton = new System.Windows.Forms.Button();
            this.undoChangesButton = new System.Windows.Forms.Button();
            this.copyTextButton = new System.Windows.Forms.Button();
            this.pasteTextButton = new System.Windows.Forms.Button();
            this.cutTextButton = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            this.generateDataButton = new System.Windows.Forms.Button();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.exceptionLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.editorTimer = new System.Windows.Forms.Timer(this.components);
            this.editorTabs = new System.Windows.Forms.TabControl();
            this.stationsDataEditorTab = new System.Windows.Forms.TabPage();
            this.stationsDataEditorText = new System.Windows.Forms.RichTextBox();
            this.stationsEditorHeaderText = new System.Windows.Forms.RichTextBox();
            this.busVelocitiesEditorTab = new System.Windows.Forms.TabPage();
            this.busVelocitiesEditorText = new System.Windows.Forms.RichTextBox();
            this.busVelocitiesHeaderText = new System.Windows.Forms.RichTextBox();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menu.SuspendLayout();
            this.toolBoxGroup.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.editorTabs.SuspendLayout();
            this.stationsDataEditorTab.SuspendLayout();
            this.busVelocitiesEditorTab.SuspendLayout();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuGroup,
            this.editMenuGroup,
            this.actionsMenuGroup,
            this.helpMenuGroup});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(869, 28);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // fileMenuGroup
            // 
            this.fileMenuGroup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeWindowMenuItem});
            this.fileMenuGroup.Name = "fileMenuGroup";
            this.fileMenuGroup.Size = new System.Drawing.Size(57, 24);
            this.fileMenuGroup.Text = "Файл";
            // 
            // closeWindowMenuItem
            // 
            this.closeWindowMenuItem.Name = "closeWindowMenuItem";
            this.closeWindowMenuItem.Size = new System.Drawing.Size(179, 26);
            this.closeWindowMenuItem.Text = "Закрыть окно";
            // 
            // editMenuGroup
            // 
            this.editMenuGroup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoChangesMenuItem,
            this.redoChangesMenuItem,
            this.copyTextMenuItem,
            this.pasteTextMenuItem,
            this.cutTextMenuItem});
            this.editMenuGroup.Name = "editMenuGroup";
            this.editMenuGroup.Size = new System.Drawing.Size(72, 24);
            this.editMenuGroup.Text = "Правка";
            // 
            // undoChangesMenuItem
            // 
            this.undoChangesMenuItem.Name = "undoChangesMenuItem";
            this.undoChangesMenuItem.Size = new System.Drawing.Size(168, 26);
            this.undoChangesMenuItem.Text = "Отменить";
            // 
            // redoChangesMenuItem
            // 
            this.redoChangesMenuItem.Name = "redoChangesMenuItem";
            this.redoChangesMenuItem.Size = new System.Drawing.Size(168, 26);
            this.redoChangesMenuItem.Text = "Повторить";
            // 
            // copyTextMenuItem
            // 
            this.copyTextMenuItem.Name = "copyTextMenuItem";
            this.copyTextMenuItem.Size = new System.Drawing.Size(168, 26);
            this.copyTextMenuItem.Text = "Копировать";
            // 
            // pasteTextMenuItem
            // 
            this.pasteTextMenuItem.Name = "pasteTextMenuItem";
            this.pasteTextMenuItem.Size = new System.Drawing.Size(168, 26);
            this.pasteTextMenuItem.Text = "Вставить";
            // 
            // cutTextMenuItem
            // 
            this.cutTextMenuItem.Name = "cutTextMenuItem";
            this.cutTextMenuItem.Size = new System.Drawing.Size(168, 26);
            this.cutTextMenuItem.Text = "Вырезать";
            // 
            // actionsMenuGroup
            // 
            this.actionsMenuGroup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.compileDataMenuItem});
            this.actionsMenuGroup.Name = "actionsMenuGroup";
            this.actionsMenuGroup.Size = new System.Drawing.Size(86, 24);
            this.actionsMenuGroup.Text = "Действие";
            // 
            // compileDataMenuItem
            // 
            this.compileDataMenuItem.Name = "compileDataMenuItem";
            this.compileDataMenuItem.Size = new System.Drawing.Size(260, 26);
            this.compileDataMenuItem.Text = "Скомпилировать данные";
            // 
            // helpMenuGroup
            // 
            this.helpMenuGroup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.docsMenuItem});
            this.helpMenuGroup.Name = "helpMenuGroup";
            this.helpMenuGroup.Size = new System.Drawing.Size(81, 24);
            this.helpMenuGroup.Text = "Помощь";
            // 
            // docsMenuItem
            // 
            this.docsMenuItem.Name = "docsMenuItem";
            this.docsMenuItem.Size = new System.Drawing.Size(142, 26);
            this.docsMenuItem.Text = "Справка";
            // 
            // toolBoxGroup
            // 
            this.toolBoxGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolBoxGroup.Controls.Add(this.redoChangesButton);
            this.toolBoxGroup.Controls.Add(this.undoChangesButton);
            this.toolBoxGroup.Controls.Add(this.copyTextButton);
            this.toolBoxGroup.Controls.Add(this.pasteTextButton);
            this.toolBoxGroup.Controls.Add(this.cutTextButton);
            this.toolBoxGroup.Controls.Add(this.quitButton);
            this.toolBoxGroup.Controls.Add(this.generateDataButton);
            this.toolBoxGroup.Location = new System.Drawing.Point(2, 30);
            this.toolBoxGroup.Name = "toolBoxGroup";
            this.toolBoxGroup.Size = new System.Drawing.Size(864, 68);
            this.toolBoxGroup.TabIndex = 2;
            this.toolBoxGroup.TabStop = false;
            this.toolBoxGroup.Text = "Панель инструментов";
            // 
            // redoChangesButton
            // 
            this.redoChangesButton.BackColor = System.Drawing.SystemColors.Control;
            this.redoChangesButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.redoChangesButton.Image = global::SimulationOfBusRoute.Properties.Resources.mRedoButton;
            this.redoChangesButton.Location = new System.Drawing.Point(134, 21);
            this.redoChangesButton.Name = "redoChangesButton";
            this.redoChangesButton.Size = new System.Drawing.Size(39, 38);
            this.redoChangesButton.TabIndex = 21;
            this.redoChangesButton.UseVisualStyleBackColor = false;
            // 
            // undoChangesButton
            // 
            this.undoChangesButton.BackColor = System.Drawing.SystemColors.Control;
            this.undoChangesButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.undoChangesButton.Image = global::SimulationOfBusRoute.Properties.Resources.mUndoButton;
            this.undoChangesButton.Location = new System.Drawing.Point(89, 21);
            this.undoChangesButton.Name = "undoChangesButton";
            this.undoChangesButton.Size = new System.Drawing.Size(39, 38);
            this.undoChangesButton.TabIndex = 20;
            this.undoChangesButton.UseVisualStyleBackColor = false;
            // 
            // copyTextButton
            // 
            this.copyTextButton.BackColor = System.Drawing.SystemColors.Control;
            this.copyTextButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.copyTextButton.Image = global::SimulationOfBusRoute.Properties.Resources.mCopyButton;
            this.copyTextButton.Location = new System.Drawing.Point(261, 21);
            this.copyTextButton.Name = "copyTextButton";
            this.copyTextButton.Size = new System.Drawing.Size(39, 38);
            this.copyTextButton.TabIndex = 19;
            this.copyTextButton.UseVisualStyleBackColor = false;
            // 
            // pasteTextButton
            // 
            this.pasteTextButton.BackColor = System.Drawing.SystemColors.Control;
            this.pasteTextButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pasteTextButton.Image = global::SimulationOfBusRoute.Properties.Resources.mPasteButton;
            this.pasteTextButton.Location = new System.Drawing.Point(306, 21);
            this.pasteTextButton.Name = "pasteTextButton";
            this.pasteTextButton.Size = new System.Drawing.Size(39, 38);
            this.pasteTextButton.TabIndex = 18;
            this.pasteTextButton.UseVisualStyleBackColor = false;
            // 
            // cutTextButton
            // 
            this.cutTextButton.BackColor = System.Drawing.SystemColors.Control;
            this.cutTextButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cutTextButton.Image = global::SimulationOfBusRoute.Properties.Resources.mCutButton;
            this.cutTextButton.Location = new System.Drawing.Point(216, 21);
            this.cutTextButton.Name = "cutTextButton";
            this.cutTextButton.Size = new System.Drawing.Size(39, 38);
            this.cutTextButton.TabIndex = 17;
            this.cutTextButton.UseVisualStyleBackColor = false;
            // 
            // quitButton
            // 
            this.quitButton.BackColor = System.Drawing.SystemColors.Control;
            this.quitButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.quitButton.Image = global::SimulationOfBusRoute.Properties.Resources.mQuitButton;
            this.quitButton.Location = new System.Drawing.Point(10, 21);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(39, 38);
            this.quitButton.TabIndex = 16;
            this.quitButton.UseVisualStyleBackColor = false;
            // 
            // generateDataButton
            // 
            this.generateDataButton.BackColor = System.Drawing.SystemColors.Control;
            this.generateDataButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.generateDataButton.Image = global::SimulationOfBusRoute.Properties.Resources.mStartSimulationButton;
            this.generateDataButton.Location = new System.Drawing.Point(391, 21);
            this.generateDataButton.Name = "generateDataButton";
            this.generateDataButton.Size = new System.Drawing.Size(39, 38);
            this.generateDataButton.TabIndex = 15;
            this.generateDataButton.UseVisualStyleBackColor = false;
            // 
            // statusBar
            // 
            this.statusBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exceptionLabel});
            this.statusBar.Location = new System.Drawing.Point(0, 533);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(869, 22);
            this.statusBar.TabIndex = 3;
            this.statusBar.Text = "statusStrip1";
            // 
            // exceptionLabel
            // 
            this.exceptionLabel.Name = "exceptionLabel";
            this.exceptionLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // editorTimer
            // 
            this.editorTimer.Enabled = true;
            this.editorTimer.Interval = 2500;
            // 
            // editorTabs
            // 
            this.editorTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editorTabs.Controls.Add(this.stationsDataEditorTab);
            this.editorTabs.Controls.Add(this.busVelocitiesEditorTab);
            this.editorTabs.Location = new System.Drawing.Point(2, 104);
            this.editorTabs.Name = "editorTabs";
            this.editorTabs.SelectedIndex = 0;
            this.editorTabs.Size = new System.Drawing.Size(864, 426);
            this.editorTabs.TabIndex = 4;
            // 
            // stationsDataEditorTab
            // 
            this.stationsDataEditorTab.BackColor = System.Drawing.SystemColors.Control;
            this.stationsDataEditorTab.Controls.Add(this.stationsDataEditorText);
            this.stationsDataEditorTab.Controls.Add(this.stationsEditorHeaderText);
            this.stationsDataEditorTab.Location = new System.Drawing.Point(4, 25);
            this.stationsDataEditorTab.Name = "stationsDataEditorTab";
            this.stationsDataEditorTab.Padding = new System.Windows.Forms.Padding(3);
            this.stationsDataEditorTab.Size = new System.Drawing.Size(856, 397);
            this.stationsDataEditorTab.TabIndex = 0;
            this.stationsDataEditorTab.Text = "Редактор матриц интенсивности";
            // 
            // stationsDataEditorText
            // 
            this.stationsDataEditorText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.stationsDataEditorText.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stationsDataEditorText.Location = new System.Drawing.Point(3, 99);
            this.stationsDataEditorText.Name = "stationsDataEditorText";
            this.stationsDataEditorText.Size = new System.Drawing.Size(850, 295);
            this.stationsDataEditorText.TabIndex = 5;
            this.stationsDataEditorText.Text = "";
            // 
            // stationsEditorHeaderText
            // 
            this.stationsEditorHeaderText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.stationsEditorHeaderText.BackColor = System.Drawing.SystemColors.Window;
            this.stationsEditorHeaderText.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stationsEditorHeaderText.Location = new System.Drawing.Point(3, 3);
            this.stationsEditorHeaderText.Name = "stationsEditorHeaderText";
            this.stationsEditorHeaderText.ReadOnly = true;
            this.stationsEditorHeaderText.Size = new System.Drawing.Size(850, 96);
            this.stationsEditorHeaderText.TabIndex = 4;
            this.stationsEditorHeaderText.Text = "";
            // 
            // busVelocitiesEditorTab
            // 
            this.busVelocitiesEditorTab.BackColor = System.Drawing.SystemColors.Control;
            this.busVelocitiesEditorTab.Controls.Add(this.busVelocitiesEditorText);
            this.busVelocitiesEditorTab.Controls.Add(this.busVelocitiesHeaderText);
            this.busVelocitiesEditorTab.Location = new System.Drawing.Point(4, 25);
            this.busVelocitiesEditorTab.Name = "busVelocitiesEditorTab";
            this.busVelocitiesEditorTab.Padding = new System.Windows.Forms.Padding(3);
            this.busVelocitiesEditorTab.Size = new System.Drawing.Size(856, 397);
            this.busVelocitiesEditorTab.TabIndex = 1;
            this.busVelocitiesEditorTab.Text = "Редактор скоростей автобусов";
            // 
            // busVelocitiesEditorText
            // 
            this.busVelocitiesEditorText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.busVelocitiesEditorText.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.busVelocitiesEditorText.Location = new System.Drawing.Point(3, 100);
            this.busVelocitiesEditorText.Name = "busVelocitiesEditorText";
            this.busVelocitiesEditorText.Size = new System.Drawing.Size(850, 294);
            this.busVelocitiesEditorText.TabIndex = 6;
            this.busVelocitiesEditorText.Text = "";
            // 
            // busVelocitiesHeaderText
            // 
            this.busVelocitiesHeaderText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.busVelocitiesHeaderText.BackColor = System.Drawing.SystemColors.Window;
            this.busVelocitiesHeaderText.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.busVelocitiesHeaderText.Location = new System.Drawing.Point(3, 3);
            this.busVelocitiesHeaderText.Name = "busVelocitiesHeaderText";
            this.busVelocitiesHeaderText.ReadOnly = true;
            this.busVelocitiesHeaderText.Size = new System.Drawing.Size(850, 96);
            this.busVelocitiesHeaderText.TabIndex = 5;
            this.busVelocitiesHeaderText.Text = "";
            // 
            // contextMenu
            // 
            this.contextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(218, 30);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(217, 26);
            this.toolStripMenuItem1.Text = "toolStripMenuItem1";
            // 
            // DataEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 555);
            this.Controls.Add(this.editorTabs);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.toolBoxGroup);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.Name = "DataEditor";
            this.Text = "Моделирование пассажирских перевозок [Редактор данных]";
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.toolBoxGroup.ResumeLayout(false);
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.editorTabs.ResumeLayout(false);
            this.stationsDataEditorTab.ResumeLayout(false);
            this.busVelocitiesEditorTab.ResumeLayout(false);
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem fileMenuGroup;
        private System.Windows.Forms.GroupBox toolBoxGroup;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripMenuItem closeWindowMenuItem;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Button generateDataButton;
        private System.Windows.Forms.ToolStripMenuItem editMenuGroup;
        private System.Windows.Forms.ToolStripMenuItem undoChangesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoChangesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyTextMenuItem;
        private System.Windows.Forms.Timer editorTimer;
        private System.Windows.Forms.ToolStripStatusLabel exceptionLabel;
        private System.Windows.Forms.TabControl editorTabs;
        private System.Windows.Forms.TabPage stationsDataEditorTab;
        private System.Windows.Forms.TabPage busVelocitiesEditorTab;
        private System.Windows.Forms.ToolStripMenuItem pasteTextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutTextMenuItem;
        private System.Windows.Forms.Button redoChangesButton;
        private System.Windows.Forms.Button undoChangesButton;
        private System.Windows.Forms.Button copyTextButton;
        private System.Windows.Forms.Button pasteTextButton;
        private System.Windows.Forms.Button cutTextButton;
        private System.Windows.Forms.ToolStripMenuItem actionsMenuGroup;
        private System.Windows.Forms.ToolStripMenuItem compileDataMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenuGroup;
        private System.Windows.Forms.ToolStripMenuItem docsMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.RichTextBox stationsEditorHeaderText;
        private System.Windows.Forms.RichTextBox stationsDataEditorText;
        private System.Windows.Forms.RichTextBox busVelocitiesHeaderText;
        private System.Windows.Forms.RichTextBox busVelocitiesEditorText;
    }
}