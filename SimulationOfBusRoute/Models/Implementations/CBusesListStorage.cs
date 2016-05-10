using SimulationOfBusRoute.Models.Implementations.Bus;


namespace SimulationOfBusRoute.Models.Implementations
{
    public class CBusesListStorage : CBaseListStorage<CBus>
    {
        public CBusesListStorage():
            base()
        {
        }

        public int NumOfBuses
        {
            get
            {
                return mEntitiesList.Count;
            }
        }
    }
}
