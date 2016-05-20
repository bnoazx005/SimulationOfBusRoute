using SimulationOfBusRoute.Models.Implementations;
using SimulationOfBusRoute.Utils;
using SimulationOfBusRoute.Views;
using System;
using System.Windows.Forms;


namespace SimulationOfBusRoute.Presenters.SimulationSettingsPresenter
{
    public class CSimulationSettingsPresenter : CBasePresenter<CDataManager, ISimulationSettingsView>
    {
        public CSimulationSettingsPresenter(CDataManager model, ISimulationSettingsView view):
            base(model, view)
        {
            mView.OnFormInit += _onFormInit;
            mView.OnQuit += _onQuit;

            mView.OnAcceptChanges   += _onAcceptChanges;
            mView.OnDeclineChanges  += _onCloseForm;
        }
        
        private void _onFormInit(object sender, EventArgs e)
        {
            ISimulationSettingsView view = mView;
            CDataManager model = mModel;
            COptionsList options = model.OptionsList;
            
            view.TimeOfStart = TimeSpan.Parse(options.GetStringParam(Properties.Resources.mOptionsStartTimeOfSimulation));
            view.TimeOfFinish = TimeSpan.Parse(options.GetStringParam(Properties.Resources.mOptionsFinishTimeOfSimulation));
        }
        
        private void _onAcceptChanges(object sender, EventArgs e)
        {
            //try to save the data into options' list
            ISimulationSettingsView view = mView;
            COptionsList options = mModel.OptionsList;
            
            try
            {
                TimeSpan diffTime = view.TimeOfFinish.Subtract(view.TimeOfStart);

                if (diffTime.TotalSeconds <= 0)
                {
                    //throw the exception
                    throw new CInvalidValueException(Properties.Resources.mSettingsIncorrectTimeIntervalErrorMessage);
                }

                options.AddIntParam(Properties.Resources.mOptionsNumOfSimulationSteps, (int)diffTime.TotalSeconds);
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
            catch (FormatException ex)
            {
                Application.OnThreadException(ex);
                return;
            }

            options.AddStringParam(Properties.Resources.mOptionsStartTimeOfSimulation, view.TimeOfStart.ToString());
            options.AddStringParam(Properties.Resources.mOptionsFinishTimeOfSimulation, view.TimeOfFinish.ToString());

            //close the form, data is valid
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
    }
}
