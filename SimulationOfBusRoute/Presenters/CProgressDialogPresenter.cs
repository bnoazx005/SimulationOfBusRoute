﻿using SimulationOfBusRoute.Models;
using SimulationOfBusRoute.Views;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulationOfBusRoute.Presenters
{
    class CProgressDialogPresenter : CBasePresenter<CMainModel, IProgressDialogView>
    {
        private Action mCurrTask;

        private Task mJob;

        public CProgressDialogPresenter(IProgressDialogView view, CMainModel model):
            base(model, view)
        {
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

        public override void Run()
        {
            mIsRunning = true;

            mJob.Start();

            mView.Display();
        }

        #endregion        

        #region Properties

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
