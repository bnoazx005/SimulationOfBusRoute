using System;
using System.Diagnostics;

namespace SimulationOfBusRoute.Models.Implementations.Bus
{
    public class CBusDeparturingState : CBusState
    {
        public CBusDeparturingState(CBus context) :
            base(context)
        {
        }

        public override void Update(uint time, uint dt)
        {
            CBus context = mContext;
            CBusStation currStation = context.CurrStation;

            context.Notify();

            context.ReactionTime = time + (uint)Math.Ceiling(currStation.NextSpanTravelTime);

            currStation.DettachBus();

            context.CurrStation = currStation.NextStation;

            mContext.SetState(mContext.OnWayState);
        }
    }
}