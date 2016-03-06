using System.Data.SQLite;
using SimulationOfBusRoute.Utils;


namespace SimulationOfBusRoute.Models
{
    public class CBusStation : IBaseModel
    {
        private uint mIndex;

        private string mName;

        private TPoint2 mPosition;

        private ushort mCurrNumOfPassengers;

        private ushort mIntensity;

        #region Constructors

        public CBusStation(uint id)
        {
            mIndex = id;

            mName = "Station" + mIndex.ToString();

            mPosition = TPoint2.mNullPoint;

            mCurrNumOfPassengers = 0;

            mIntensity = 0;
        }

        public CBusStation(uint id, TPoint2 position, ushort startNumOfPassengers, ushort intensity)
        {
            mIndex = id;

            mName = "Station" + mIndex.ToString();

            mPosition = position;

            mCurrNumOfPassengers = startNumOfPassengers;

            mIntensity = intensity;
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
