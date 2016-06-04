using GMap.NET;
using SimulationOfBusRoute.Models.Implementations.Bus;
using SimulationOfBusRoute.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;


namespace SimulationOfBusRoute.Models.Implementations
{
    public struct TStationTableEntity
    {
        [DisplayName("Тек. время")]
        public uint Time { get; set; }

        [DisplayName("№ остановки")]
        public int ID { get; set; }

        [DisplayName("Кол-во пассажиров")]
        public uint CurrNumOfPassengers { get; set; }

        [DisplayName("Распределение пассажиров")]
        public double[] PassengersDistributionByGroups { get; set; }
    }

    public class CBusStation : CRouteNode, IUpdatable
    {
        public event Action<CBusStation> OnGetData;

        public enum E_BUS_STATION_TYPE
        {
            BST_INITIAL,
            BST_FINAL,
            BST_DEFAULT
        }
        
        private uint mReactionTime;

        private E_ROUTE_NODE_TYPE mNodeType;

        private CBusStation mNextStation;

        private uint mCurrNumOfPassengers;

        private double[] mPassengersDistributionByGroups;

        private double[] mIntensityVector;

        private uint mNextSpanTravelTime;

        private static Random mRandomGenerator;

        private Queue<CBus> mBusQueue;

        private static CBusRoute mCurrBusRouteObject;

        private int mBusStationId;

        public CBusStation(E_BUS_STATION_TYPE type, int id, string name, PointLatLng position):
            base(id, name, position)
        {
            switch (type)
            {
                case E_BUS_STATION_TYPE.BST_INITIAL:
                    mNodeType = E_ROUTE_NODE_TYPE.RNT_INITIAL_BUS_STATION;
                    break;
                case E_BUS_STATION_TYPE.BST_FINAL:
                    mNodeType = E_ROUTE_NODE_TYPE.RNT_FINAL_BUS_STATION;
                    break;
                default:
                    mNodeType = E_ROUTE_NODE_TYPE.RNT_BUS_STATION;
                    break;
            }

            mReactionTime = 60;

            mNextStation = null;

            mCurrNumOfPassengers = 0;

            mPassengersDistributionByGroups = null;

            mIntensityVector = null;

            mBusStationId = -1;

            mRandomGenerator = new Random();

            mBusQueue = new Queue<CBus>();
        }

        #region Methods

        private static NLog.Logger mLogger = NLog.LogManager.GetCurrentClassLogger();
        
        public void AttachBus(CBus bus)
        {
            if (mBusQueue.Contains(bus))
            {
                mLogger.Debug("bus {0} tries to attach again", bus.ID);

                return;
            }

            mBusQueue.Enqueue(bus);
        }

        public void DettachBus()
        {
            if (mBusQueue.Count >= 1)
            {
                CBus departuringBus = mBusQueue.Peek();

                mBusQueue.Dequeue();
                
                if (mBusQueue.Count >= 1)
                {
                    CBus bus = mBusQueue.Peek();
                    bus.UnlockBus(departuringBus.CurrDepartureTime);
                }
            }
        }

        public void InitData(CBusRoute route)
        {
            int id = mBusStationId;
            int numOfStations = route.NumOfStations;

            mPassengersDistributionByGroups = new double[numOfStations];
            mCurrNumOfPassengers = 0;

            CBusRoute busRouteObject = mCurrBusRouteObject;

            mReactionTime = 60;

            mNextSpanTravelTime = (uint)Math.Ceiling(busRouteObject.SpansDisntancesVector[id] /
                                                     busRouteObject.VelocitiesOfSpans.GetData(mReactionTime)[0][id]);

            mBusQueue.Clear();
        }
             
