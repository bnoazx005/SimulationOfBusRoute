using System;
using SimulationOfBusRoute.Models;
using SimulationOfBusRoute.Views;


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

        public virtual bool IsRunning
        {
            get
            {
                return mIsRunning;
            }
        }
    }
}
