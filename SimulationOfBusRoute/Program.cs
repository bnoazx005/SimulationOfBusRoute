using System;
using System.Windows.Forms;

using SimulationOfBusRoute.Models;
using SimulationOfBusRoute.Presenters;
using SimulationOfBusRoute.Views;


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
            Application.SetCompatibleTextRenderingDefault(false);

            CMainModel model = new CMainModel();
            MainForm view = new MainForm();

            CMainFormPresenter mainViewPresenter = new CMainFormPresenter(model, view);

            Application.Run(view);
        }
    }
}
