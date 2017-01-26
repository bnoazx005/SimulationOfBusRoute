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

            Shown       += (sender, e) => { if (OnFormInit != null) { OnFormInit(this, e); } };
            FormClosing += (sender, e) => { if (OnQuit != null) { OnQuit(this, e); } };

            saveDataButton.Click    += (sender, e) => { if (OnGenerateReport != null) { OnGenerateReport(sender, e); } };

            closeFormMenuItem.Click += (sender, e) => { if (OnCloseForm != null) { OnCloseForm(null, e); } };
            quitButton.Click        += (sender, e) => { if (OnCloseForm != null) { OnCloseForm(null, EventArgs.Empty); } };

            busesList.ItemCheck    += (sender, e) => { if (OnBusesListItemChecked != null) { OnBusesListItemChecked(sender, e); } };
            stationsList.ItemCheck += (sender, e) => { if (OnStationsListItemChecked != null) { OnStationsListItemChecked(sender, e); } };

            selectAllBusItemsButton.Click   += (sender, e) => { if (OnBusesListSelectAllItems != null) { OnBusesListSelectAllItems(sender, e); } };
            deselectAllBusItemsButton.Click += (sender, e) => { if (OnBusesListDeselectAllItems != null) { OnBusesListDeselectAllItems(sender, e); } };
            
            selectAllStationItemsButton.Click   += (sender, e) => { if (OnStationsListSelectAllItems != null) { OnStationsListSelectAllItems(sender, e); } };
            deselectAllStationItemsButton.Click += (sender, e) => { if (OnStationsListDeselectAllItems != null) { OnStationsListDeselectAllItems(sender, e); } };

            busPlotType.SelectedIndexChanged += (sender, e) => { if (OnBusPlotTypeChanged != null) { OnBusPlotTypeChanged(sender, e); } };
            stationPlotType.SelectedIndexChanged += (sender, e) => { if (OnStationPlotTypeChanged != null) { OnStationPlotTypeChanged(sender, e); } };

            busesDataNavigator.AddStandardItems();
            busesDataNavigator.AddNewItem.Dispose();
            busesDataNavigator.DeleteItem.Dispose();
            
            stationsDataNavigator.AddStandardItems();
            stationsDataNavigator.AddNewItem.Dispose();
            stationsDataNavigator.DeleteItem.Dispose();
        }

        public event EventHandler OnCloseForm;
        public event EventHandler OnFormInit;
        public event FormClosingEventHandler OnQuit;
        public event ItemCheckEventHandler OnBusesListItemChecked;
        public event EventHandler OnBusesListSelectAllItems;
        public event EventHandler OnBusesListDeselectAllItems;
        public event EventHandler OnStationsListSelectAllItems;
        public event EventHandler OnStationsListDeselectAllItems;
        public event ItemCheckEventHandler OnStationsListItemChecked;
        public event EventHandler OnBusPlotTypeChanged;
        public event EventHandler OnStationPlotTypeChanged;
        public event EventHandler OnGenerateReport;

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

        public ToolStripProgressBar OperationProgress
        {
            get
            {
                return progressBar;
            }

            set
            {
                progressBar = value;
            }
        }

        public bool IsComputing
        {
            get
            {
                return progressBarLabel.Visible;
            }

            set
            {
                progressBarLabel.Visible = value;
            }
        }

        public Chart BusesPlot
        {
            get
            {
                return busPlot;
            }

            set
            {
                busPlot = value;
            }
        }

        public Chart StationsPlot
        {
            get
            {
                return stationPlot;
            }

            set
            {
                stationPlot = value;
            }
        }

        public DataGridView BusesTable
        {
            get
            {
                return busesTable;
            }

            set
            {
                busesTable = value;
            }
        }

        public DataGridView StationsTable
        {
            get
            {
                return stationsTable;
            }

            set
            {
                stationsTable = value;
            }
        }

        public CheckedListBox BusesList
        {
            get
            {
                return busesList;
            }

            set
            {
                busesList = value;
            }
        }

        public CheckedListBox StationsList
        {
            get
            {
                return stationsList;
            }

            set
            {
                stationsList = value;
            }
        }

        public ComboBox BusPlotType
        {
            get
            {
                return busPlotType;
            }

            set
            {
                busPlotType = value;
            }
        }

        public ComboBox StationPlotType
        {
            get
            {
                return stationPlotType;
            }

            set
            {
                stationPlotType = value;
            }
        }

        public BindingNavigator BusesDataNavigator
        {
            get
            {
                return busesDataNavigator;
            }

            set
            {
                busesDataNavigator = value;
            }
        }
        
        public BindingNavigator StationsDataNavigator
        {
            get
            {
                return stationsDataNavigator;
            }

            set
            {
                stationsDataNavigator = value;
            }
        }

        public SaveFileDialog SaveFileDialogObject
        {
            get
            {
                return saveFileDialog;
            }

            set
            {
                saveFileDialog = value;
            }
        }
    }
}
