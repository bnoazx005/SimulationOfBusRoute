using SimulationOfBusRoute.Models.Implementations;
using SimulationOfBusRoute.Presenters;
using SimulationOfBusRoute.Views;
using System;


namespace SimulationOfBusRoute.Utils
{
    public static class CBackgroundJobHelper
    {
        public static void BackgroundModelOperation(ref CDataManager model, string infoMessage, Action job)
        {
            ProgressDialog progressDialogView = new ProgressDialog();
            CProgressDialogPresenter progressDialogPresenter = new CProgressDialogPresenter(model, progressDialogView);

            progressDialogPresenter.Text = infoMessage;

            progressDialogPresenter.CurrTask = job;

            progressDialogPresenter.Run();
        }
    }
}
