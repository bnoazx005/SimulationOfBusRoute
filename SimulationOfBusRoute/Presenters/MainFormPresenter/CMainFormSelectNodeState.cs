using GMap.NET.WindowsForms;
using SimulationOfBusRoute.Views;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace SimulationOfBusRoute.Presenters.MainFormPresenter
{
    public class CMainFormSelectNodeState : CMainFormState
    {
        public CMainFormSelectNodeState(CMainFormPresenter context) :
            base(context)
        {
        }

        public override void AddNodeMode()
        {
            IMainFormView view = mContext.View;

            Dictionary<string, Button> buttons = view.ButtonsList;

            buttons[Properties.Resources.mSelectNodeButtonName].BackgroundImage = Properties.Resources.mSelectNodeButtonImage;
            buttons[Properties.Resources.mAddRouteNodeButtonName].BackgroundImage = Properties.Resources.mAddNodeButtonActiveImage;

            view.IsPropertyActive = true;

            _onNeedSumbitProperties();//mContext.OnSubmitChanges();//ADD submit changes function call here

            mContext.SetState(mContext.AddNodeState);
        }

        public override void MoveNodeMode()
        {
            IMainFormView view = mContext.View;

            Dictionary<string, Button> buttons = view.ButtonsList;

            buttons[Properties.Resources.mSelectNodeButtonName].BackgroundImage = Properties.Resources.mSelectNodeButtonImage;
            buttons[Properties.Resources.mMoveNodeButtonName].BackgroundImage = Properties.Resources.mMoveNodeButtonActiveImage;

            view.IsPropertyActive = true;

            mContext.SetState(mContext.MoveNodeState);
        }

        /// <summary>
        /// Method does nothing for CMainFormSelectNodeState object.
        /// </summary>
        /// <param name="sender">Reference to sender's object</param>
        /// <param name="e">Event's data</param>

        public override void OnMapMouseClick(object sender, MouseEventArgs e)
        {
        }

        public override void OnMarkerSelected(GMapMarker item, MouseEventArgs e)
        {
            IMainFormView view = mContext.View;

            if (item == null)
            {
                throw new ArgumentNullException("The argument equals null", "item");
            }

            GMapOverlay routeNodesOverlay = view.Map.Overlays[1];
                        
            view.CurrMarkerIndex = routeNodesOverlay.Markers.IndexOf(item);
            view.IsPropertyActive = true;
        }

        public override void RemoveNodeMode()
        {
            IMainFormView view = mContext.View;

            Dictionary<string, Button> buttons = view.ButtonsList;

            buttons[Properties.Resources.mSelectNodeButtonName].BackgroundImage = Properties.Resources.mSelectNodeButtonImage;
            buttons[Properties.Resources.mRemoveRouteNodeButtonName].BackgroundImage = Properties.Resources.mRemoveNodeButtonActiveImage;

            view.IsPropertyActive = false;

            mContext.SetState(mContext.RemoveNodeState);
        }
    }
}
