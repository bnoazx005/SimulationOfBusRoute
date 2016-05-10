using GMap.NET.WindowsForms;
using System.Windows.Forms;
using System;
using GMap.NET.ObjectModel;
using SimulationOfBusRoute.Views;
using System.Collections.Generic;


namespace SimulationOfBusRoute.Presenters.MainFormPresenter
{
    public abstract class CMainFormState
    {
        public event EventHandler OnNeedSubmitProperties;

        public event Action<GMapControl, ObservableCollectionThreadSafe<GMapMarker>> OnNeedUpdateRouteLines;
        
        protected CMainFormPresenter mContext;

        protected CMainFormState(CMainFormPresenter context)
        {
            mContext = context;
        }

        public virtual void OnMarkerSelected(GMapMarker item, MouseEventArgs e) { }

        public virtual void OnMapMouseClick(object sender, MouseEventArgs e) { }

        public virtual void SelectNodeMode() { }

        public virtual void AddNodeMode() { }

        public virtual void RemoveNodeMode() { }

        public virtual void MoveNodeMode() { }

        public virtual void StartSimulationMode()
        {
            IMainFormView view = mContext.View;

            Dictionary<string, Button> buttons = view.ButtonsList;

            buttons[Properties.Resources.mStartSimulationButtonName].Image = Properties.Resources.mPauseSimulationButtonImage;
            buttons[Properties.Resources.mStopSimulationButtonName].Enabled = true;

            buttons[Properties.Resources.mAddRouteNodeButtonName].Enabled = false;
            buttons[Properties.Resources.mRemoveRouteNodeButtonName].Enabled = false;
            buttons[Properties.Resources.mSelectNodeButtonName].Enabled = false;
            buttons[Properties.Resources.mMoveNodeButtonName].Enabled = false;
            buttons[Properties.Resources.mBusEditorButtonName].Enabled = false;
            buttons[Properties.Resources.mDataEditorButtonName].Enabled = false;

            mContext.SetState(mContext.StartSimulationState);
        }

        public virtual void StopSimulationMode() { }

        public virtual void PauseSimulationMode() { }

        protected void _onNeedSumbitProperties()
        {
            if (OnNeedSubmitProperties != null)
            {
                OnNeedSubmitProperties(null, EventArgs.Empty);
            }
        }

        protected void _onNeedUpdateRouteLines(GMapControl map, ObservableCollectionThreadSafe<GMapMarker> markers)
        {
            if (OnNeedUpdateRouteLines != null)
            {
                OnNeedUpdateRouteLines(map, markers);
            }
        }
        
        //void ComputationsMode(CMainFormPresenter context);
    }
}
