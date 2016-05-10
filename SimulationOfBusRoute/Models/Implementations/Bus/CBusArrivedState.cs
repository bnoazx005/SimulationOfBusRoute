using System;
using System.Diagnostics;

namespace SimulationOfBusRoute.Models.Implementations.Bus
{
    public class CBusArrivedState : CBusState
    {
        public CBusArrivedState(CBus context) :
            base(context)
        {
        }
        
        public override void Update(uint time, uint dt)
        {
            CBusStation currStation = mContext.CurrStation;
            CBus context = mContext;

            if (!currStation.IsFree)
            {
                currStation.AttachBus(mContext);

                mContext.SetState(mContext.WaitingState);

                context.CurrNumOfExcurrentPassengers = 0;
                context.CurrNumOfIncomingPassengers = 0;

                context.CurrArrivalTime = time;
                context.CurrDepartureTime = time;

                context.ReactionTime += dt;
                Debug.Assert(context.ReactionTime >= time);

                return;
            }

            currStation.AttachBus(mContext);

            context.CurrArrivalTime = time;
            context.CurrDepartureTime = time;

            context.CurrNumOfExcurrentPassengers = 0;
            context.CurrNumOfIncomingPassengers = 0;

            Debug.Assert(context.CurrArrivalTime >= context.CurrDepartureTime);
            
            mContext.SetState(mContext.AlightingState);
            mContext.Update(time, dt);
        }
    }
}
