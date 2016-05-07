using SimulationOfBusRoute.Models.Interfaces;


namespace SimulationOfBusRoute.Models.Implementations
{
    public class CBus : CBaseModel, IUpdatable
    {
        private uint mMaxBusCapacity;

        private uint mCurrBusCapacity;

        private byte mAlightingTimePerPassenger;

        private byte mBoardingTimePerPassenger;

        private uint mReactionTime;

        private uint mTimeOfStart;

        private uint mCurrArrivalTime;

        private uint mCurrDepartureTime;

        private uint[] mPassengersDistributionByGroups;

        private uint[] mTotalNumOfTransportedPassengers;

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
        }

        #region Methods

        public override void Verify()
        {
        }

        public void Update(uint time, uint dt)
        {
        }

        #endregion

        public uint ReactionTime
        {
            get
            {
                return mReactionTime;
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
    }
}
