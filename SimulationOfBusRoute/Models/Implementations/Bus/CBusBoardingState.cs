using System;
using System.Diagnostics;

namespace SimulationOfBusRoute.Models.Implementations.Bus
{
    public class CBusBoardingState : CBusState
    {
        public CBusBoardingState(CBus context) :
            base(context)
        {
        }
        
        public override void Update(uint time, uint dt)
        {
            CBus context = mContext;
            CBusStation currStation = context.CurrStation;

            int currStationId = currStation.BusStationId;

            if (currStation.NodeType == CRouteNode.E_ROUTE_NODE_TYPE.RNT_FINAL_BUS_STATION)
            {
                //Debug.Assert(mContext.CurrDepartureTime >= time);
                context.CurrDepartureTime = time;
                context.CurrNumOfIncomingPassengers = 0;

                //context.ReactionTime = time + 1;

                context.SetState(context.DeparturingState);
                context.Update(time, dt);

                return;
            }

            uint currBusCapacity = context.CurrBusCapacity;

            if (currBusCapacity == 0 || currStation.CurrNumOfPassengers == 0)
            {
                //Debug.Assert(mContext.CurrDepartureTime >= time);
                context.CurrDepartureTime = time;

                //context.ReactionTime = time + 1;
                
                context.SetState(context.DeparturingState);
                context.Update(time, dt);

                return; //there is no place for the rest passengers
            }

            int passengerGroup = currStation.GetPassenger();
            
            context.CurrBusCapacity = Math.Max(context.CurrBusCapacity - 1, 0);

            context.PassengersDistribution[passengerGroup] += 1;
            context.CurrNumOfIncomingPassengers += 1;

            context.CurrDepartureTime += context.BoardingTimePerPassenger;
            Debug.Assert(mContext.CurrDepartureTime >= time);
            context.ReactionTime = context.CurrDepartureTime;
        }
    }
}
