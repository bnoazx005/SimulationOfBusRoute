namespace DataModel.Implementations
{
    public enum E_ROUTE_NODE_TYPE
    {
        RNT_INITIAL_BUS_STATION,
        RNT_FINAL_BUS_STATION,
        RNT_BUS_STATION,
        RNT_CROSSROAD,
    }

    public abstract class CRouteNode : CBaseModel
    {
        protected TLatLngPoint mPosition;

        #region Constructors        

        public CRouteNode(uint id, string name) :
            base(id, name)
        {
        }

        public CRouteNode(uint id, string name, TLatLngPoint position) :
            base(id, name)
        {
            mPosition = position;
        }

        #endregion

        #region Properties

        public abstract E_ROUTE_NODE_TYPE NodeType { get; }

        public TLatLngPoint Position
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