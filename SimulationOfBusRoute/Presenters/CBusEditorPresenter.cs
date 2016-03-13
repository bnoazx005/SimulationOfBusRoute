using SimulationOfBusRoute.Models;
using SimulationOfBusRoute.Views;


namespace SimulationOfBusRoute.Presenters
{
    public class CBusEditorPresenter : IBasePresenter
    {
        private CMainModel mModel;

        private IBusEditorView mView;

        public CBusEditorPresenter(CMainModel model, IBusEditorView view)
        {
            mModel = model;
            mView = view;
        }

        public void Run()
        {
            mView.Display();
        }
    }
}
