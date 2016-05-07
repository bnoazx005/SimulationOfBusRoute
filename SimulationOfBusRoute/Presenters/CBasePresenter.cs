using SimulationOfBusRoute.Views;
using SimulationOfBusRoute.Models.Interfaces;


namespace SimulationOfBusRoute.Presenters
{
    public class CBasePresenter <M, V> : IBasePresenter 
                            where M : class, IBaseModel
                            where V : class, IBaseView
    {
        protected bool mIsRunning;

        protected M mModel;

        protected V mView;

        protected CBasePresenter(M model, V view)
        {
            mIsRunning = false;

            mModel = model;
            mView = view;
        }

        public virtual void Run()
        {
            mIsRunning = true;

            mView.Display();
        }

        public bool IsRunning
        {
            get
            {
                return mIsRunning;
            }
        }

        public V View
        {
            get
            {
                return mView;
            }
        }

        public M Model
        {
            get
            {
                return mModel;
            }
        }
    }
}
