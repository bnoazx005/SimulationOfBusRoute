using SimulationOfBusRoute.Models;
using SimulationOfBusRoute.Views;
using System;
using System.Windows.Forms;

namespace SimulationOfBusRoute.Presenters
{
    class CStationsEditorPresenter : CBasePresenter<CMainModel, IStationsEditorView>
    {
        public CStationsEditorPresenter(CMainModel model, IStationsEditorView view):
            base(model, view)
        {
            mView.OnFormInit += _onFormInit;
            mView.OnQuit += _onQuit;

            mView.OnAddMatrix += _onAddMatrix;
            mView.OnRemoveMatrix += _onRemoveMatrix;
            mView.OnTimerTick += _onTimerTick;
            mView.OnCloseForm += _onCloseForm;
        }
        
        private void _onFormInit(object sender, EventArgs e)
        {

        }

        private void _onQuit(object sender, FormClosingEventArgs e)
        {            
            mIsRunning = false;
        }

        private void _onCloseForm(object sender, EventArgs e)
        {
            mView.Quit();
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

            System.Diagnostics.Debug.WriteLine("Tick");
        }
    }
}
