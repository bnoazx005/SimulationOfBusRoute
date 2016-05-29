using SimulationOfBusRoute.Models.Implementations;
using SimulationOfBusRoute.Models.Implementations.Bus;
using SimulationOfBusRoute.Utils;
using SimulationOfBusRoute.Views;
using System;
using System.Linq;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Collections.Generic;


namespace SimulationOfBusRoute.Presenters.StatisticsViewerPresenter
{
    public class CStatisticsViewerPresenter : CBasePresenter<CDataManager, IStatisticsViewerView>
    {
        public enum E_BUS_PLOT_TYPE
        {
            [Description("Время прибытия на остановку")]
            BPT_TOTAL_TIME,
            [Description("Время ожидания")]
            BPT_WAITING_TIME,
            [Description("Динамика наполняемости")]
            BPT_CAPACITY,
            [Description("Число входящих пассажиров")]
            BPT_INCOMING_PASSENGERS,
            [Description("Число выходящих пассажиров")]
            BPT_EXCURRENT_PASSENGERS,
        }

        public enum E_STATIONS_PLOT_TYPE
        {
            [Description("Число пассажиров")]
            SPT_PASSENGERS,
            [Description("Эпюра пассажиропотока")]
            SPT_TRAFFIC_POWER,
        }
        
        private CComputationsResults mComputationsResults;

        private BindingSource mBusesTableData;

        private BindingSource mStationsTableData;

        private const int mBusesPageSize = 30;

        private const int mStationsPageSize = 30;

        private BindingList<BindingList<TBusTableEntity>> mBusesDataPages;

        private BindingList<BindingList<TStationTableEntity>> mStationsDataPages;

        public CStatisticsViewerPresenter(CDataManager model, IStatisticsViewerView view):
            base(model, view)
        {
            mView.OnFormInit += _onFormInit;
            mView.OnQuit += _onQuit;

            mView.OnCloseForm += _onCloseForm;

            mView.OnBusesListItemChecked    += _onBusesListItemChecked;
            mView.OnStationsListItemChecked += _onStationsListItemChecked;

            mView.OnBusesListSelectAllItems      += _onBusesListSelectAllItems;
            mView.OnBusesListDeselectAllItems    += _onBusesListDeselectAllItems;

            mView.OnStationsListSelectAllItems   += _onStationsListSelectAllItems;
            mView.OnStationsListDeselectAllItems += _onStationsListDeselectAllItems;

            mView.OnGenerateReport += _onGenerateReport;

            mComputationsResults = model.ComputationsResults;

            mView.IsComputing = false;
        }

        private void _onFormInit(object sender, EventArgs e)
        {
            IStatisticsViewerView view = mView;

            Chart stationsPlot = view.StationsPlot;

            CheckedListBox stationsList = view.StationsList;

            ComboBox busPlotType = view.BusPlotType;

            foreach (CBusStation station in mModel.CurrBusRouteObject.BusStationsList)
            {
                var stationSeries = stationsPlot.Series.Add(station.BusStationId.ToString());
                stationSeries.ChartType = SeriesChartType.Column;

                stationsList.Items.Add(station.BusStationId);

                for (int i = 0; i < stationsList.Items.Count; i++)
                {
                    stationsList.SetItemChecked(i, true);
                }
            }

            busPlotType.DisplayMember = "Key";
            busPlotType.ValueMember = "Value";

            busPlotType.DataSource = typeof(E_BUS_PLOT_TYPE).ToDescriptionsList();

            mView.OnBusPlotTypeChanged += _onBusPlotTypeChanged;

            ComboBox stationPlotType = view.StationPlotType;

            stationPlotType.DisplayMember = "Key";
            stationPlotType.ValueMember = "Value";

            stationPlotType.DataSource = typeof(E_STATIONS_PLOT_TYPE).ToDescriptionsList();

            mView.OnStationPlotTypeChanged += _onStationPlotTypeChanged;
            
            Chart busesPlot = view.BusesPlot;

            CheckedListBox busesList = view.BusesList;
            
            foreach (CBus bus in mModel.BusesStorage.GetAll())
            {
                var stationSeries = busesPlot.Series.Add(bus.Name + bus.ID);
                stationSeries.ChartType = SeriesChartType.Column;

                busesList.Items.Add(bus.Name + bus.ID);

                for (int i = 0; i < busesList.Items.Count; i++)
                {
                    busesList.SetItemChecked(i, true);
                }
            }

            if (mModel.ComputationsResults.IsEmpty)
            {
                _computeData();
            }
            else
            {
                _onBusPlotTypeChanged(null, EventArgs.Empty);
                _onStationPlotTypeChanged(null, EventArgs.Empty);
            }

            mBusesDataPages = _generatePages(mComputationsResults.BusesRecords, mBusesPageSize);

            mBusesTableData = new BindingSource();

            view.BusesDataNavigator.BindingSource = mBusesTableData;

            mBusesTableData.DataSource = mBusesDataPages;
            mBusesTableData.PositionChanged += _onBusesDataPositionChanged;

            _onBusesDataPositionChanged(null, EventArgs.Empty);


            mStationsDataPages = _generatePages(mComputationsResults.StationsRecords, mStationsPageSize);

            mStationsTableData = new BindingSource();

            view.StationsDataNavigator.BindingSource = mStationsTableData;

            mStationsTableData.DataSource = mStationsDataPages;
            mStationsTableData.PositionChanged += _onStationsDataPositionChanged;

            _onStationsDataPositionChanged(null, EventArgs.Empty);
            
            busesPlot.Invalidate();
            stationsPlot.Invalidate();
        }

