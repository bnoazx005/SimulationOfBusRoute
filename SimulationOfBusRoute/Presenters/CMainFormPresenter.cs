using System;
using System.Windows.Forms;
using SimulationOfBusRoute.Models;
using SimulationOfBusRoute.Views;
using SimulationOfBusRoute.Utils;


namespace SimulationOfBusRoute.Presenters
{
    public class CMainFormPresenter : IBasePresenter
    {
        private CBusRoute mModel;

        private IMainFormView mView;

        public CMainFormPresenter(CBusRoute model, IMainFormView view)
        {
            mModel = model;

            mView = view;

            //mouse events
            //toolbox events
            //map events
            //properties events
            //menu events
            mView.OnQuit += _onQuit;
        }

        #region Methods

        private void _onAddBusStation(object sender, EventArgs e)
        {
            mModel.AddBusStation(TPoint2.mNullPoint, 42, 3);
        }

        private void _onQuit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion
    }
}
