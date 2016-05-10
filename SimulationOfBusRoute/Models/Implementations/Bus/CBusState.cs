namespace SimulationOfBusRoute.Models.Implementations.Bus
{
    public abstract class CBusState
    {
        protected CBus mContext;

        public CBusState(CBus context)
        {
            mContext = context;
        }

        public virtual void UnlockBus(uint time) { }
        
        public abstract void Update(uint time, uint dt);
    }
}
