using GMap.NET;
using System;
using System.ComponentModel;


namespace SimulationOfBusRoute.Models.Implementations
{
    public abstract class CRouteNode : CBaseModel
    {
        public enum E_ROUTE_NODE_TYPE
        {
            [Description("Начальная остановка")]
            RNT_INITIAL_BUS_STATION = 0,

            [Description("Конечная остановка")]
            RNT_FINAL_BUS_STATION = 1,

            [Description("Промежуточ. остановка")]
            RNT_BUS_STATION = 2,

            [Description("Вспомогательный узел")]
            RNT_UTILITY = 3,
        }

        protected PointLatLng mPosition;

        protected CRouteNode(int id):
            base(id)
        {
        }

        protected CRouteNode(int id, string name, PointLatLng position):
            base(id, name)
        {
            mPosition = position;
        }

        #region Properties

        public PointLatLng Position
        {
            get
            {
                return mPosition;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("mPosition", "Position of a route node cannot equal to null");
                }

                mPosition = value;
            }
        }

        public abstract E_ROUTE_NODE_TYPE NodeType { get; }

        public static CRouteNodesListStorage RouteNodesStorage { get; set; }

        #endregion
    }
}
