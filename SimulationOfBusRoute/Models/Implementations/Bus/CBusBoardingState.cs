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

            uint[] incomingPassengersVec = currStation.GetPassengers(currBusCapacity);

            int incomingPassengersVecLength = incomingPassengersVec.Length;

            uint numOfIncomingPassengers = 0;
            uint currGroupValue = 0;

            uint[] currPassengers = context.PassengersDistribution;

            for (int i = 0; i < incomingPassengersVecLength; i++)
            {
                currGroupValue = incomingPassengersVec[i];

                numOfIncomingPassengers += currGroupValue;
                currPassengers[i] += currGroupValue;
            }

            context.CurrBusCapacity = Math.Max(currBusCapacity - numOfIncomingPassengers, 0);
            context.CurrNumOfIncomingPassengers = numOfIncomingPassengers;

            context.CurrDepartureTime += numOfIncomingPassengers * context.BoardingTimePerPassenger;

            context.SetState(context.DeparturingState);

            if (context.CurrDepartureTime == context.ReactionTime)
            {
                Update(time, dt);
                return;
            }

            context.ReactionTime = context.CurrDepartureTime;
        }
    }
}
