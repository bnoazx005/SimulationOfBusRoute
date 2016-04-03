using System.Data.SQLite;
using SimulationOfBusRoute.Utils;


namespace SimulationOfBusRoute.Models
{
    public class CBus : IBaseModel
    {
        private uint mIndex;

        private string mName;

        private double mVelocity;

        private TPoint2 mPosition;

        private uint mCurrStationIndex;

        private ushort mCurrNumOfPassengers;

        private ushort mNumOfIncomingPassengers;

        private ushort mNumOfExcurrentPassengers;

        private ushort mMaxNumOfPassengers;

        private uint mStartTime;

        private uint mAlightingTimePerPassenger;

        private uint mBoardingTimePerPassenger;

        #region Contructors

        //конструктор, используемый для загрузки данных об автобусе из БД

        public CBus(uint id)
        {
            mIndex = id;

            mName = "Bus" + mIndex.ToString();

            mPosition = TPoint2.mNullPoint;

            mCurrStationIndex = 0;

            mCurrNumOfPassengers = 0;

            mNumOfIncomingPassengers = 0;

            mNumOfExcurrentPassengers = 0;

            mMaxNumOfPassengers = 0;

            mStartTime = 0;
        }

        //конструктор используется при создании нового автобуса

        public CBus(uint id, ushort maxNumOfPassengers, uint startTime, uint alightingTimePerPassenger, uint boardingTimePerPassenger)
        {
            mIndex = id;

            mName = "Bus" + mIndex.ToString();

            mPosition = TPoint2.mNullPoint;

            mCurrStationIndex = 0;

            mCurrNumOfPassengers = 0;

            mNumOfIncomingPassengers = 0;

            mNumOfExcurrentPassengers = 0;

            mMaxNumOfPassengers = maxNumOfPassengers;

            mStartTime = startTime;

            mAlightingTimePerPassenger = alightingTimePerPassenger;

            mBoardingTimePerPassenger = boardingTimePerPassenger;
        }

        #endregion

        #region Methods

        public void LoadFromDataBase(SQLiteConnection dbConnection)
        {
            throw new System.NotImplementedException();
        }

        public void SaveIntoDataBase(SQLiteConnection dbConnection)
        {
            using (SQLiteCommand currCommand = new SQLiteCommand(dbConnection))
            {
                //добавление данных в таблицу buses
                currCommand.CommandText = Properties.Resources.mSQLQueryInsertBus;

                currCommand.Parameters.AddWithValue("@id", mIndex);
                currCommand.Parameters.AddWithValue("@name", mName);
                currCommand.Parameters.AddWithValue("@maxNumOfPassengers", mMaxNumOfPassengers);
                currCommand.Parameters.AddWithValue("@startTime", mStartTime);
                currCommand.Parameters.AddWithValue("@alightingTimePerPassenger", mAlightingTimePerPassenger);
                currCommand.Parameters.AddWithValue("@boardingTimePerPassenger", mBoardingTimePerPassenger);

                currCommand.ExecuteNonQuery();
            }
        }

        #endregion

        #region Properties

        public uint ID
        {
            get
            {
                return mIndex;
            }

            set
            {
                mIndex = value;
            }
        }

        public string Name
        {
            get
            {
                return mName;
            }

            set
            {
                mName = value;
            }
        }

        public uint CurrStationIndex
        {
            get
            {
                return mCurrStationIndex;
            }

            set
            {
                mCurrStationIndex = value;
            }
        }

        public TPoint2 Position
        {
            get
            {
                return mPosition;
            }

            set
            {
                mPosition = value;
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

        public uint StartTime
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

        public uint AlightingTimePerPassenger
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

        public uint BoardingTimePerPassenger
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

        #endregion
    }
}
