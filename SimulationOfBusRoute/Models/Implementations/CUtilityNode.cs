using GMap.NET;


namespace SimulationOfBusRoute.Models.Implementations
{
    public class CUtilityNode : CRouteNode
    {
        public CUtilityNode(int id):
            base(id)
        {
        }

        public CUtilityNode(int id, PointLatLng position):
            base(id, "UtilityNode", position)
        {
        }

        public CUtilityNode(int id, string name, PointLatLng position) :
            base(id, name, position)
        {
        }

        /// <summary>
        /// Method does nothing.
        /// </summary>

        public override void Verify()
        { 
        }

        public override E_ROUTE_NODE_TYPE NodeType
        {
            get
            {
                return E_ROUTE_NODE_TYPE.RNT_UTILITY;
            }
        }
    }
}
