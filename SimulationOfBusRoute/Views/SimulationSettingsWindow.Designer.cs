﻿namespace SimulationOfBusRoute.Views
{
    partial class SimulationSettingsWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimulationSettingsWindow));
            this.simulationSettingsGroup = new System.Windows.Forms.GroupBox();
            this.acceptButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.speedOfSimulationGroup = new System.Windows.Forms.GroupBox();
            this.speedOfSimulationValue = new System.Windows.Forms.NumericUpDown();
            this.speedOfSimulationTrackBar = new System.Windows.Forms.TrackBar();
            this.timeSettingsGroup = new System.Windows.Forms.GroupBox();
            this.timeOfFinishValue = new System.Windows.Forms.MaskedTextBox();
            this.timeOfStartValue = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.simulationSettingsGroup.SuspendLayout();
            this.speedOfSimulationGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedOfSimulationValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedOfSimulationTrackBar)).BeginInit();
            this.timeSettingsGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // simulationSettingsGroup
            // 
            this.simulationSettingsGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.simulationSettingsGroup.Controls.Add(this.acceptButton);
            this.simulationSettingsGroup.Controls.Add(this.cancelButton);
            this.simulationSettingsGroup.Controls.Add(this.speedOfSimulationGroup);
            this.simulationSettingsGroup.Controls.Add(this.timeSettingsGroup);
            this.simulationSettingsGroup.Location = new System.Drawing.Point(5, 0);
            this.simulationSettingsGroup.Name = "simulationSettingsGroup";
            this.simulationSettingsGroup.Size = new System.Drawing.Size(378, 260);
            this.simulationSettingsGroup.TabIndex = 0;
            this.simulationSettingsGroup.TabStop = false;
            this.simulationSettingsGroup.Text = "Настройки режима моделирования";
            // 
            // acceptButton
            // 
            this.acceptButton.Location = new System.Drawing.Point(166, 222);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(99, 32);
            this.acceptButton.TabIndex = 3;
            this.acceptButton.Text = "Потвердить";
            this.acceptButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(271, 222);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(99, 32);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // speedOfSimulationGroup
            // 
            this.speedOfSimulationGroup.Controls.Add(this.speedOfSimulationValue);
            this.speedOfSimulationGroup.Controls.Add(this.speedOfSimulationTrackBar);
            this.speedOfSimulationGroup.Location = new System.Drawing.Point(6, 135);
            this.speedOfSimulationGroup.Name = "speedOfSimulationGroup";
            this.speedOfSimulationGroup.Size = new System.Drawing.Size(364, 81);
            this.speedOfSimulationGroup.TabIndex = 2;
            this.speedOfSimulationGroup.TabStop = false;
            this.speedOfSimulationGroup.Text = "Скорость моделирования:";
            // 
            // speedOfSimulationValue
            // 
            this.speedOfSimulationValue.Location = new System.Drawing.Point(293, 19);
            this.speedOfSimulationValue.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.speedOfSimulationValue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.speedOfSimulationValue.Name = "speedOfSimulationValue";
            this.speedOfSimulationValue.Size = new System.Drawing.Size(61, 22);
            this.speedOfSimulationValue.TabIndex = 1;
            this.speedOfSimulationValue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // speedOfSimulationTrackBar
            // 
            this.speedOfSimulationTrackBar.LargeChange = 3;
            this.speedOfSimulationTrackBar.Location = new System.Drawing.Point(9, 19);
            this.speedOfSimulationTrackBar.Minimum = 1;
            this.speedOfSimulationTrackBar.Name = "speedOfSimulationTrackBar";
            this.speedOfSimulationTrackBar.Size = new System.Drawing.Size(278, 56);
            this.speedOfSimulationTrackBar.TabIndex = 0;
            this.speedOfSimulationTrackBar.Value = 1;
            // 
            // timeSettingsGroup
            // 
            this.timeSettingsGroup.Controls.Add(this.timeOfFinishValue);
            this.timeSettingsGroup.Controls.Add(this.timeOfStartValue);
            this.timeSettingsGroup.Controls.Add(this.label1);
            this.timeSettingsGroup.Controls.Add(this.label6);
            this.timeSettingsGroup.Location = new System.Drawing.Point(6, 30);
            this.timeSettingsGroup.Name = "timeSettingsGroup";
            this.timeSettingsGroup.Size = new System.Drawing.Size(364, 90);
            this.timeSettingsGroup.TabIndex = 1;
            this.timeSettingsGroup.TabStop = false;
            this.timeSettingsGroup.Text = "Временной интервал для моделирования:";
            // 
            // timeOfFinishValue
            // 
            this.timeOfFinishValue.Location = new System.Drawing.Point(309, 53);
            this.timeOfFinishValue.Mask = "00:00";
            this.timeOfFinishValue.Name = "timeOfFinishValue";
            this.timeOfFinishValue.Size = new System.Drawing.Size(45, 22);
            this.timeOfFinishValue.TabIndex = 7;
            this.timeOfFinishValue.Text = "2300";
            this.timeOfFinishValue.ValidatingType = typeof(System.DateTime);
            // 
            // timeOfStartValue
            // 
            this.timeOfStartValue.BeepOnError = true;
            this.timeOfStartValue.Location = new System.Drawing.Point(309, 23);
            this.timeOfStartValue.Mask = "00:00";
            this.timeOfStartValue.Name = "timeOfStartValue";
            this.timeOfStartValue.Size = new System.Drawing.Size(45, 22);
            this.timeOfStartValue.TabIndex = 6;
            this.timeOfStartValue.Text = "0700";
            this.timeOfStartValue.ValidatingType = typeof(System.DateTime);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Время начала работы транспорта:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(273, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Время завершения работы транспорта:";
            // 
            // SimulationSettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 263);
            this.Controls.Add(this.simulationSettingsGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SimulationSettingsWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "[Окно настроек]";
            this.simulationSettingsGroup.ResumeLayout(false);
            this.speedOfSimulationGroup.ResumeLayout(false);
            this.speedOfSimulationGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedOfSimulationValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedOfSimulationTrackBar)).EndInit();
            this.timeSettingsGroup.ResumeLayout(false);
            this.timeSettingsGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox simulationSettingsGroup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox timeSettingsGroup;
        private System.Windows.Forms.GroupBox speedOfSimulationGroup;
        private System.Windows.Forms.NumericUpDown speedOfSimulationValue;
        private System.Windows.Forms.TrackBar speedOfSimulationTrackBar;
        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.MaskedTextBox timeOfFinishValue;
        private System.Windows.Forms.MaskedTextBox timeOfStartValue;
    }
}