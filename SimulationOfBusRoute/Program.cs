using System;
using System.Windows.Forms;
using SimulationOfBusRoute.Views;
using SimulationOfBusRoute.Models.Implementations;
using SimulationOfBusRoute.Presenters.MainFormPresenter;


namespace SimulationOfBusRoute
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.SetCompatibleTextRenderingDefault(false);

            CDataManager dataManager = new CDataManager();
            MainForm view = new MainForm();

            CMainFormPresenter mainViewPresenter = new CMainFormPresenter(dataManager, view);
            mainViewPresenter.Run();
        }
    }
}
