using SimulationOfBusRoute.Models;
using SimulationOfBusRoute.Views;
using System;
using System.Windows.Forms;

namespace SimulationOfBusRoute.Presenters
{
    class CStationsEditorPresenter : IBasePresenter
    {
        private bool mIsRunning;

        private CMainModel mModel;

        private IStationsEditorView mView;

        public CStationsEditorPresenter(CMainModel model, IStationsEditorView view)
        {
            mModel = model;

            mView = view;

            mIsRunning = false;

            mView.OnFormInit += _onFormInit;
            mView.OnQuit += _onQuit;
            mView.OnAddMatrix += _onAddMatrix;
            mView.OnRemoveMatrix += _onRemoveMatrix;
            mView.OnTimerTick += _onTimerTick;
            mView.OnClose += _onClose;
        }

        public void Run()
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

        private void _onFormInit(object sender, EventArgs e)
        {

        }

        private void _onQuit(object sender, FormClosingEventArgs e)
        {
            //mView.Quit();
            
            mIsRunning = false;
        }

        private void _onClose(object sender, FormClosedEventArgs e)
        {
           
        }

        private void _onAddMatrix(object sender, EventArgs e)
        {

        }

        private void _onRemoveMatrix(object sender, EventArgs e)
        {

        }

        private void _onTimerTick(object sender, EventArgs e)
        {
            if (!mIsRunning)
            {
                return;
            }

            ;
        }
    }
}
