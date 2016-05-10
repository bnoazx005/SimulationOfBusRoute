using GMap.NET.ObjectModel;
using GMap.NET.WindowsForms;
using MDLParser.Data;
using SimulationOfBusRoute.Models.Implementations.Bus;
using System;
using System.Collections.Generic;
using System.Linq;


namespace SimulationOfBusRoute.Models.Implementations
{
    public class CBusRoute : CBaseModel
    {
        private static CDataManager mDataManager;

        private CMatricesList mPassengersIntensities;

        private CMatricesList mVelocitiesOfSpans;

        private List<CBusStation> mBusStations;

        private double[] mSpansDistancesVector;

        private int mNumOfStations;
        
        public CBusRoute(CDataManager model) :
            base(0, "DefaultBusRoute")
        {
            mDataManager = model;
        }

        #region Methods

        public override void Verify()
        {
            if (mBusStations == null || mBusStations.Count == 0)
            {
                throw new ArgumentNullException("mBusStations", "There is no any station at route");
            }

            if (mPassengersIntensities == null)
            {
                throw new CNotCompiledDataException("mPassengersIntensities is not compiled");
            }

            if (mVelocitiesOfSpans == null)
            {
                throw new CNotCompiledDataException("mVelocitiesOfSpans is not compiled");
            }

            if (mBusStations[0].NodeType != CRouteNode.E_ROUTE_NODE_TYPE.RNT_INITIAL_BUS_STATION)
            {
                throw new CInvalidStartRouteNodeException("A bus route should begin with an initial station");
            }

            if (mBusStations.Last().NodeType != CRouteNode.E_ROUTE_NODE_TYPE.RNT_FINAL_BUS_STATION)
            {
                throw new CInvalidEndRouteNodeException("A bus route should end with a final station");
            }

            int numOfBusStations = mNumOfStations;

            for (int i = 1; i < numOfBusStations - 1; i++)
            {
                if (mBusStations[i].NodeType != CRouteNode.E_ROUTE_NODE_TYPE.RNT_BUS_STATION)
                {
                    throw new CInvalidRouteConfigurationException("There is incorrect node between start and finish at " + i.ToString());
                }
            }

            //check up a number of buses
            if (mDataManager.BusesStorage.NumOfBuses <= 0)
            {
                throw new CIncorrectNumOfBusesException("A number of buses equals to " + mDataManager.BusesStorage.NumOfBuses.ToString());
            }

            //if all tests are passed we can start to build the route
        }

        public void Build(ObservableCollectionThreadSafe<GMapRoute> routesList)
        {
            mBusStations = mDataManager.RouteNodesStorage.GetAllBySpecification(new CIsBusStationSpecification()).Cast<CBusStation>().ToList();
            mNumOfStations = mBusStations.Count;

            Verify();

            //compute distances of the spans
            List<CBusStation> busStations = mBusStations;

            mSpansDistancesVector = new double[mNumOfStations];

            double currDistanceValue = 0.0;
            
            int numOfStations = mNumOfStations;

            double meterCoeff = 1000.0;

            int firstId = 0;
            int secondId = 0;
            
            for (int i = 0; i < numOfStations - 1; i++)
            {
                currDistanceValue = 0.0;

                firstId = busStations[i].ID;
                secondId = busStations[i + 1].ID;

                for (int k = firstId; k < secondId; k++)
                {
                    currDistanceValue += routesList[k].Distance;
                }

                mSpansDistancesVector[i] = currDistanceValue * meterCoeff; //convert km to m
            }

            firstId = busStations.Last().ID;
            secondId = busStations[0].ID;

            int routesCount = routesList.Count;

            currDistanceValue = 0.0;

            for (int k = firstId; k != secondId; k = (k + 1) % routesCount)
            {
                currDistanceValue += routesList[k].Distance;
            }

            mSpansDistancesVector[numOfStations - 1] = currDistanceValue * meterCoeff;

            //building the bus route
            CBusStation.CurrBusRouteObject = this;

            for (int i = 0; i < numOfStations; i++)
            {
                mBusStations[i].NextStation = mBusStations[(i + 1) % numOfStations];
                mBusStations[i].BusStationId = i;
            }

            List<CBus> buses = mDataManager.BusesStorage.GetAll();

            foreach (CBus bus in buses)
            {
                bus.InitData(this);
            }
        }

        #endregion

        public List<CBusStation> BusStationsList
        {
            get
            {
                return mBusStations;
            }
        }
        
        public CMatricesList PassengersIntensities
        {
            get
            {
                return mPassengersIntensities;
            }

            set
            {
                mPassengersIntensities = value;
            }
        }

        public CMatricesList VelocitiesOfSpans
        {
            get
            {
                return mVelocitiesOfSpans;
            }

            set
            {
                mVelocitiesOfSpans = value;
            }
        }

        public double[] SpansDisntancesVector
        {
            get
            {
                return mSpansDistancesVector;
            }
        }

        public int NumOfStations
        {
            get
            {
                return mNumOfStations;
            }
        }
    }
}
