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
                currCommand.Parameters.AddWithValue("@position", mPosition.ToString());
                currCommand.Parameters.AddWithValue("@velocity", mVelocity);
                currCommand.Parameters.AddWithValue("@currNumOfPassengers", mCurrNumOfPassengers);
                currCommand.Parameters.AddWithValue("@numOfIncomingPassengers", mNumOfIncomingPassengers);
                currCommand.Parameters.AddWithValue("@numOfExcurrentPassengers", mNumOfExcurrentPassengers);
                currCommand.Parameters.AddWithValue("@maxNumOfPassengers", mMaxNumOfPassengers);
                currCommand.Parameters.AddWithValue("@currRouteNodeIndex", mCurrStationIndex);

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

        #endregion
    }
}