        private void _computeData()
        {
            CTimer timer = new CTimer(0, 1);

            IStatisticsViewerView view = mView;

            Chart stationsPlot = view.StationsPlot;
            
            foreach (CBusStation station in mModel.CurrBusRouteObject.BusStationsList)
            {
                timer.Subscribe(station);
                station.OnGetData += _onPrintStation;
            }

            Chart busesPlot = view.BusesPlot;
           
            foreach (CBus bus in mModel.BusesStorage.GetAll())
            {
                timer.Subscribe(bus);
                bus.OnGetData += _onPrintBus;
            }

            int numOfSteps = mModel.OptionsList.GetIntParam(Properties.Resources.mOptionsNumOfSimulationSteps);

            ToolStripProgressBar operationProgress = View.OperationProgress;
            operationProgress.Maximum = numOfSteps;
            operationProgress.Step = 1;
            View.IsComputing = true;

            ToolStrip statusBar = operationProgress.GetCurrentParent();

            CBackgroundJobHelper.BackgroundModelOperation(ref mModel, "Выполняются вычисления...", () =>
            {
                while (timer.CurrTime < numOfSteps)
                {
                    timer.Tick();
                    statusBar.Invoke((MethodInvoker)(() => operationProgress.Increment(operationProgress.Step)));
                }
            });

            operationProgress.Value = 0;
            operationProgress.Visible = false;
            View.IsComputing = false;
            
            foreach (CBusStation station in mModel.CurrBusRouteObject.BusStationsList)
            {
                station.OnGetData -= _onPrintStation;
            }

            foreach (CBus bus in mModel.BusesStorage.GetAll())
            {
                bus.OnGetData -= _onPrintBus;
            }
        }

        private void _onPrintBus(CBus bus)
        {
            Chart busesPlot = mView.BusesPlot;

            System.Diagnostics.Debug.Assert(bus.CurrBusCapacity <= bus.MaxBusCapacity);

            if (busesPlot.InvokeRequired)
            {
                busesPlot.Invoke((MethodInvoker)(() =>
                {
                    busesPlot.Titles[0].Text = Properties.Resources.mBusesPlotTotalTimeTitle;

                    busesPlot.Series.FindByName(bus.Name + bus.ID).Points.AddXY(bus.CurrArrivalTime, bus.CurrStation.BusStationId);
                    busesPlot.Series.FindByName(bus.Name + bus.ID).Points.AddXY(bus.CurrDepartureTime, bus.CurrStation.BusStationId);

                    mComputationsResults.BusesRecords.Add(bus.ToTableEntity());
                }));
            }
            else
            {
                busesPlot.Titles[0].Text = Properties.Resources.mBusesPlotTotalTimeTitle;

                busesPlot.Series.FindByName(bus.Name + bus.ID).Points.AddXY(bus.CurrStation.BusStationId, bus.CurrArrivalTime);
                busesPlot.Series.FindByName(bus.Name + bus.ID).Points.AddXY(bus.CurrStation.BusStationId, bus.CurrDepartureTime);

                mComputationsResults.BusesRecords.Add(bus.ToTableEntity());
            }
        }

