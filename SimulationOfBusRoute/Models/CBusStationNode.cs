using System.Data.SQLite;
using SimulationOfBusRoute.Utils;


namespace SimulationOfBusRoute.Models
{
    public class CBusStationNode : CRouteNode
    {
        private ushort mCurrNumOfPassengers;

        private ushort mIntensity;

        private bool mIsEndingStation;

        #region Constructors

        public CBusStationNode(uint id, string name):
            base(id, name)
        {
            mCurrNumOfPassengers = 0;

            mIntensity = 0;
        }

        public CBusStationNode(uint id, string name, TPoint2 position, ushort startNumOfPassengers, 
                               ushort intensity, bool isEnding):
            base(id, name, position)
        {
            mCurrNumOfPassengers = startNumOfPassengers;

            mIntensity = intensity;

            mIsEndingStation = isEnding;
        }

        #endregion

        #region Methods

        public override void LoadFromDataBase(SQLiteConnection dbConnection)
        {

        }

        public override void SaveIntoDataBase(SQLiteConnection dbConnection)
        {
            using (SQLiteCommand currCommand = new SQLiteCommand(dbConnection))
            {
                //добавление данных в таблицу routeNodes
                currCommand.CommandText = Properties.Resources.mSQLQueryInsertRouteNode;

                currCommand.Parameters.AddWithValue("@id", mIndex);
                currCommand.Parameters.AddWithValue("@name", mName);
                currCommand.Parameters.AddWithValue("@position", mPosition.ToString());

                if (mIsEndingStation)
                {
                    currCommand.Parameters.AddWithValue("@type", E_ROUTE_NODE_TYPE.RNT_ENDING_BUS_STATION);
                }
                else
                {
                    currCommand.Parameters.AddWithValue("@type", E_ROUTE_NODE_TYPE.RNT_BUS_STATION);
                }

                currCommand.ExecuteNonQuery();

                //добавление данных в таблицу busStationNodes
                currCommand.CommandText = Properties.Resources.mSQLQueryInsertBusStationNode;

                currCommand.Parameters.AddWithValue("@id", mIndex);
                currCommand.Parameters.AddWithValue("@currNumOfPassengers", mCurrNumOfPassengers);
                currCommand.Parameters.AddWithValue("@intensity", mIntensity);

                currCommand.ExecuteNonQuery();
            }
        }

        #endregion

        #region Properties
        
        public ushort CurrNumOfPassengers
        {
            get
            {
                return mCurrNumOfPassengers;
            }

            set
            {
                mCurrNumOfPassengers = value;
            }
        }

        public ushort Intensity
        {
            get
            {
                return mIntensity;
            }

            set
            {
                mIntensity = value;
            }
        }

        public bool IsEndingStation
        {
            get
            {
                return mIsEndingStation;
            }

            set
            {
                mIsEndingStation = value;
            }
        }

        #endregion
    }
}
