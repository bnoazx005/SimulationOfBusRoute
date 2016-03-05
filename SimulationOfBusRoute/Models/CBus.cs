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
        }

        //конструктор используется при создании нового автобуса

        public CBus(uint id, uint currStationIndex, TPoint2 currPosition, ushort maxNumOfPassengers)
        {
            mIndex = id;

            mName = "Bus" + mIndex.ToString();

            mPosition = currPosition;

            mCurrStationIndex = currStationIndex;

            mCurrNumOfPassengers = 0;

            mNumOfIncomingPassengers = 0;

            mNumOfExcurrentPassengers = 0;

            mMaxNumOfPassengers = maxNumOfPassengers;
        }

        #endregion

        #region Methods

        public void LoadFromDataBase(SQLiteConnection dbConnection)
        {

        }

        public void SaveIntoDataBase(SQLiteConnection dbConnection)
        {

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

        public TPoint2 Position
        {
            get
            {
                return mPosition;
            }
        }

        #endregion
    }
}
