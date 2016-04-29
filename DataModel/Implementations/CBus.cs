using DataModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SQLite;


namespace DataModel.Implementations
{
    public class CBus : CBaseModel, IUpdatable
    {
        public enum E_BUS_STATE
        {
            BS_ARRIVED_AT_STATION,
            BS_ALIGHTING,
            BS_BOARDING,
            BS_WAITING,
            BS_ON_WAY,
            BS_DEFAULT
        }

        public event Action<CBus> OnGetData;

        private double mReactionTime;

        private CBusStation mCurrBusStation;

        private ushort mCurrCapacity;

        private ushort mNumOfIncomingPassengers;

        private ushort mNumOfExcurrentPassengers;

        private ushort mMaxNumOfPassengers;

        private ushort[] mPassengersDistributionByGroups;

        private uint[] mTotalNumOfTransportedPassengers;

        private double mStartTime;

        private double mCurrArrivalTime;

        private double mCurrDepartureTime;

        private double mAlightingTimePerPassenger;

        private double mBoardingTimePerPassenger;

        private E_BUS_STATE mState;

        #region Contructors

        //конструктор, используемый для загрузки данных об автобусе из БД

        public CBus(uint id):
            base(id, string.Format("bus{0}", id))
        {
            mCurrCapacity = 0;

            mNumOfIncomingPassengers = 0;

            mNumOfExcurrentPassengers = 0;

            mMaxNumOfPassengers = 0;

            mStartTime = 0.0;

            mCurrArrivalTime = 0.0;

            mCurrDepartureTime = 0.0;
        }

        //конструктор используется при создании нового автобуса

        public CBus(uint id, ushort maxNumOfPassengers, double startTime, double alightingTimePerPassenger, double boardingTimePerPassenger,
                    CBusStation initialStation, int numOfStations):
            base(id, string.Format("bus{0}", id))
        {
            mCurrCapacity = 0;

            mNumOfIncomingPassengers = 0;

            mNumOfExcurrentPassengers = 0;

            mMaxNumOfPassengers = maxNumOfPassengers;

            mStartTime = startTime;

            mAlightingTimePerPassenger = alightingTimePerPassenger;

            mBoardingTimePerPassenger = boardingTimePerPassenger;

            mCurrArrivalTime = 0.0;

            mCurrDepartureTime = 0.0;

            mCurrBusStation = initialStation;

            mPassengersDistributionByGroups = new ushort[numOfStations];
            mTotalNumOfTransportedPassengers = new uint[numOfStations];
        }

        #endregion

        #region Methods

        public override void LoadFromFile(string filename)
        {
            throw new NotImplementedException();
        }

        public override void SaveIntoFile(string filename)
        {
            //using (SQLiteCommand currCommand = new SQLiteCommand(dbConnection))
            //{
            //    //добавление данных в таблицу buses
            //    currCommand.CommandText = Properties.Resources.mSQLQueryInsertBus;

            //    currCommand.Parameters.AddWithValue("@id", mIndex);
            //    currCommand.Parameters.AddWithValue("@name", mName);
            //    currCommand.Parameters.AddWithValue("@maxNumOfPassengers", mMaxNumOfPassengers);
            //    currCommand.Parameters.AddWithValue("@startTime", mStartTime);
            //    currCommand.Parameters.AddWithValue("@alightingTimePerPassenger", mAlightingTimePerPassenger);
            //    currCommand.Parameters.AddWithValue("@boardingTimePerPassenger", mBoardingTimePerPassenger);

            //    currCommand.ExecuteNonQuery();
            //}
        }

        public void Update(double time, double dt)
        {
            throw new NotImplementedException();
        }

        public override void Verify()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Properties

        public CBusStation CurrStation
        {
            get
            {
                return mCurrBusStation;
            }
        }

        public ushort MaxNumOfPassengers
        {
            get
            {
                return mMaxNumOfPassengers;
            }

            set
            {
                mMaxNumOfPassengers = value;
            }
        }

        public ushort CurrCapacity
        {
            get
            {
                return mCurrCapacity;
            }

            set
            {
                mCurrCapacity = value;
            }
        }

        public double StartTime
        {
            get
            {
                return mStartTime;
            }

            set
            {
                mStartTime = value;
            }
        }

        public double AlightingTimePerPassenger
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

        public double BoardingTimePerPassenger
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

        public double ReactionTime
        {
            get
            {
                return mReactionTime;
            }

            set
            {
                mReactionTime = value;
            }
        }

        public E_BUS_STATE State
        {
            get
            {
                return mState;
            }
        }

        #endregion
    }

    public class CSqLiteBusDataMapper : CSqLiteDataMapper<CBus>
    {
        public CSqLiteBusDataMapper(string connectionString):
            base(connectionString)
        {
        }

        public override CBus Load(uint id)
        {
            throw new NotImplementedException();
        }

        public override List<CBus> LoadAll()
        {
            throw new NotImplementedException();
        }

        public override void Save(CBus entity)
        {
            throw new NotImplementedException();
        }

        public override void SaveAll(List<CBus> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException();
            }

            foreach (CBus bus in entities)
            {
                Save(bus);
            }
        }
    }
}
