using System;
using System.Collections.Generic;


namespace SimulationOfBusRoute.Models.Implementations
{
    public class CRouteNodesListStorage : CBaseListStorage<CRouteNode>
    {
        public CRouteNodesListStorage():
            base()
        {
        }
        
        public int NumOfRouteNodes
        {
            get
            {
                return mEntitiesList.Count;
            }
        }

        public int NumOfBusStations
        {
            get
            {
                return GetAllBySpecification(new CIsBusStationSpecification()).Count;
            }
        }
    }
}
