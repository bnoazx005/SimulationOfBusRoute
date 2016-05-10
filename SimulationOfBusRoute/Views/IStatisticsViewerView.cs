using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace SimulationOfBusRoute.Views
{
    public interface IStatisticsViewerView : IBaseView
    {
        event EventHandler OnFormInit;

        event FormClosingEventHandler OnQuit;

        event EventHandler OnCloseForm;

        Chart TimeChart { get; set; }
    }
}
