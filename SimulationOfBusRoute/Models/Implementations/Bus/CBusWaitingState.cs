using System.Diagnostics;

namespace SimulationOfBusRoute.Models.Implementations.Bus
{
    public class CBusWaitingState : CBusState
    {
        public CBusWaitingState(CBus context) :
            base(context)
        {
        }

        public override void UnlockBus(uint time)
        {
            CBus context = mContext;

            context.CurrArrivalTime = time;
            context.CurrDepartureTime = time;

            mContext.SetState(mContext.AlightingState);
        }

        public override void Update(uint time, uint dt)
        {
            CBus context = mContext;

            context.CurrArrivalTime = time;
            context.CurrDepartureTime = time;

            context.ReactionTime += dt;
        }
    }
}
