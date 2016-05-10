using SimulationOfBusRoute.Models.Implementations;
using SimulationOfBusRoute.Models.Implementations.Bus;
using SimulationOfBusRoute.Views;
using System;
using System.Windows.Forms;


namespace SimulationOfBusRoute.Presenters.StatisticsViewerPresenter
{
    public class CStatisticsViewerPresenter : CBasePresenter<CDataManager, IStatisticsViewerView>
    {
        public CStatisticsViewerPresenter(CDataManager model, IStatisticsViewerView view):
            base(model, view)
        {
            mView.OnFormInit += _onFormInit;
            mView.OnQuit += _onQuit;

            mView.OnCloseForm += _onCloseForm;
        }

        private void _onFormInit(object sender, EventArgs e)
        {
            CTimer timer = new CTimer(0, 1);
            
            foreach (CBusStation station in mModel.CurrBusRouteObject.BusStationsList)
            {
                timer.Subscribe(station);
                station.InitData(mModel.CurrBusRouteObject);
                station.OnGetData += _onPrintStation;
            }

            var series = View.TimeChart.Series.Add("bus0");
            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;

            foreach (CBus bus in mModel.BusesStorage.GetAll())
            {
                timer.Subscribe(bus);
                bus.OnGetData += _onPrintBus;
            }

            int numOfSteps = mModel.OptionsList.GetIntParam(Properties.Resources.mOptionsNumOfSimulationSteps);

            while (timer.CurrTime < numOfSteps)
            {
                timer.Tick();
            }

            View.TimeChart.Invalidate();
            mBusTableOutput.Close();
        }

        private static System.IO.StreamWriter mBusTableOutput = new System.IO.StreamWriter("bus.csv");
        private void _onPrintBus(CBus bus)
        {
            //View.TimeChart.Series.FindByName("bus0").Points.AddXY(bus.CurrStation.BusStationId, bus.CurrArrivalTime);
            //View.TimeChart.Series.FindByName("bus0").Points.AddXY(bus.CurrStation.BusStationId, bus.CurrDepartureTime);
            mBusTableOutput.Write("{0};", bus.ID);
            mBusTableOutput.Write("{0};", bus.CurrStation.BusStationId);
            mBusTableOutput.Write("{0:F2};", bus.CurrArrivalTime);
            mBusTableOutput.Write("{0:F2};", bus.CurrDepartureTime);
            mBusTableOutput.Write("{0};", bus.CurrBusCapacity);
            mBusTableOutput.Write("{0};", bus.CurrNumOfIncomingPassengers);
            mBusTableOutput.Write("{0};", bus.CurrNumOfExcurrentPassengers);
            mBusTableOutput.WriteLine();
        }

        private void _onPrintStation(CBusStation station)
        {
            if (station.BusStationId != 0)
                return;

            View.TimeChart.Series.FindByName("bus0").Points.AddXY(station.ReactionTime, station.CurrNumOfPassengers);
        }

        private void _onQuit(object sender, FormClosingEventArgs e)
        {
            mIsRunning = false;
        }

        private void _onCloseForm(object sender, EventArgs e)
        {
            mView.Quit();
        }
    }
}
