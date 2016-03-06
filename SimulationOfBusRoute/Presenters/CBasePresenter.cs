using SimulationOfBusRoute.Models;
using SimulationOfBusRoute.Views;


namespace SimulationOfBusRoute.Presenters
{
    public abstract class CBasePresenter : IBasePresenter
    {
        protected abstract void _updateModelWithView(ref IBaseModel model, ref IBaseView view);

        protected abstract void _updateViewWithModel(ref IBaseView view, ref IBaseModel model);
    }
}
