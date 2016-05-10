using System;
using System.Diagnostics;

namespace SimulationOfBusRoute.Models.Implementations.Bus
{
    public class CBusAlightingState : CBusState
    {
        public CBusAlightingState(CBus context) :
            base(context)
        {
        }
        
        public override void Update(uint time, uint dt)
        {
            CBus context = mContext;
            CBusStation currStation = context.CurrStation;

            int currStationId = currStation.BusStationId;
            
            //computing of an alighting time's duration
            if (currStation.NodeType == CRouteNode.E_ROUTE_NODE_TYPE.RNT_INITIAL_BUS_STATION)
            {
                context.CurrDepartureTime = time;
                context.CurrNumOfExcurrentPassengers = 0;

                mContext.SetState(mContext.BoardingState);
                mContext.Update(time, dt);

                return;
            }

            uint numOfExcurrentPassengers = context.PassengersDistribution[currStationId];

            if (numOfExcurrentPassengers == 0)
            {
                context.CurrDepartureTime = time;
                context.CurrNumOfExcurrentPassengers = 0;

                mContext.SetState(mContext.BoardingState);
                mContext.Update(time, dt);

                return;
            }

            context.TotalNumOfTransportedPassengers[currStationId] += numOfExcurrentPassengers;
            context.CurrBusCapacity = Math.Min(context.MaxBusCapacity, context.CurrBusCapacity + numOfExcurrentPassengers);
            context.PassengersDistribution[currStationId] = 0;
            context.CurrNumOfExcurrentPassengers = numOfExcurrentPassengers;
            
            context.CurrDepartureTime = context.CurrArrivalTime + context.AlightingTimePerPassenger * numOfExcurrentPassengers;
            
            context.ReactionTime = context.CurrDepartureTime + 1;
            Debug.Assert(context.ReactionTime >= time);

            mContext.SetState(mContext.BoardingState);
        }
    }
}
