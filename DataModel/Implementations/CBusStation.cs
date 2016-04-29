using System;
using DataModel.Interfaces;


namespace DataModel.Implementations
{
    public class CBusStation : CRouteNode, IUpdatable
    {
        public enum E_BUS_STATION_TYPE
        {
            BST_START,
            BST_FINISH,
            BST_DEFAULT
        }

        private double mReactionTime;

        private ushort mCurrNumOfPassengers;

        private ushort[] mPassengersByGroups;
        
        private double mVelocityOfSpan;

        private E_ROUTE_NODE_TYPE mType;

        #region Constructors
        
        public CBusStation(E_BUS_STATION_TYPE type, uint id, string name, int numOfStations) :
            base(id, name)
        {
            mCurrNumOfPassengers = 0;

            mVelocityOfSpan = 0.0;
            
            mReactionTime = 60.0;

            switch (type)
            {
                case E_BUS_STATION_TYPE.BST_START:
                    mType = E_ROUTE_NODE_TYPE.RNT_INITIAL_BUS_STATION;
                    break;
                case E_BUS_STATION_TYPE.BST_FINISH:
                    mType = E_ROUTE_NODE_TYPE.RNT_FINAL_BUS_STATION;
                    break;
                case E_BUS_STATION_TYPE.BST_DEFAULT:
                    mType = E_ROUTE_NODE_TYPE.RNT_BUS_STATION;
                    break;
            }
        }

        //public CBusStationNode(uint id, string name, TPoint2 position, double startNumOfPassengers, bool isEnding) :
        //    base(id, name, position)
        //{
        //    mCurrNumOfPassengers = startNumOfPassengers;

        //    mIsEndingStation = isEnding;
        //}

        #endregion

        #region Methods

        public override void LoadFromFile(string filename)
        {
        }

        public override void SaveIntoFile(string filename)
        {
            //using (SQLiteCommand currCommand = new SQLiteCommand(dbConnection))
            //{
            //    //добавление данных в таблицу routeNodes
            //    currCommand.CommandText = Properties.Resources.mSQLQueryInsertRouteNode;

            //    currCommand.Parameters.AddWithValue("@id", mIndex);
            //    currCommand.Parameters.AddWithValue("@name", mName);
            //    currCommand.Parameters.AddWithValue("@position", mPosition.ToString());

            //    if (mIsEndingStation)
            //    {
            //        currCommand.Parameters.AddWithValue("@type", E_ROUTE_NODE_TYPE.RNT_ENDING_BUS_STATION);
            //    }
            //    else
            //    {
            //        currCommand.Parameters.AddWithValue("@type", E_ROUTE_NODE_TYPE.RNT_BUS_STATION);
            //    }

            //    currCommand.ExecuteNonQuery();

            //    //добавление данных в таблицу busStationNodes
            //    currCommand.CommandText = Properties.Resources.mSQLQueryInsertBusStationNode;

            //    currCommand.Parameters.AddWithValue("@id", mIndex);
            //    currCommand.Parameters.AddWithValue("@currNumOfPassengers", mCurrNumOfPassengers);
            //    currCommand.Parameters.AddWithValue("@velocityOfSpan", mVelocityOfSpan);

            //    currCommand.ExecuteNonQuery();
            //}
        }

        public override void Verify()
        {
            throw new NotImplementedException();
        }

        public void Update(double time, double dt)
        {

        }

        #endregion

        #region Properties

        public override E_ROUTE_NODE_TYPE NodeType
        {
            get
            {
                return E_ROUTE_NODE_TYPE.RNT_BUS_STATION/*mIsEndingStation ? E_ROUTE_NODE_TYPE.RNT_ENDING_BUS_STATION : E_ROUTE_NODE_TYPE.RNT_BUS_STATION*/;
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

        #endregion
    }
}
