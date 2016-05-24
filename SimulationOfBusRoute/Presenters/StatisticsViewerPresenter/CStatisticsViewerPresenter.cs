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
using System.Threading.Tasks;

namespace SimulationOfBusRoute.Presenters.StatisticsViewerPresenter
{
    public class CStatisticsViewerPresenter : CBasePresenter<CDataManager, IStatisticsViewerView>
    {
        public enum E_BUS_PLOT_TYPE
        {
            [Description("Временные характеристики")]
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
                        
            mComputationsResults = model.ComputationsResults;
        }

        private void _onFormInit(object sender, EventArgs e)
        {
            CTimer timer = new CTimer(0, 1);

            IStatisticsViewerView view = mView;

            Chart stationsPlot = view.StationsPlot;

            CheckedListBox stationsList = view.StationsList;

            ComboBox busPlotType = view.BusPlotType;

            busPlotType.DisplayMember = "Key";
            busPlotType.ValueMember = "Value";

            busPlotType.DataSource = typeof(E_BUS_PLOT_TYPE).ToDescriptionsList();

            mView.OnBusPlotTypeChanged += _onBusPlotTypeChanged;

            ComboBox stationPlotType = view.StationPlotType;

            stationPlotType.DisplayMember = "Key";
            stationPlotType.ValueMember = "Value";

            stationPlotType.DataSource = typeof(E_STATIONS_PLOT_TYPE).ToDescriptionsList();

            mView.OnStationPlotTypeChanged += _onStationPlotTypeChanged;

            foreach (CBusStation station in mModel.CurrBusRouteObject.BusStationsList)
            {
                timer.Subscribe(station);
                //station.InitData(mModel.CurrBusRouteObject);
                station.OnGetData += _onPrintStation;

                var stationSeries = stationsPlot.Series.Add(station.BusStationId.ToString());
                stationSeries.ChartType = SeriesChartType.Line;

                stationsList.Items.Add(station.BusStationId);

                for (int i = 0; i < stationsList.Items.Count; i++)
                {
                    stationsList.SetItemChecked(i, true);
                }
            }

            Chart busesPlot = view.BusesPlot;

            CheckedListBox busesList = view.BusesList;

            foreach (CBus bus in mModel.BusesStorage.GetAll())
            {
                timer.Subscribe(bus);
                bus.OnGetData += _onPrintBus;

                var stationSeries = busesPlot.Series.Add(bus.Name + bus.ID);
                stationSeries.ChartType = SeriesChartType.Line;

                busesList.Items.Add(bus.Name + bus.ID);
                
                for (int i = 0; i < busesList.Items.Count; i++)
                {
                    busesList.SetItemChecked(i, true);
                }
            }

            int numOfSteps = mModel.OptionsList.GetIntParam(Properties.Resources.mOptionsNumOfSimulationSteps);

            ToolStripProgressBar operationProgress = View.OperationProgress;
            operationProgress.Maximum = numOfSteps;
            operationProgress.Step = 1;
            View.IsComputing = true;

            ToolStrip statusBar = operationProgress.GetCurrentParent();

            mComputationsResults.BusesRecords.Clear();
            mComputationsResults.StationsRecords.Clear();

            CBackgroundJobHelper.BackgroundModelOperation(ref mModel, "Выполняются вычисления...", () =>
            {
                while (timer.CurrTime < numOfSteps)
                {
                    timer.Tick();
                    statusBar.Invoke((MethodInvoker)(() => operationProgress.Increment(operationProgress.Step)));
                }           
            });
            
            operationProgress.Value   = 0;
            operationProgress.Visible = false;
            View.IsComputing          = false;

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

            //view.BusesDataNavigator.BindingSource = mBusesTableData;
            //view.BusesTable.DataSource = mBusesTableData.DataSource;
            //_initBusesNavigator(view.BusesDataNavigator);

            //view.StationsDataNavigator.BindingSource = mStationsTableData;
            //view.StationsTable.DataSource = mStationsTableData.DataSource;
            //_initStationsNavigator(view.StationsDataNavigator);

            //mBusesTableData = new BindingSource();
            //mBusesTableData.DataSource = mComputationsResults.BusesRecords;
            //view.BusesTable.DataSource = mBusesTableData;

            //mStationsTableData = new BindingSource();
            //mStationsTableData.DataSource = mComputationsResults.StationsRecords;
            //view.StationsTable.DataSource = mStationsTableData;

            busesPlot.Invalidate();
            stationsPlot.Invalidate();

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

            if (busesPlot.InvokeRequired)
            {
                busesPlot.Invoke((MethodInvoker)(() =>
                {
                    busesPlot.Series.FindByName(bus.Name + bus.ID).Points.AddXY(bus.CurrStation.BusStationId, bus.CurrArrivalTime);
                    busesPlot.Series.FindByName(bus.Name + bus.ID).Points.AddXY(bus.CurrStation.BusStationId, bus.CurrDepartureTime);

                    mComputationsResults.BusesRecords.Add(bus.ToTableEntity());
                }));
            }
            else
            {

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
                    stationsPlot.Series.FindByName(station.BusStationId.ToString()).Points.AddXY(station.ReactionTime, station.CurrNumOfPassengers);

                    mComputationsResults.StationsRecords.Add(station.ToTableEntity());
                }));
            }                
            else
            {
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

                    addDataOntoPlot = (entity) =>
                    {
                        Series currBusesPlot = busPlot.Series[entity.ID];

                        currBusesPlot.Points.AddXY(entity.CurrStationId, entity.CurrArrivalTime);
                        currBusesPlot.Points.AddXY(entity.CurrStationId, entity.CurrDepartureTime);

                        currBusesPlot.ChartType = SeriesChartType.Line;
                    };

                    break;

                case E_BUS_PLOT_TYPE.BPT_WAITING_TIME:

                    addDataOntoPlot = (entity) =>
                    {
                        Series currBusesPlot = busPlot.Series[entity.ID];
                        
                        currBusesPlot.Points.AddXY(entity.CurrDepartureTime, entity.CurrDepartureTime - entity.CurrArrivalTime);

                        currBusesPlot.ChartType = SeriesChartType.Column;
                    };

                    break;

                case E_BUS_PLOT_TYPE.BPT_CAPACITY:

                    addDataOntoPlot = (entity) =>
                    {
                        Series currBusesPlot = busPlot.Series[entity.ID];

                        currBusesPlot.Points.AddXY(entity.CurrDepartureTime, entity.CurrBusCapacity);

                        currBusesPlot.ChartType = SeriesChartType.StepLine;
                    };

                    break;

                case E_BUS_PLOT_TYPE.BPT_INCOMING_PASSENGERS:

                    addDataOntoPlot = (entity) =>
                    {
                        Series currBusesPlot = busPlot.Series[entity.ID];

                        currBusesPlot.Points.AddXY(entity.CurrDepartureTime, entity.CurrNumOfIncomingPassengers);

                        currBusesPlot.ChartType = SeriesChartType.Column;
                    };

                    break;

                case E_BUS_PLOT_TYPE.BPT_EXCURRENT_PASSENGERS:

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

            Series currPlot = null;
            int stationsPlotsCount = stationPlot.Series.Count;

            BindingList<TStationTableEntity> stations = mComputationsResults.StationsRecords;
            List<TStationTableEntity> currStationRecords = null;

            Action<TStationTableEntity> addDataOntoPlot = (entity) =>
            {
                Series currStationPlot = stationPlot.Series[entity.ID];
                currStationPlot.ChartType = SeriesChartType.Line;

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

        private void _onBusesNagivatorLastPage(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void _onBusesNavigatorFirstPage(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void _onBusesNavigatorNextPage(object sender, EventArgs e)
        {
            IStatisticsViewerView view = mView;

            BindingNavigator navigator = view.BusesDataNavigator;

            ToolStripItem position = navigator.PositionItem;

            int currPageIndex = Convert.ToInt32(position.Text) + 1;

            position.Text = currPageIndex.ToString();

            mBusesTableData.Position = currPageIndex;
        }

        private void _onBusesNagivatorPrevPage(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void _onBusesNagivatorRefresh(object sender, EventArgs e)
        {
            IStatisticsViewerView view = mView;

            BindingNavigator navigator = view.BusesDataNavigator;
            
            int numOfPages = mComputationsResults.BusesRecords.Count / mBusesPageSize;

            navigator.CountItem.Text = numOfPages.ToString();
        }

        private void _initStationsNavigator(BindingNavigator navigator)
        {
            ToolStripItem position = navigator.PositionItem;

            int currPageIndex = Convert.ToInt32(position.Text);

            int numOfPages = mComputationsResults.BusesRecords.Count / mStationsPageSize;

            mBusesTableData.DataSource = mComputationsResults.StationsRecords.ToList().GetRange(currPageIndex * mStationsPageSize, mStationsPageSize);

            navigator.CountItem.Text = numOfPages.ToString();
        }

        private void _onStationsNagivatorLastPage(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void _onStationsNavigatorFirstPage(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void _onStationsNavigatorNextPage(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void _onStationsNagivatorPrevPage(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void _onStationsNagivatorRefresh(object sender, EventArgs e)
        {
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
    }
}
