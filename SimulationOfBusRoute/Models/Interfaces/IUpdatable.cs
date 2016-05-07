namespace SimulationOfBusRoute.Models.Interfaces
{
    public interface IUpdatable
    {
        uint ReactionTime { get; }

        void Update(uint time, uint dt);
    }
}