        private void _onPrintStation(CBusStation station)
        {
            Chart stationsPlot = mView.StationsPlot;

            if (stationsPlot.InvokeRequired)
            {
                stationsPlot.Invoke((MethodInvoker)(() =>
                {
                    stationsPlot.Titles[0].Text = Properties.Resources.mStationsPlotPassengersCountTitle;

                    stationsPlot.Series.FindByName(station.BusStationId.ToString()).Points.AddXY(station.ReactionTime, station.CurrNumOfPassengers);

                    mComputationsResults.StationsRecords.Add(station.ToTableEntity());
                }));
            }                
            else
            {
                stationsPlot.Titles[0].Text = Properties.Resources.mStationsPlotPassengersCountTitle;

                stationsPlot.Series.FindByName(station.BusStationId.ToString()).Points.AddXY(station.ReactionTime, station.CurrNumOfPassengers);

                mComputationsResults.StationsRecords.Add(station.ToTableEntity());
            }
        }

        private void _onQuit(object sender, FormClosingEventArgs e)
        {
            mIsRunning = false;
        }

        private void _onCloseForm(object sender, EventArgs e)
        {
            mView.Quit();
        }

        private void _onBusesListItemChecked(object sender, ItemCheckEventArgs e)
        {
            Chart busesPlot = mView.BusesPlot;

            busesPlot.Series[e.Index].Enabled = e.NewValue == CheckState.Checked ? true : false;
        }

        private void _onBusesListDeselectAllItems(object sender, EventArgs e)
        {
            CheckedListBox busesList = mView.BusesList;

            for (int i = 0; i < busesList.Items.Count; i++)
            {
                busesList.SetItemChecked(i, false);
            }
        }

        private void _onBusesListSelectAllItems(object sender, EventArgs e)
        {
            CheckedListBox busesList = mView.BusesList;

            for (int i = 0; i < busesList.Items.Count; i++)
            {
                busesList.SetItemChecked(i, true);
            }
        }

        private void _onStationsListItemChecked(object sender, ItemCheckEventArgs e)
        {
            Chart stationsPlot = mView.StationsPlot;

            stationsPlot.Series[e.Index].Enabled = e.NewValue == CheckState.Checked ? true : false;
        }

        private void _onStationsListDeselectAllItems(object sender, EventArgs e)
        {
            CheckedListBox stationsList = mView.StationsList;

            for (int i = 0; i < stationsList.Items.Count; i++)
            {
                stationsList.SetItemChecked(i, false);
            }
        }

        private void _onStationsListSelectAllItems(object sender, EventArgs e)
        {
            CheckedListBox busesList = mView.StationsList;

            for (int i = 0; i < busesList.Items.Count; i++)
            {
                busesList.SetItemChecked(i, true);
            }
        }

