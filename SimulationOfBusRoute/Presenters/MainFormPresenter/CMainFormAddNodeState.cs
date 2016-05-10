using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using SimulationOfBusRoute.Models.Implementations;
using SimulationOfBusRoute.Views;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;


namespace SimulationOfBusRoute.Presenters.MainFormPresenter
{
    public class CMainFormAddNodeState : CMainFormState
    {
        public CMainFormAddNodeState(CMainFormPresenter context) :
            base(context)
        {
        }

        public override void AddNodeMode()
        {
            IMainFormView view = mContext.View;

            Dictionary<string, Button> buttons = view.ButtonsList;

            buttons[Properties.Resources.mAddRouteNodeButtonName].BackgroundImage = Properties.Resources.mAddNodeButtonImage;
            buttons[Properties.Resources.mSelectNodeButtonName].BackgroundImage = Properties.Resources.mSelectNodeButtonActiveImage;

            view.IsPropertyActive = true;

            _onNeedSumbitProperties();//mContext.OnSubmitChanges();//ADD submit changes function call here

            mContext.SetState(mContext.SelectNodeState);
        }

        public override void MoveNodeMode()
        {
            IMainFormView view = mContext.View;

            Dictionary<string, Button> buttons = view.ButtonsList;

            buttons[Properties.Resources.mAddRouteNodeButtonName].BackgroundImage = Properties.Resources.mAddNodeButtonImage;
            buttons[Properties.Resources.mMoveNodeButtonName].BackgroundImage = Properties.Resources.mMoveNodeButtonActiveImage;

            view.IsPropertyActive = true;

            _onNeedSumbitProperties();//mContext.OnSubmitChanges();//ADD submit changes function call here

            mContext.SetState(mContext.MoveNodeState);
        }

        public override void OnMapMouseClick(object sender, MouseEventArgs e)
        {
            _onNeedSumbitProperties(); //попытка сохранить значения для предыдущего узла, перед созданием нового

            IMainFormView view = mContext.View;
            CDataManager model = mContext.Model;

            GMapControl map = view.Map;
            GMapOverlay busStationsOverlay = map.Overlays[1];

            GMapMarker busStationMarker = null;
            PointLatLng currCoordinates;

            int currMarkerIndex = view.CurrMarkerIndex;

            CRouteNode.E_ROUTE_NODE_TYPE routeNodeType = (CRouteNode.E_ROUTE_NODE_TYPE)view.RouteNodeTypeProperty.SelectedValue;

            CRouteNode currNode = null;

            if (e.Button != MouseButtons.Left)
            {
                return;
            }

            //добавление маркера на карту
            currCoordinates = map.FromLocalToLatLng(e.X, e.Y);

            //в зависимости от типа узла создать маркер нужного вида и создать объект нового узла
            //В будущем ЗАМЕНИТЬ GoogleMarker на свой ImageMarker

            switch (routeNodeType)
            {
                case CRouteNode.E_ROUTE_NODE_TYPE.RNT_INITIAL_BUS_STATION:

                    busStationMarker = new GMarkerGoogle(currCoordinates, GMarkerGoogleType.red_dot);

                    currNode = new CBusStation(CBusStation.E_BUS_STATION_TYPE.BST_INITIAL, currMarkerIndex + 1, view.NodeNameProperty, currCoordinates);

                    break;

                case CRouteNode.E_ROUTE_NODE_TYPE.RNT_BUS_STATION:

                    busStationMarker = new GMarkerGoogle(currCoordinates, GMarkerGoogleType.blue_dot);

                    currNode = new CBusStation(CBusStation.E_BUS_STATION_TYPE.BST_DEFAULT, currMarkerIndex + 1, view.NodeNameProperty, currCoordinates);

                    break;

                case CRouteNode.E_ROUTE_NODE_TYPE.RNT_FINAL_BUS_STATION:

                    busStationMarker = new GMarkerGoogle(currCoordinates, GMarkerGoogleType.red_dot);

                    currNode = new CBusStation(CBusStation.E_BUS_STATION_TYPE.BST_FINAL, currMarkerIndex + 1, view.NodeNameProperty, currCoordinates);

                    break;

                case CRouteNode.E_ROUTE_NODE_TYPE.RNT_UTILITY:

                    busStationMarker = new GMarkerGoogle(currCoordinates, GMarkerGoogleType.yellow_dot);

                    currNode = new CUtilityNode(currMarkerIndex + 1, view.NodeNameProperty, currCoordinates);

                    break;
            }

            busStationsOverlay.Markers.Insert(currMarkerIndex + 1, busStationMarker);

            //model.InsertRouteNodeByID((uint)(currMarkerIndex + 1), currNode); 

            CRouteNodesListStorage routeNodesStorage = model.RouteNodesStorage;
            routeNodesStorage.InsertAfter(routeNodesStorage.GetById(currMarkerIndex), currNode);

            StringBuilder newItemStr = new StringBuilder();
            newItemStr.AppendFormat("{0} : ({1:F3};{2:F3})", view.NodeNameProperty, currCoordinates.Lat, currCoordinates.Lng);
            view.NodesList.Items.Insert(currMarkerIndex + 1, newItemStr.ToString());

            view.CurrMarkerIndex = (currMarkerIndex + 1);
            
            view.NodeNameProperty = "";
            view.RouteNodeTypeProperty.SelectedIndex = (int)CRouteNode.E_ROUTE_NODE_TYPE.RNT_BUS_STATION;

            _onNeedUpdateRouteLines(map, busStationsOverlay.Markers);

            map.Update();
        }

        /// <summary>
        /// Method does nothing for CMainFormAddNodeState object.
        /// </summary>
        /// <param name="item">Reference to selected marker</param>
        /// <param name="e">Event's data</param>

        public override void OnMarkerSelected(GMapMarker item, MouseEventArgs e)
        {
        }

        public override void RemoveNodeMode()
        {
            IMainFormView view = mContext.View;

            Dictionary<string, Button> buttons = view.ButtonsList;

            buttons[Properties.Resources.mAddRouteNodeButtonName].BackgroundImage = Properties.Resources.mAddNodeButtonImage;
            buttons[Properties.Resources.mRemoveRouteNodeButtonName].BackgroundImage = Properties.Resources.mRemoveNodeButtonActiveImage;

            view.IsPropertyActive = false;

            _onNeedSumbitProperties();//mContext.OnSubmitChanges();//ADD submit changes function call here

            mContext.SetState(mContext.RemoveNodeState);
        }

        public override void SelectNodeMode()
        {
            IMainFormView view = mContext.View;

            Dictionary<string, Button> buttons = view.ButtonsList;

            buttons[Properties.Resources.mAddRouteNodeButtonName].BackgroundImage = Properties.Resources.mAddNodeButtonImage;
            buttons[Properties.Resources.mSelectNodeButtonName].BackgroundImage = Properties.Resources.mSelectNodeButtonActiveImage;

            view.IsPropertyActive = true;

            _onNeedSumbitProperties();//mContext.OnSubmitChanges();//ADD submit changes function call here

            mContext.SetState(mContext.SelectNodeState);
        }
    }
}
