using System;
using System.Linq.Expressions;


namespace SimulationOfBusRoute.Models.Implementations
{
    /// <summary>
    /// The class implements the following predicate: Is this route node a bus station? 
    /// </summary>

    public class CIsBusStationSpecification: CSpecification<CRouteNode>
    {
        public CIsBusStationSpecification():
            base()
        {
        }
        
        public override Expression<Func<CRouteNode, bool>> ToExpression()
        {
            return node => node.NodeType != CRouteNode.E_ROUTE_NODE_TYPE.RNT_UTILITY;
        }
    }

    /// <summary>
    /// The class implements the following predicate: Is this an utility node? 
    /// </summary>

    public class CIsUtilityNodeSpecification : CSpecification<CRouteNode>
    {
        public CIsUtilityNodeSpecification() :
            base()
        {
        }

        public override Expression<Func<CRouteNode, bool>> ToExpression()
        {
            return node => node.NodeType == CRouteNode.E_ROUTE_NODE_TYPE.RNT_UTILITY;
        }
    }

    /// <summary>
    /// The class implements the following predicate: (id > initialId) && IsBusStation(entity(id)) && IsBusStation(entity(initialId))
    /// </summary>

    public class CNextBusStationSpecification : CSpecification<CRouteNode>
    {
        private int mInitialStationID;

        public CNextBusStationSpecification(CBusStation initialStation) :
            base()
        {
            if (initialStation == null)
            {
                throw new ArgumentNullException("initialStation", "Parameter of the constructor cannot equal to null");
            }

            mInitialStationID = initialStation.ID;
        }

        public override Expression<Func<CRouteNode, bool>> ToExpression()
        {            
            return node => (node.NodeType != CRouteNode.E_ROUTE_NODE_TYPE.RNT_UTILITY) && (mInitialStationID + 1 == node.ID);
        }
    }

    /// <summary>
    /// The class implements the following predicate: (id < initialId) && IsBusStation(entity(id)) && IsBusStation(entity(initialId))
    /// </summary>

    public class CPrevBusStationSpecification : CSpecification<CRouteNode>
    {
        private int mInitialStationID;

        public CPrevBusStationSpecification(CBusStation initialStation) :
            base()
        {
            if (initialStation == null)
            {
                throw new ArgumentNullException("initialStation", "Parameter of the constructor cannot equal to null");
            }

            mInitialStationID = initialStation.ID;
        }

        public override Expression<Func<CRouteNode, bool>> ToExpression()
        {
            return node => (node.NodeType != CRouteNode.E_ROUTE_NODE_TYPE.RNT_UTILITY) && (mInitialStationID - 1 == node.ID);
        }
    }

    public class CBusStationsIdGTCurrSpecification : CSpecification<CRouteNode>
    {
        private int mInitialStationID;

        public CBusStationsIdGTCurrSpecification(CBusStation entity):
            base()
        {
            mInitialStationID = entity.ID;
        }

        public override Expression<Func<CRouteNode, bool>> ToExpression()
        {
            return node => (node.NodeType != CRouteNode.E_ROUTE_NODE_TYPE.RNT_UTILITY) && (node.ID > mInitialStationID);
        }
    }

    public class CBusStationsIdLTCurrSpecification : CSpecification<CRouteNode>
    {
        private int mInitialStationID;

        public CBusStationsIdLTCurrSpecification(CBusStation entity) :
            base()
        {
            mInitialStationID = entity.ID;
        }

        public override Expression<Func<CRouteNode, bool>> ToExpression()
        {
            return node => (node.NodeType != CRouteNode.E_ROUTE_NODE_TYPE.RNT_UTILITY) && (node.ID < mInitialStationID);
        }
    }
}
