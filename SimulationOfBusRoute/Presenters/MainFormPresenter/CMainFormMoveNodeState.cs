using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using SimulationOfBusRoute.Views;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace SimulationOfBusRoute.Presenters.MainFormPresenter
{
    public class CMainFormMoveNodeState : CMainFormState
    {
        public event Func<GMapMarker> OnNeedGetCurrMarker;

        public CMainFormMoveNodeState(CMainFormPresenter context) :
            base(context)
        {
        }

        public override void AddNodeMode()
        {
            IMainFormView view = mContext.View;

            Dictionary<string, Button> buttons = view.ButtonsList;

            buttons[Properties.Resources.mMoveNodeButtonName].BackgroundImage = Properties.Resources.mMoveNodeButtonImage;
            buttons[Properties.Resources.mAddRouteNodeButtonName].BackgroundImage = Properties.Resources.mAddNodeButtonActiveImage;

            view.IsPropertyActive = true;

            _onNeedSumbitProperties();//mContext.OnSubmitChanges();//ADD submit changes function call here

            mContext.SetState(mContext.AddNodeState);
        }

        public override void MoveNodeMode()
        {
            IMainFormView view = mContext.View;

            Dictionary<string, Button> buttons = view.ButtonsList;

            buttons[Properties.Resources.mMoveNodeButtonName].BackgroundImage = Properties.Resources.mMoveNodeButtonImage;
            buttons[Properties.Resources.mSelectNodeButtonName].BackgroundImage = Properties.Resources.mSelectNodeButtonActiveImage;

            view.IsPropertyActive = true;

            mContext.SetState(mContext.SelectNodeState);
        }

        public override void OnMapMouseClick(object sender, MouseEventArgs e)
        {
            IMainFormView view = mContext.View;

            GMapControl map = view.Map;
            GMapOverlay busStationsOverlay = map.Overlays[1];

            GMapMarker busStationMarker = null;
            PointLatLng currCoordinates;
                        
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            
            currCoordinates = map.FromLocalToLatLng(e.X, e.Y);

            busStationMarker = _onNeedGetCurrMarker() as GMarkerGoogle;

            if (busStationMarker == null)
            {
                return;
            }

            busStationMarker.Position = currCoordinates;

            _onNeedUpdateRouteLines(map, busStationsOverlay.Markers); //updating the lines of a route
            _onNeedSumbitProperties(); //updating the node's data

            map.Update();
        }

        public override void OnMarkerSelected(GMapMarker item, MouseEventArgs e)
        {
        }

        public override void RemoveNodeMode()
        {
            IMainFormView view = mContext.View;

            Dictionary<string, Button> buttons = view.ButtonsList;

            buttons[Properties.Resources.mMoveNodeButtonName].BackgroundImage = Properties.Resources.mMoveNodeButtonImage;
            buttons[Properties.Resources.mRemoveRouteNodeButtonName].BackgroundImage = Properties.Resources.mRemoveNodeButtonActiveImage;

            view.IsPropertyActive = false;

            mContext.SetState(mContext.RemoveNodeState);
        }

        public override void SelectNodeMode()
        {
            IMainFormView view = mContext.View;

            Dictionary<string, Button> buttons = view.ButtonsList;

            buttons[Properties.Resources.mMoveNodeButtonName].BackgroundImage = Properties.Resources.mMoveNodeButtonImage;
            buttons[Properties.Resources.mSelectNodeButtonName].BackgroundImage = Properties.Resources.mSelectNodeButtonActiveImage;
            
            view.IsPropertyActive = true;

            mContext.SetState(mContext.SelectNodeState);
        }

        protected GMapMarker _onNeedGetCurrMarker()
        {
            if (OnNeedGetCurrMarker != null)
            {
                return OnNeedGetCurrMarker();
            }

            return null;
        }
    }
}
