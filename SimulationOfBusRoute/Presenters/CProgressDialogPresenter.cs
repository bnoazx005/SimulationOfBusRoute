using SimulationOfBusRoute.Models;
using SimulationOfBusRoute.Views;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulationOfBusRoute.Presenters
{
    class CProgressDialogPresenter : IBasePresenter
    {
        private IProgressDialogView mView;

        private CMainModel mModel;

        private bool mIsRunning;

        private Action mCurrTask;

        private Task mJob;

        public CProgressDialogPresenter(IProgressDialogView view, CMainModel model)
        {
            mView = view;

            mModel = model;

            mIsRunning = false;

            mJob = new Task(() =>
            {
                while (true)
                {
                    if (mCurrTask != null)
                    {
                        mCurrTask();

                        break;
                    }
                }

                mView.Form.Invoke((MethodInvoker)(() => { mView.Quit(); }));
            });
        }

        #region Methods

        public void Run()
        {
            mIsRunning = true;

            mJob.Start();

            mView.Display();
        }

        #endregion        

        #region Properties

        public bool IsRunning
        {
            get
            {
                return mIsRunning;
            }
        }

        public Action CurrTask
        {
            get
            {
                return mCurrTask;
            }

            set
            {
                mCurrTask = value;
            }
        }

        public string Text
        {
            get
            {
                return mView.Message;
            }

            set
            {
                mView.Message = value; 
            }
        }

        #endregion
    }
}
