using GMap.NET.WindowsForms;
using SimulationOfBusRoute.Models.Implementations;
using SimulationOfBusRoute.Views;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace SimulationOfBusRoute.Presenters.MainFormPresenter
{
    public class CMainFormRemoveNodeState : CMainFormState
    {
        public CMainFormRemoveNodeState(CMainFormPresenter context) :
            base(context)
        {
        }

        public override void AddNodeMode()
        {
            IMainFormView view = mContext.View;

            Dictionary<string, Button> buttons = view.ButtonsList;

            buttons[Properties.Resources.mRemoveRouteNodeButtonName].BackgroundImage = Properties.Resources.mRemoveNodeButtonImage;
            buttons[Properties.Resources.mAddRouteNodeButtonName].BackgroundImage = Properties.Resources.mAddNodeButtonActiveImage;

            view.IsPropertyActive = true;

            _onNeedSumbitProperties();//mContext.OnSubmitChanges();//ADD submit changes function call here

            mContext.SetState(mContext.AddNodeState);
        }

        public override void MoveNodeMode()
        {
            IMainFormView view = mContext.View;

            Dictionary<string, Button> buttons = view.ButtonsList;

            buttons[Properties.Resources.mRemoveRouteNodeButtonName].BackgroundImage = Properties.Resources.mRemoveNodeButtonImage;
            buttons[Properties.Resources.mMoveNodeButtonName].BackgroundImage = Properties.Resources.mMoveNodeButtonActiveImage;

            view.IsPropertyActive = true;

            mContext.SetState(mContext.MoveNodeState);
        }

        /// <summary>
        /// Method does nothing for CMainFormRemoveNodeState object.
        /// </summary>
        /// <param name="sender">Reference to sender's object</param>
        /// <param name="e">Event's data</param>

        public override void OnMapMouseClick(object sender, MouseEventArgs e)
        {
        }

        public override void OnMarkerSelected(GMapMarker item, MouseEventArgs e)
        {
            IMainFormView view = mContext.View;
            CDataManager model = mContext.Model;

            if (item == null)
            {
                throw new ArgumentNullException("The argument equals null", "item");
            }

            GMapOverlay routeNodesOverlay = view.Map.Overlays[1];

            int currMarkerIndex = -1;
            
            if (e.Button != MouseButtons.Left)
            {
                return;
            }

            currMarkerIndex = routeNodesOverlay.Markers.IndexOf(item);
            routeNodesOverlay.Markers.RemoveAt(currMarkerIndex);

            //Добавить удаление сведений из модели (обновление модели)
            CRouteNodesListStorage routeNodesStorage = model.RouteNodesStorage;
            routeNodesStorage.Delete(routeNodesStorage.GetById(currMarkerIndex));
            
            //обновление представления
            view.NodesList.Items.RemoveAt(currMarkerIndex);
            view.CurrMarkerIndex = -1;

            _onNeedUpdateRouteLines(view.Map, routeNodesOverlay.Markers);
        }

        public override void RemoveNodeMode()
        {
            IMainFormView view = mContext.View;

            Dictionary<string, Button> buttons = view.ButtonsList;

            buttons[Properties.Resources.mRemoveRouteNodeButtonName].BackgroundImage = Properties.Resources.mRemoveNodeButtonImage;
            buttons[Properties.Resources.mSelectNodeButtonName].BackgroundImage = Properties.Resources.mSelectNodeButtonActiveImage;
            
            view.IsPropertyActive = true;

            mContext.SetState(mContext.SelectNodeState);
        }

        public override void SelectNodeMode()
        {
            IMainFormView view = mContext.View;

            Dictionary<string, Button> buttons = view.ButtonsList;

            buttons[Properties.Resources.mRemoveRouteNodeButtonName].BackgroundImage = Properties.Resources.mRemoveNodeButtonImage;
            buttons[Properties.Resources.mSelectNodeButtonName].BackgroundImage = Properties.Resources.mSelectNodeButtonActiveImage;

            view.IsPropertyActive = true;

            mContext.SetState(mContext.SelectNodeState);
        }
    }
}
