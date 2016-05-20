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
        
        private CComputationsResults mComputationsResults;

        private BindingSource mBusesTableData;

        private BindingSource mStationsTableData;

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
            
            operationProgress.Value = 0;
            operationProgress.Visible = false;
            View.IsComputing = false;

            mBusesTableData = new BindingSource();
            mBusesTableData.DataSource = mComputationsResults.BusesRecords;
            view.BusesTable.DataSource = mBusesTableData;

            mStationsTableData = new BindingSource();
            mStationsTableData.DataSource = mComputationsResults.StationsRecords;
            view.StationsTable.DataSource = mStationsTableData;

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

                        currBusesPlot.Points.AddXY(entity.CurrArrivalTime, entity.CurrBusCapacity);

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
    }
}