        private void _onBusPlotTypeChanged(object sender, EventArgs e)
        {
            IStatisticsViewerView view = mView;

            E_BUS_PLOT_TYPE busPlotType = (E_BUS_PLOT_TYPE)view.BusPlotType.SelectedValue;
            Chart busPlot = view.BusesPlot;

            Action<TBusTableEntity> addDataOntoPlot = null;
            
            switch (busPlotType)
            {
                case E_BUS_PLOT_TYPE.BPT_TOTAL_TIME:

                    busPlot.Titles[0].Text = Properties.Resources.mBusesPlotTotalTimeTitle;

                    addDataOntoPlot = (entity) =>
                    {
                        Series currBusesPlot = busPlot.Series[entity.ID];

                        currBusesPlot.Points.AddXY(entity.CurrArrivalTime, entity.CurrStationId);
                        currBusesPlot.Points.AddXY(entity.CurrDepartureTime, entity.CurrStationId);

                        currBusesPlot.ChartType = SeriesChartType.Column;
                    };

                    break;

                case E_BUS_PLOT_TYPE.BPT_WAITING_TIME:

                    busPlot.Titles[0].Text = Properties.Resources.mBusesPlotWaitingTimeTitle;

                    addDataOntoPlot = (entity) =>
                    {
                        Series currBusesPlot = busPlot.Series[entity.ID];
                        
                        currBusesPlot.Points.AddXY(entity.CurrDepartureTime, entity.CurrDepartureTime - entity.CurrArrivalTime);

                        currBusesPlot.ChartType = SeriesChartType.Column;
                    };

                    break;

                case E_BUS_PLOT_TYPE.BPT_CAPACITY:

                    busPlot.Titles[0].Text = Properties.Resources.mBusesPlotCapacityTitle;

                    addDataOntoPlot = (entity) =>
                    {
                        Series currBusesPlot = busPlot.Series[entity.ID];
                        DataPointCollection plotPoints = currBusesPlot.Points;

                        uint numOfIncomingPassengers = entity.CurrNumOfIncomingPassengers;
                        uint numOfExcurrentPassengers = entity.CurrNumOfExcurrentPassengers;

                        uint prevBusCapacity = entity.CurrBusCapacity + numOfIncomingPassengers - numOfExcurrentPassengers;
                        uint prevTime = entity.CurrArrivalTime;
                        System.Diagnostics.Debug.Assert(prevBusCapacity < uint.MaxValue);
                        plotPoints.AddXY(prevTime, prevBusCapacity);

                        prevTime += entity.AlightingTimePerPassenger * numOfExcurrentPassengers;
                        prevBusCapacity += entity.CurrNumOfExcurrentPassengers;

                        plotPoints.AddXY(prevTime, prevBusCapacity);
                        
                        plotPoints.AddXY(entity.CurrDepartureTime, entity.CurrBusCapacity);
                        
                        currBusesPlot.ChartType = SeriesChartType.Column;                            
                    };

                    break;

                case E_BUS_PLOT_TYPE.BPT_INCOMING_PASSENGERS:

                    busPlot.Titles[0].Text = Properties.Resources.mBusesPlotIncomingPassengersTitle;

                    addDataOntoPlot = (entity) =>
                    {
                        Series currBusesPlot = busPlot.Series[entity.ID];

                        currBusesPlot.Points.AddXY(entity.CurrDepartureTime, entity.CurrNumOfIncomingPassengers);

                        currBusesPlot.ChartType = SeriesChartType.Column;
                    };

                    break;

                case E_BUS_PLOT_TYPE.BPT_EXCURRENT_PASSENGERS:

                    busPlot.Titles[0].Text = Properties.Resources.mBusesPlotExcurrentPassengersTitle;

                    addDataOntoPlot = (entity) =>
                    {
                        Series currBusesPlot = busPlot.Series[entity.ID];

                        currBusesPlot.Points.AddXY(entity.CurrDepartureTime, entity.CurrNumOfExcurrentPassengers);

                        currBusesPlot.ChartType = SeriesChartType.Column;
                    };

                    break;
            }

            Series currPlot = null;

            int busesPlotsCount = busPlot.Series.Count;

            BindingList<TBusTableEntity> buses = mComputationsResults.BusesRecords;
            List<TBusTableEntity> currBusesRecords = null;

            for (int i = 0; i < busesPlotsCount; i++)
            {
                currPlot = busPlot.Series[i];

                currPlot.Points.Clear();

                currBusesRecords = buses.Where(t => t.ID == i).ToList();

                if (busPlot.InvokeRequired)
                {
                    busPlot.Invoke((MethodInvoker)(() => currBusesRecords.ForEach(addDataOntoPlot)));
                }
                else
                {
                    currBusesRecords.ForEach(addDataOntoPlot);
                }
            }
        }

        private void _onStationPlotTypeChanged(object sender, EventArgs e)
        {
            E_STATIONS_PLOT_TYPE stationPlotType = (E_STATIONS_PLOT_TYPE)mView.StationPlotType.SelectedValue;
            
            switch (stationPlotType)
            {
                case E_STATIONS_PLOT_TYPE.SPT_PASSENGERS:
                    _drawPassengersDataPlot();
                    break;

                case E_STATIONS_PLOT_TYPE.SPT_TRAFFIC_POWER:
                    _drawTrafficPowerPlot();
                    break;
            }            
        }

        private void _drawPassengersDataPlot()
        {
            IStatisticsViewerView view = mView;

            Chart stationPlot = view.StationsPlot;

            stationPlot.Titles[0].Text = Properties.Resources.mStationsPlotPassengersCountTitle;

            Series currPlot = null;
            int stationsPlotsCount = stationPlot.Series.Count;

            BindingList<TStationTableEntity> stations = mComputationsResults.StationsRecords;
            List<TStationTableEntity> currStationRecords = null;

            Action<TStationTableEntity> addDataOntoPlot = (entity) =>
            {
                Series currStationPlot = stationPlot.Series[entity.ID];
                currStationPlot.ChartType = SeriesChartType.Column;

                currStationPlot.Points.AddXY(entity.Time, entity.CurrNumOfPassengers);
            };

            for (int i = 0; i < stationsPlotsCount; i++)
            {
                currPlot = stationPlot.Series[i];

                currPlot.Points.Clear();

                currStationRecords = stations.Where(t => t.ID == i).ToList();

                if (stationPlot.InvokeRequired)
                {
                    stationPlot.Invoke((MethodInvoker)(() => currStationRecords.ForEach(addDataOntoPlot)));
                }
                else
                {
                    currStationRecords.ForEach(addDataOntoPlot);
                }
            }
        }

