using GMap.NET;
using SimulationOfBusRoute.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace SimulationOfBusRoute.Models.Implementations
{
    public class CBusStation : CRouteNode, IUpdatable
    {
        public Action<CBusStation> OnGetData;

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

        private double mNextSpanTravelTime;

        private static Random mRandomObject;

        private Queue<CBus> mBusQueue;

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

            mRandomObject = new Random();

            mBusQueue = new Queue<CBus>();
        }

        #region Methods

        public void AttachBus(CBus bus)
        {
            if (mBusQueue.Contains(bus))
            {
                return;
            }

            mBusQueue.Enqueue(bus);
        }

        public void DettachBus()
        {
            if (mBusQueue.Count >= 1)
            {
                mBusQueue.Dequeue();

                if (mBusQueue.Count >= 1)
                {
                    CBus bus = mBusQueue.Peek();
                    //bus.UnlockBus();
                }
            }
        }

        //public void ReceiveData(CBusRoute route)
        //{

        //}

        public override void Verify()
        {
        }

        public void Update(uint time, uint dt)
        {
            if (mPassengersDistributionByGroups == null)
            {
                return;
            }

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

        public double NextSpanDuration
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
    }
}
