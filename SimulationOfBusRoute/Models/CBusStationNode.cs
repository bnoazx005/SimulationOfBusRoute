using System.Data.SQLite;
using SimulationOfBusRoute.Utils;


namespace SimulationOfBusRoute.Models
{
    public class CBusStationNode : CRouteNode
    {
        private double mCurrNumOfPassengers;

        private double mIntensity;

        private bool mIsEndingStation;

        private double mVelocityOfSpan;

        #region Constructors

        public CBusStationNode(uint id, string name):
            base(id, name)
        {
            mCurrNumOfPassengers = 0.0;

            mIntensity = 0.0;

            mVelocityOfSpan = 0.0;
        }

        public CBusStationNode(uint id, string name, bool isEndingStation) :
            base(id, name)
        {
            mCurrNumOfPassengers = 0.0;

            mIntensity = 0.0;

            mVelocityOfSpan = 0.0;

            mIsEndingStation = isEndingStation;
        }

        public CBusStationNode(uint id, string name, TPoint2 position, double startNumOfPassengers, 
                               double intensity, bool isEnding):
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
                currCommand.Parameters.AddWithValue("@velocityOfSpan", mVelocityOfSpan);

                currCommand.ExecuteNonQuery();
            }
        }

        #endregion

        #region Properties

        public override E_ROUTE_NODE_TYPE NodeType
        {
            get
            {
                return mIsEndingStation ? E_ROUTE_NODE_TYPE.RNT_ENDING_BUS_STATION : E_ROUTE_NODE_TYPE.RNT_BUS_STATION;
            }
        }

        public double CurrNumOfPassengers
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

        public double Intensity
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

        public double VelocityOfSpan
        {
            get
            {
                return mVelocityOfSpan;
            }

            set
            {
                mVelocityOfSpan = value;
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
