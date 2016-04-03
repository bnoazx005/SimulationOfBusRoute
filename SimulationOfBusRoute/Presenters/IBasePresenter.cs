

namespace SimulationOfBusRoute.Presenters
{
    public interface IBasePresenter
    {
        void Run();

        bool IsRunning { get; }
    }
}
