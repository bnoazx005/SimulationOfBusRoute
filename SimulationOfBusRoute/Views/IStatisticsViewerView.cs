using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace SimulationOfBusRoute.Views
{
    public interface IStatisticsViewerView : IBaseView
    {
        ToolStripProgressBar OperationProgress { get; set; }

        bool IsComputing { get; set; }

        Chart BusesPlot { get; set; }

        Chart StationsPlot { get; set; }

        DataGridView BusesTable { get; set; }

        DataGridView StationsTable { get; set; }

        CheckedListBox BusesList { get; set; }

        CheckedListBox StationsList { get; set; }

        ComboBox BusPlotType { get; set; }

        ComboBox StationPlotType { get; set; }

        BindingNavigator BusesDataNavigator { get; set; }

        BindingNavigator StationsDataNavigator { get; set; }

        SaveFileDialog SaveFileDialogObject { get; set; }

        event EventHandler OnFormInit;

        //event EventHandler OnFormShown;

        event FormClosingEventHandler OnQuit;

        event EventHandler OnCloseForm;

        event ItemCheckEventHandler OnBusesListItemChecked;

        event ItemCheckEventHandler OnStationsListItemChecked;

        event EventHandler OnBusesListSelectAllItems;

        event EventHandler OnBusesListDeselectAllItems;

        event EventHandler OnStationsListSelectAllItems;

        event EventHandler OnStationsListDeselectAllItems;

        event EventHandler OnBusPlotTypeChanged;

        event EventHandler OnStationPlotTypeChanged;

        event EventHandler OnGenerateReport;
    }
}
