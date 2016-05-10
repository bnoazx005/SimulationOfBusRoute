namespace SimulationOfBusRoute.Views
{
    partial class StatisticsViewer
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.timeChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.timeChart)).BeginInit();
            this.SuspendLayout();
            // 
            // timeChart
            // 
            chartArea1.Name = "ChartArea1";
            this.timeChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.timeChart.Legends.Add(legend1);
            this.timeChart.Location = new System.Drawing.Point(24, 68);
            this.timeChart.Name = "timeChart";
            this.timeChart.Size = new System.Drawing.Size(896, 447);
            this.timeChart.TabIndex = 0;
            this.timeChart.Text = "chart1";
            // 
            // StatisticsViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 568);
            this.Controls.Add(this.timeChart);
            this.Name = "StatisticsViewer";
            this.Text = "Моделирование пассажирских перевозок [Вычисления]";
            ((System.ComponentModel.ISupportInitialize)(this.timeChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart timeChart;
    }
}