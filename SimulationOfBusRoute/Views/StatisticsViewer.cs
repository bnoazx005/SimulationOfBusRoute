using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace SimulationOfBusRoute.Views
{
    public partial class StatisticsViewer : Form, IStatisticsViewerView
    {
        public StatisticsViewer()
        {
            InitializeComponent();

            Load += (sender, e) => { if (OnFormInit != null) { OnFormInit(this, EventArgs.Empty); } };
            FormClosing += (sender, e) => { if (OnQuit != null) { OnQuit(this, e); } };
        }

        public event EventHandler OnCloseForm;
        public event EventHandler OnFormInit;
        public event FormClosingEventHandler OnQuit;

        #region Methods

        public void Display()
        {
            ShowDialog();
        }

        public void Quit()
        {
            Close();
        }

        #endregion

        public Chart TimeChart
        {
            get
            {
                return timeChart;
            }

            set
            {
                timeChart = value;
            }
        }
    }
}
