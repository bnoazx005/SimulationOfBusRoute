using SimulationOfBusRoute.Utils;
using System.Data.SQLite;


namespace SimulationOfBusRoute.Models
{
    public enum E_ROUTE_NODE_TYPE
    {
        RNT_BUS_STATION,
        RNT_ENDING_BUS_STATION,
        RNT_CROSSROAD,
    }


    public abstract class CRouteNode : IBaseModel
    {
        protected uint mIndex;

        protected string mName;

        protected TPoint2 mPosition;

        #region Constructors        

        public CRouteNode(uint id, string name)
        {
            mIndex = id;

            mName = name;
        }

        public CRouteNode(uint id, string name, TPoint2 position)
        {
            mIndex = id;

            mName = name;

            mPosition = position;
        }

        #endregion

        #region Methods

        public abstract void LoadFromDataBase(SQLiteConnection dbConnection);

        public abstract void SaveIntoDataBase(SQLiteConnection dbConnection);

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

        public abstract E_ROUTE_NODE_TYPE NodeType { get; }

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
