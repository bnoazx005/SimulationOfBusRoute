﻿namespace SimulationOfBusRoute.Views
{
    partial class StationsEditor
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
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.закрытьОкноToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.действиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьМатрицуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьМатрицуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.очиститьСписокToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolBoxGroup = new System.Windows.Forms.GroupBox();
            this.clearDataButton = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            this.addMatrixButton = new System.Windows.Forms.Button();
            this.removeMatrixButton = new System.Windows.Forms.Button();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.dataGroupBox = new System.Windows.Forms.GroupBox();
            this.dataEditor = new System.Windows.Forms.RichTextBox();
            this.stationsListGroupBox = new System.Windows.Forms.GroupBox();
            this.listOfStationsMatrices = new System.Windows.Forms.ListBox();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.editorTimer = new System.Windows.Forms.Timer(this.components);
            this.menu.SuspendLayout();
            this.toolBoxGroup.SuspendLayout();
            this.dataGroupBox.SuspendLayout();
            this.stationsListGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.действиеToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(869, 28);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.закрытьОкноToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // закрытьОкноToolStripMenuItem
            // 
            this.закрытьОкноToolStripMenuItem.Name = "закрытьОкноToolStripMenuItem";
            this.закрытьОкноToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.закрытьОкноToolStripMenuItem.Text = "Закрыть окно";
            // 
            // действиеToolStripMenuItem
            // 
            this.действиеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьМатрицуToolStripMenuItem,
            this.удалитьМатрицуToolStripMenuItem,
            this.очиститьСписокToolStripMenuItem});
            this.действиеToolStripMenuItem.Name = "действиеToolStripMenuItem";
            this.действиеToolStripMenuItem.Size = new System.Drawing.Size(86, 24);
            this.действиеToolStripMenuItem.Text = "Действие";
            // 
            // добавитьМатрицуToolStripMenuItem
            // 
            this.добавитьМатрицуToolStripMenuItem.Name = "добавитьМатрицуToolStripMenuItem";
            this.добавитьМатрицуToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.добавитьМатрицуToolStripMenuItem.Text = "Добавить матрицу";
            // 
            // удалитьМатрицуToolStripMenuItem
            // 
            this.удалитьМатрицуToolStripMenuItem.Name = "удалитьМатрицуToolStripMenuItem";
            this.удалитьМатрицуToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.удалитьМатрицуToolStripMenuItem.Text = "Удалить матрицу";
            // 
            // очиститьСписокToolStripMenuItem
            // 
            this.очиститьСписокToolStripMenuItem.Name = "очиститьСписокToolStripMenuItem";
            this.очиститьСписокToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.очиститьСписокToolStripMenuItem.Text = "Удалить все данные";
            // 
            // toolBoxGroup
            // 
            this.toolBoxGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolBoxGroup.Controls.Add(this.clearDataButton);
            this.toolBoxGroup.Controls.Add(this.quitButton);
            this.toolBoxGroup.Controls.Add(this.addMatrixButton);
            this.toolBoxGroup.Controls.Add(this.removeMatrixButton);
            this.toolBoxGroup.Location = new System.Drawing.Point(2, 30);
            this.toolBoxGroup.Name = "toolBoxGroup";
            this.toolBoxGroup.Size = new System.Drawing.Size(864, 68);
            this.toolBoxGroup.TabIndex = 2;
            this.toolBoxGroup.TabStop = false;
            this.toolBoxGroup.Text = "Панель инструментов";
            // 
            // clearDataButton
            // 
            this.clearDataButton.BackColor = System.Drawing.SystemColors.Control;
            this.clearDataButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.clearDataButton.Image = global::SimulationOfBusRoute.Properties.Resources.mRemoveNodeButton;
            this.clearDataButton.Location = new System.Drawing.Point(179, 21);
            this.clearDataButton.Name = "clearDataButton";
            this.clearDataButton.Size = new System.Drawing.Size(39, 38);
            this.clearDataButton.TabIndex = 17;
            this.clearDataButton.UseVisualStyleBackColor = false;
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
            // addMatrixButton
            // 
            this.addMatrixButton.BackColor = System.Drawing.SystemColors.Control;
            this.addMatrixButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.addMatrixButton.Image = global::SimulationOfBusRoute.Properties.Resources.mAddNodeButton;
            this.addMatrixButton.Location = new System.Drawing.Point(89, 21);
            this.addMatrixButton.Name = "addMatrixButton";
            this.addMatrixButton.Size = new System.Drawing.Size(39, 38);
            this.addMatrixButton.TabIndex = 15;
            this.addMatrixButton.UseVisualStyleBackColor = false;
            // 
            // removeMatrixButton
            // 
            this.removeMatrixButton.BackColor = System.Drawing.SystemColors.Control;
            this.removeMatrixButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.removeMatrixButton.Image = global::SimulationOfBusRoute.Properties.Resources.mRemoveNodeButton;
            this.removeMatrixButton.Location = new System.Drawing.Point(134, 21);
            this.removeMatrixButton.Name = "removeMatrixButton";
            this.removeMatrixButton.Size = new System.Drawing.Size(39, 38);
            this.removeMatrixButton.TabIndex = 14;
            this.removeMatrixButton.UseVisualStyleBackColor = false;
            // 
            // statusBar
            // 
            this.statusBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusBar.Location = new System.Drawing.Point(0, 533);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(869, 22);
            this.statusBar.TabIndex = 3;
            this.statusBar.Text = "statusStrip1";
            // 
            // dataGroupBox
            // 
            this.dataGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGroupBox.Controls.Add(this.dataEditor);
            this.dataGroupBox.Location = new System.Drawing.Point(3, 3);
            this.dataGroupBox.Name = "dataGroupBox";
            this.dataGroupBox.Size = new System.Drawing.Size(647, 414);
            this.dataGroupBox.TabIndex = 0;
            this.dataGroupBox.TabStop = false;
            this.dataGroupBox.Text = "Редактор данных:";
            // 
            // dataEditor
            // 
            this.dataEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataEditor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dataEditor.Location = new System.Drawing.Point(6, 21);
            this.dataEditor.Name = "dataEditor";
            this.dataEditor.Size = new System.Drawing.Size(635, 387);
            this.dataEditor.TabIndex = 0;
            this.dataEditor.Text = "case(<condition for counter>);\n\nmatrix(\n[[],\n [],\n...\n []]\n);";
            // 
            // stationsListGroupBox
            // 
            this.stationsListGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.stationsListGroupBox.Controls.Add(this.listOfStationsMatrices);
            this.stationsListGroupBox.Location = new System.Drawing.Point(3, 3);
            this.stationsListGroupBox.Name = "stationsListGroupBox";
            this.stationsListGroupBox.Size = new System.Drawing.Size(201, 414);
            this.stationsListGroupBox.TabIndex = 0;
            this.stationsListGroupBox.TabStop = false;
            this.stationsListGroupBox.Text = "Список данных:";
            // 
            // listOfStationsMatrices
            // 
            this.listOfStationsMatrices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listOfStationsMatrices.FormattingEnabled = true;
            this.listOfStationsMatrices.ItemHeight = 16;
            this.listOfStationsMatrices.Location = new System.Drawing.Point(7, 21);
            this.listOfStationsMatrices.Name = "listOfStationsMatrices";
            this.listOfStationsMatrices.Size = new System.Drawing.Size(188, 388);
            this.listOfStationsMatrices.TabIndex = 0;
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.Location = new System.Drawing.Point(2, 104);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.dataGroupBox);
            this.splitContainer.Panel1MinSize = 200;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.stationsListGroupBox);
            this.splitContainer.Panel2MinSize = 200;
            this.splitContainer.Size = new System.Drawing.Size(864, 426);
            this.splitContainer.SplitterDistance = 653;
            this.splitContainer.TabIndex = 4;
            // 
            // editorTimer
            // 
            this.editorTimer.Enabled = true;
            this.editorTimer.Interval = 2500;
            // 
            // StationsEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 555);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.toolBoxGroup);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.Name = "StationsEditor";
            this.Text = "Моделирование пассажирских перевозок [Редактор остановок]";
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.toolBoxGroup.ResumeLayout(false);
            this.dataGroupBox.ResumeLayout(false);
            this.stationsListGroupBox.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.GroupBox toolBoxGroup;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.GroupBox dataGroupBox;
        private System.Windows.Forms.GroupBox stationsListGroupBox;
        private System.Windows.Forms.ListBox listOfStationsMatrices;
        private System.Windows.Forms.RichTextBox dataEditor;
        private System.Windows.Forms.ToolStripMenuItem закрытьОкноToolStripMenuItem;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Button addMatrixButton;
        private System.Windows.Forms.Button removeMatrixButton;
        private System.Windows.Forms.ToolStripMenuItem действиеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьМатрицуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьМатрицуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem очиститьСписокToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Button clearDataButton;
        private System.Windows.Forms.Timer editorTimer;
    }
}