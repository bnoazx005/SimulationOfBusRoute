using SimulationOfBusRoute.Models;
using SimulationOfBusRoute.Utils;
using SimulationOfBusRoute.Views;
using System;
using System.Windows.Forms;


namespace SimulationOfBusRoute.Presenters
{
    class CSimulationSettingsPresenter : CBasePresenter<CMainModel, ISimulationSettingsView>
    {
        public CSimulationSettingsPresenter(CMainModel model, ISimulationSettingsView view):
            base(model, view)
        {
            mView.OnFormInit += _onFormInit;
            mView.OnQuit += _onQuit;

            mView.OnAcceptChanges   += _onAcceptChanges;
            mView.OnDeclineChanges  += _onCloseForm;

            mView.OnSpeedOfSimulationValueChanged += _onSpeedOfSimulationChanged;
        }
        
        private void _onFormInit(object sender, EventArgs e)
        {
            ISimulationSettingsView view = mView;
            CMainModel model = mModel;

            int speedOfSimulation = (int)(view.MaxSpeedOfSimulation - model.SpeedOfSimulation);

            view.SpeedOfSimulation = speedOfSimulation;
            view.SpeedOfSimulationTrackBar = speedOfSimulation;
            view.TimeOfStart = model.StartTimeOfSimulation;
            view.TimeOfFinish = model.FinishTimeOfSimulation;
        }
        
        private void _onAcceptChanges(object sender, EventArgs e)
        {
            //сохранение данных в модель
            ISimulationSettingsView view = mView;

            mModel.SpeedOfSimulation = (uint)Math.Max(0, view.MaxSpeedOfSimulation - view.SpeedOfSimulation);

            try
            {
                TimeSpan diffTime = view.TimeOfFinish.Subtract(view.TimeOfStart);

                if (diffTime.TotalSeconds <= 0)
                {
                    //вызов исключения
                    throw new CInvalidValueException(Properties.Resources.mSettingsIncorrectTimeIntervalErrorMessage);
                }

                mModel.NumOfSimulationSteps = (uint)diffTime.TotalSeconds;
            }
            catch(OverflowException formatException)
            {
                Application.OnThreadException(formatException);
                return;
            }
            catch(CInvalidValueException ex)
            {
                Application.OnThreadException(ex);
                return;
            }

            mModel.StartTimeOfSimulation = view.TimeOfStart;
            mModel.FinishTimeOfSimulation = view.TimeOfFinish;

            //выход
            _onCloseForm(sender, e);
        }

        private void _onQuit(object sender, FormClosingEventArgs e)
        {
            mIsRunning = false;
        }

        private void _onCloseForm(object sender, EventArgs e)
        {
            mView.Quit();
        }

        private void _onSpeedOfSimulationChanged(object sender, EventArgs e)
        {
            if (sender == null) //изменен numericbox, меняем trackbar
            {
                mView.SpeedOfSimulationTrackBar = mView.SpeedOfSimulation;

                return;
            }

            mView.SpeedOfSimulation = mView.SpeedOfSimulationTrackBar;
        }
    }
}
