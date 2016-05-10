using System.Diagnostics;

namespace SimulationOfBusRoute.Models.Implementations.Bus
{
    public class CBusOnWayState : CBusState
    {
        public CBusOnWayState(CBus context):
            base(context)
        {
        }

        public override void Update(uint time, uint dt)
        {
            mContext.SetState(mContext.ArrivedState);
            mContext.Update(time, dt);
        }
    }
}
