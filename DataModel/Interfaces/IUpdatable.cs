namespace DataModel.Interfaces
{
    public interface IUpdatable
    {
        double ReactionTime { get; }

        void Update(double time, double dt);
    }
}