        private void _drawTrafficPowerPlot()
        {
            IStatisticsViewerView view = mView;

            Chart stationPlot = view.StationsPlot;

            stationPlot.Titles[0].Text = Properties.Resources.mStationsPlotPassengersPowerTitle;

            Series currPlot = null;
            int stationsPlotsCount = stationPlot.Series.Count;

            BindingList<TBusTableEntity> buses = mComputationsResults.BusesRecords;
            BindingList<TStationTableEntity> stations = mComputationsResults.StationsRecords;
            List<TBusTableEntity> currBusRecords = null;
            
            uint totalNumOfPassengers = 0;

            int numOfSteps = mModel.OptionsList.GetIntParam(Properties.Resources.mOptionsNumOfSimulationSteps);
            CBusRoute route = mModel.CurrBusRouteObject;

            double elapsedHours = numOfSteps / 3600; //convert seconds to hours
            double currLength = 0.0;
            double passengersTrafficPower = 0.0;
            double currDistance = 0.0;

            for (int i = 0; i < stationsPlotsCount; i++)
            {
                totalNumOfPassengers = 0;
                currDistance = route.SpansDisntancesVector[i];

                currPlot = stationPlot.Series[i];
                currPlot.ChartType = SeriesChartType.Area;

                currPlot.Points.Clear();

                currBusRecords = buses.Where(entity => entity.CurrStationId == i).ToList();

                currBusRecords.ForEach(entity => 
                {
                    totalNumOfPassengers += entity.MaxCapacity - entity.CurrBusCapacity;
                });

                passengersTrafficPower = totalNumOfPassengers / elapsedHours;

                currPlot.Points.AddXY(currLength, passengersTrafficPower);
                currPlot.Points.AddXY(currLength + currDistance, passengersTrafficPower);
                
                currLength += currDistance;
            }
        }

        private void _initBusesNavigator(BindingNavigator navigator)
        {
            ToolStripItem position = navigator.PositionItem;

            int currPageIndex = Convert.ToInt32(position.Text);

            int numOfPages = mComputationsResults.BusesRecords.Count / mBusesPageSize;
            navigator.CountItem.Text = numOfPages.ToString();

            mBusesTableData.DataSource = mComputationsResults.BusesRecords.ToList().GetRange(currPageIndex * mBusesPageSize, mBusesPageSize);
        }
        
        private void _initStationsNavigator(BindingNavigator navigator)
        {
            ToolStripItem position = navigator.PositionItem;

            int currPageIndex = Convert.ToInt32(position.Text);

            int numOfPages = mComputationsResults.BusesRecords.Count / mStationsPageSize;

            mBusesTableData.DataSource = mComputationsResults.StationsRecords.ToList().GetRange(currPageIndex * mStationsPageSize, mStationsPageSize);

            navigator.CountItem.Text = numOfPages.ToString();
        }

        private BindingList<BindingList<T>> _generatePages<T>(BindingList<T> records, int pageSize) where T :struct
        {
            BindingList<BindingList<T>> pages = new BindingList<BindingList<T>>();

            int numOfPages = (int)Math.Ceiling(records.Count / (double)mBusesPageSize);

            List<T> recordsList = records.ToList();

            int firstIndex = 0;

            for (int currPage = 1; currPage <= numOfPages; currPage++)
            {
                firstIndex = (currPage - 1) * pageSize;

                pages.Add(new BindingList<T>(recordsList.GetRange(firstIndex, Math.Min(records.Count - firstIndex, pageSize))));
            }

            return pages;
        }

        private void _onBusesDataPositionChanged(object sender, EventArgs e)
        {
            mView.BusesTable.DataSource = mBusesDataPages[mBusesTableData.Position];
        }

        private void _onStationsDataPositionChanged(object sender, EventArgs e)
        {
            mView.StationsTable.DataSource = mStationsDataPages[mStationsTableData.Position];
        }

        private void _onGenerateReport(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = mView.SaveFileDialogObject;

            DialogResult result = saveFileDialog.ShowDialog();

            if (result != DialogResult.OK)
            {
                return;
            }

            string filename = saveFileDialog.FileName;

            CBaseReportFile report = null;

            if (filename.EndsWith(".xlsx"))
            {
                report = new CXLSXReportFile(filename);
            }
            else if (filename.EndsWith(".pdf"))
            {
                report = new CPDFReportFile(filename);
            }

            CBackgroundJobHelper.BackgroundModelOperation(ref mModel, "Выполняется генерация\n отчета...", () =>
            {
                report.WriteData(mModel);
                report.Close();
            });
        }
    }
}
