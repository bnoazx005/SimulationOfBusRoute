using SimulationOfBusRoute.Views;
using System.Collections.Generic;
using System.Windows.Forms;


namespace SimulationOfBusRoute.Presenters.MainFormPresenter
{
    public class CMainFormStartSimulationState : CMainFormState
    {
        public CMainFormStartSimulationState(CMainFormPresenter context) :
            base(context)
        {
        }

        public override void StartSimulationMode()
        {
        }

        public override void StopSimulationMode()
        {
            IMainFormView view = mContext.View;

            Dictionary<string, Button> buttons = view.ButtonsList;

            buttons[Properties.Resources.mStartSimulationButtonName].Image = Properties.Resources.mStartSimulationButtonImage;
            buttons[Properties.Resources.mStopSimulationButtonName].Enabled = false;

            buttons[Properties.Resources.mAddRouteNodeButtonName].Enabled = true;
            buttons[Properties.Resources.mRemoveRouteNodeButtonName].Enabled = true;
            buttons[Properties.Resources.mSelectNodeButtonName].Enabled = true;
            buttons[Properties.Resources.mMoveNodeButtonName].Enabled = true;
            buttons[Properties.Resources.mBusEditorButtonName].Enabled = true;
            buttons[Properties.Resources.mDataEditorButtonName].Enabled = true;

            mContext.SetState(mContext.StopSimulationState);
        }

        public override void PauseSimulationMode()
        {
        }
    }
}
