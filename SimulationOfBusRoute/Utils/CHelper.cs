using SimulationOfBusRoute.Models;
using SimulationOfBusRoute.Presenters;
using SimulationOfBusRoute.Views;
using System;


namespace SimulationOfBusRoute.Utils
{
    public static class CHelper
    {
        public static void BackgroundModelOperation(ref CMainModel model, string infoMessage, Action job)
        {
            ProgressDialog progressDialogView = new ProgressDialog();
            CProgressDialogPresenter progressDialogPresenter = new CProgressDialogPresenter(progressDialogView, model);

            progressDialogPresenter.Text = infoMessage;

            progressDialogPresenter.CurrTask = job;

            progressDialogPresenter.Run();
        }
    }
}