        public void Update(uint time, uint dt)
        {
            if (mPassengersDistributionByGroups == null)
            {
                return;
            }

            //Updating the station's data
            CBusRoute busRouteObject = mCurrBusRouteObject;
            int id = mBusStationId;

            mIntensityVector = mCurrBusRouteObject.PassengersIntensities.GetData(mReactionTime)[id];

            mNextSpanTravelTime = (uint)Math.Ceiling(busRouteObject.SpansDisntancesVector[id] / 
                                                     busRouteObject.VelocitiesOfSpans.GetData(mReactionTime)[0][id]);

            int numOfStations = mPassengersDistributionByGroups.Length;

            mCurrNumOfPassengers = 0;

            for (int k = 0; k < numOfStations; k++)
            {
                mPassengersDistributionByGroups[k] += mIntensityVector[k];
                mCurrNumOfPassengers += (uint)mPassengersDistributionByGroups[k];
            }

            if (OnGetData != null)
            {
                OnGetData(this);
            }

            mReactionTime += 60;
        }

        public uint[] GetPassengers(uint busCapacity)
        {
            int passengersGroupsCount = mPassengersDistributionByGroups.Length;
            int groupSample;

            uint[] mIncomingPassengersDistribution = new uint[passengersGroupsCount];

            if (mCurrNumOfPassengers == 0)
            {
                return mIncomingPassengersDistribution;
            }

            while (busCapacity > 0 && mCurrNumOfPassengers > 0)
            {
                do
                {
                    groupSample = mRandomGenerator.Next(0, passengersGroupsCount);
                }
                while (mPassengersDistributionByGroups[groupSample] < 1.0);

                mPassengersDistributionByGroups[groupSample] -= 1.0;
                mIncomingPassengersDistribution[groupSample] += 1;

                busCapacity--;
                mCurrNumOfPassengers--;
            }

            return mIncomingPassengersDistribution;
        }

        public int GetPassenger()
        {
            int passengersGroupsCount = mPassengersDistributionByGroups.Length;
            int groupSample;
            
            if (mCurrNumOfPassengers == 0)
            {
                return -1;
            }

            //#region DebugTest

            //groupSample = 0;
            //while (mPassengersDistributionByGroups[groupSample] < 1.0)
            //{
            //    groupSample++;
            //}

            //#endregion

            do
            {
                groupSample = mRandomGenerator.Next(0, passengersGroupsCount);
            }
            while (mPassengersDistributionByGroups[groupSample] < 1.0);

            mPassengersDistributionByGroups[groupSample] -= 1.0;
            mCurrNumOfPassengers--;

            return groupSample;
        }

        public TStationTableEntity ToTableEntity()
        {
            TStationTableEntity currMappedEntity = new TStationTableEntity();

            currMappedEntity.Time = mReactionTime;
            currMappedEntity.ID = BusStationId;
            currMappedEntity.CurrNumOfPassengers = mCurrNumOfPassengers;
            currMappedEntity.PassengersDistributionByGroups = mPassengersDistributionByGroups;

            return currMappedEntity;
        }

        #endregion

        /// <summary>
        /// Property returns a type of a bus station. There are three possible values, which are described in E_ROUTE_NODE_TYPE enumeration.
        /// </summary>

        public override E_ROUTE_NODE_TYPE NodeType
        {
            get
            {
                return mNodeType;
            }
        }

        /// <summary>
        /// Property returns a reaction time of the object.
        /// </summary>

        public uint ReactionTime
        {
            get
            {
                return mReactionTime;
            }
        }
        
        public CBusStation NextStation
        {
            get
            {
                return mNextStation;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("mNextStation", "Reference to next station cannot equal to null");
                }

                mNextStation = value;
            }
        }

        //public double[] PassengersDistributionByGroups
        //{
        //    get
        //    {
        //        return mPassengersDistributionByGroups;
        //    }            
        //}

        public uint CurrNumOfPassengers
        {
            get
            {
                return mCurrNumOfPassengers;
            }
        }

        public double NextSpanTravelTime
        {
            get
            {
                return mNextSpanTravelTime;
            }
        }

        public bool IsFree
        {
            get
            {
                return (mBusQueue.Count == 0);
            }
        }

        public int BusStationId
        {
            get
            {
                return mBusStationId;
            }

            set
            {
                mBusStationId = value;
            }
        }

        public static CBusRoute CurrBusRouteObject
        {
            get
            {
                return mCurrBusRouteObject;
            }

            set
            {
                mCurrBusRouteObject = value;
            }
        }

        public double[] PassengersDistributionByGroups
        {
            get
            {
                return mPassengersDistributionByGroups;
            }
        }
    }
}
