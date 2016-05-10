using SimulationOfBusRoute.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace SimulationOfBusRoute.Models.Implementations.Bus
{
    public class CBus : CBaseModel, IUpdatable
    {
        public event Action<CBus> OnGetData;

        private uint mMaxBusCapacity;

        private uint mCurrBusCapacity;

        private byte mAlightingTimePerPassenger;

        private byte mBoardingTimePerPassenger;

        private uint mReactionTime;

        private uint mTimeOfStart;

        private uint mCurrArrivalTime;

        private uint mCurrDepartureTime;

        private uint mCurrNumOfIncomingPassengers;

        private uint mCurrNumOfExcurrentPassengers;

        private uint[] mPassengersDistributionByGroups;

        private uint[] mTotalNumOfTransportedPassengers;

        private CBusStation mCurrStation;

        private CBusState mCurrState;

        private CBusOnWayState mOnWayState;

        private CBusArrivedState mArrivedState;

        private CBusAlightingState mAlightingState;

        private CBusBoardingState mBoardingState;

        private CBusWaitingState mWaitingState;

        private CBusDeparturingState mDeparturingState;

        public CBus(int id):
            base(id, "bus")
        {
        }

        public CBus(int id, string name, uint maxBusCapatity, byte alightingTimePerPassenger, byte boardingTimePerPassenger, uint timeOfStart):
            base(id, name)
        {
            mMaxBusCapacity = maxBusCapatity;

            mCurrBusCapacity = 0;

            mAlightingTimePerPassenger = alightingTimePerPassenger;

            mBoardingTimePerPassenger = boardingTimePerPassenger;

            mReactionTime = timeOfStart;

            mTimeOfStart = timeOfStart;

            mCurrArrivalTime = 0;

            mCurrDepartureTime = 0;

            mPassengersDistributionByGroups = null;

            mTotalNumOfTransportedPassengers = null;

            mCurrNumOfExcurrentPassengers = 0;

            mCurrNumOfIncomingPassengers = 0;

            mOnWayState = new CBusOnWayState(this);

            mArrivedState = new CBusArrivedState(this);

            mAlightingState = new CBusAlightingState(this);

            mBoardingState = new CBusBoardingState(this);

            mWaitingState = new CBusWaitingState(this);

            mDeparturingState = new CBusDeparturingState(this);

            mCurrState = mOnWayState;
    }

        #region Methods
        
        public void Update(uint time, uint dt)
        {
            mCurrState.Update(time, dt);
        }

        public void SetState(CBusState state)
        {
            if (state == null)
            {
                throw new ArgumentNullException("state", "A null state is impossible");
            }

            mCurrState = state;
        }

        public void InitData(CBusRoute route)
        {
            List<CBusStation> stations = route.BusStationsList;
            int numOfStations = route.NumOfStations;

            mCurrStation = stations[0];
            
            mCurrState = mOnWayState;

            mPassengersDistributionByGroups = new uint[numOfStations];
            mTotalNumOfTransportedPassengers = new uint[numOfStations];

            mCurrBusCapacity = mMaxBusCapacity;
        }

        public void UnlockBus(uint time)
        {
            mCurrState.UnlockBus(time);
        }

        public void Notify()
        {
            if (OnGetData != null)
            {
                OnGetData(this);
            }
        }

        #endregion

        public uint ReactionTime
        {
            get
            {
                return mReactionTime;
            }

            set
            {
                System.Diagnostics.Debug.Assert(mReactionTime <= value);
                mReactionTime = value;
            }
        }

        public uint MaxBusCapacity
        {
            get
            {
                return mMaxBusCapacity;
            }

            set
            {
                mMaxBusCapacity = value;
            }
        }

        public uint CurrBusCapacity
        {
            get
            {
                return mCurrBusCapacity;
            }

            set
            {
                mCurrBusCapacity = value;
            }
        }

        public byte AlightingTimePerPassenger
        {
            get
            {
                return mAlightingTimePerPassenger;
            }

            set
            {
                mAlightingTimePerPassenger = value;
            }
        }

        public byte BoardingTimePerPassenger
        {
            get
            {
                return mBoardingTimePerPassenger;
            }

            set
            {
                mBoardingTimePerPassenger = value;
            }
        }

        public uint TimeOfStart
        {
            get
            {
                return mTimeOfStart;
            }

            set
            {
                mReactionTime = value;
                mTimeOfStart  = value;
            }
        }

        public CBusStation CurrStation
        {
            get
            {
                return mCurrStation;
            }

            set
            {
                mCurrStation = value;
            }
        }

        public uint CurrArrivalTime
        {
            get
            {
                return mCurrArrivalTime;
            }

            set
            {
                mCurrArrivalTime = value;
            }
        }

        public uint CurrDepartureTime
        {
            get
            {
                return mCurrDepartureTime;
            }

            set
            {
                mCurrDepartureTime = value;
            }
        }

        public uint CurrNumOfIncomingPassengers
        {
            get
            {
                return mCurrNumOfIncomingPassengers;
            }

            set
            {
                mCurrNumOfIncomingPassengers = value;
            }
        }

        public uint CurrNumOfExcurrentPassengers
        {
            get
            {
                return mCurrNumOfExcurrentPassengers;
            }

            set
            {
                mCurrNumOfExcurrentPassengers = value;
            }
        }

        public uint[] PassengersDistribution
        {
            get
            {
                return mPassengersDistributionByGroups;
            }

            set
            {
                mPassengersDistributionByGroups = value;
            }
        }

        public uint[] TotalNumOfTransportedPassengers
        {
            get
            {
                return mTotalNumOfTransportedPassengers;
            }

            set
            {
                mTotalNumOfTransportedPassengers = value;
            }
        }

        public CBusOnWayState OnWayState
        {
            get
            {
                return mOnWayState;
            }
        }

        public CBusArrivedState ArrivedState
        {
            get
            {
                return mArrivedState;
            }
        }

        public CBusAlightingState AlightingState
        {
            get
            {
                return mAlightingState;
            }
        }

        public CBusBoardingState BoardingState
        {
            get
            {
                return mBoardingState;
            }
        }

        public CBusWaitingState WaitingState
        {
            get
            {
                return mWaitingState;
            }
        }

        public CBusDeparturingState DeparturingState
        {
            get
            {
                return mDeparturingState;
            }
        }
    }
}
