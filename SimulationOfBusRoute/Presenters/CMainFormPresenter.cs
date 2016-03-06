using System;
using System.Windows.Forms;
using SimulationOfBusRoute.Models;
using SimulationOfBusRoute.Views;
using GMap.NET.WindowsForms;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms.Markers;
using GMap.NET;
using System.Text;
using System.Collections.Generic;
using SimulationOfBusRoute.Utils;
using System.IO;
using System.Data.SQLite;
using System.Drawing;


namespace SimulationOfBusRoute.Presenters
{
    public class CMainFormPresenter : IBasePresenter
    {
        private CMainModel mModel;

        private IMainFormView mView;

        public CMainFormPresenter(CMainModel model, IMainFormView view)
        {
            mModel = model;
            mView = view;

            mView.OnFormInit += _onFormInit;

            //keyboard events
            mView.OnKeyPressed += _onKeyPressed;

            //toolbox events
            mView.OnAddRouteNode += _onAddRouteNode;
            mView.OnRemoveRouteNode += _onRemoveRouteNode;
            mView.OnOpenBusEditor += _onLaunchBusEditor;
            mView.OnShowStatistics += _onShowStatisticsWindow;

            //map events
            mView.OnMapZoomChanged += _onZoomMapChanged;
            mView.OnMarkerSelected += _onMarkerSelected;
            mView.OnMapMouseClick += _onMapMouseClick;

            //properties events
            mView.OnNodeTypeChanged += _onNodeTypeChanged;
            mView.OnSubmitProperties += _onSubmitProperties;
            mView.OnNodeSelectionChanged += _onNodeSelectionChanged;

            //menu events
            mView.OnLoadData += _onLoadModelData;
            mView.OnSaveData += _onSaveModelData;
            mView.OnQuit += _onQuit;
            mView.OnClearMap += _onClearMap;
        }

        #region Methods

        private void _onFormInit(object sender, EventArgs e)
        {
            GMapControl map = mView.Map;

#if DEBUG
            map.Manager.Mode = AccessMode.ServerOnly;
#else
            map.Manager.Mode = GMap.NET.AccessMode.ServerAndCache;
#endif

            map.MapProvider = YandexMapProvider.Instance;
            map.SetPositionByKeywords("Russia, Izhevsk");

            map.Overlays.Add(new GMapOverlay("RouteLinesNodes"));
            map.Overlays.Add(new GMapOverlay("Nodes"));
            
            //привязка типов узлов к элементу представления
            //ПЕРЕДЕЛАТЬ,ЧТОБЫ ОТОБРАЖАЛИСЬ НОРМАЛЬНЫЕ НАЗВАНИЯ,А НЕ ОРИГИНАЛЬНЫЕ ИМЕНА ЭЛЕМЕНТОВ ПЕРЕЧИСЛЕНИЯ
            ComboBox routeNodeType = mView.RouteNodeTypeProperty;

            routeNodeType.DataSource = Enum.GetValues(typeof(E_ROUTE_NODE_TYPE));

            _activatePropertiesEditor((E_ROUTE_NODE_TYPE)routeNodeType.SelectedValue);
        }

        private void _onKeyPressed(object sender, KeyEventArgs e)
        {
            //MessageBox.Show("Pressed" + e.KeyValue.ToString());
            // mModel.AddBusStation(TPoint2.mNullPoint, 42, 3);

            if (e.KeyCode == Keys.C) //временное решение, будет переделано позже
            {
                mView.Map.Position = new PointLatLng(56.855079, 53.239444);               
            }

            //ЗАМЕНИТЬ НА ВЫЗОВ _onAddBusStation
            //сделать на "+" приближение карты
            if (e.KeyCode == Keys.D1 && e.Control)
            {
                _onAddRouteNode(null, EventArgs.Empty);
            }

            if (e.KeyCode == Keys.D2 && e.Control)
            {
                _onRemoveRouteNode(null, EventArgs.Empty);
            }
        }
        
        private void _onQuit(object sender, EventArgs e)
        {
            //ДОБАВИТЬ ВАЛИДАЦИЮ СОСТОЯНИЯ МОДЕЛИ, ЕСЛИ ИЗМЕНЕНА, ТО ПРЕДЛОЖИТЬ СОХРАНИТЬ

            Application.Exit();
        }

        private void _onAddRouteNode(object sender, EventArgs e)
        {
            IMainFormView view = mView;
            CMainModel model = mModel;

            Button addRouteNodeButton = view.ButtonsList[Properties.Resources.mAddRouteNodeButtonName];
            
            if (model.CurrState != E_CURRENT_STATE.CS_EDITOR_ADD_MARKER)
            {
                model.CurrState = E_CURRENT_STATE.CS_EDITOR_ADD_MARKER;

                addRouteNodeButton.BackgroundImage = Properties.Resources.mAddRouteNodeButtonActive;

                view.IsPropertyActive = true;
                
                return;
            }

            model.CurrState = E_CURRENT_STATE.CS_DEFAULT;

            addRouteNodeButton.BackgroundImage = Properties.Resources.mAddRouteNodeButton;
        }

        private void _onRemoveRouteNode(object sender, EventArgs e)
        {
            IMainFormView view = mView;
            CMainModel model = mModel;

            Button removeRouteNodeButton = view.ButtonsList[Properties.Resources.mRemoveRouteNodeButtonName];

            if (model.CurrState != E_CURRENT_STATE.CS_EDITOR_REMOVE_MARKER)
            {
                model.CurrState = E_CURRENT_STATE.CS_EDITOR_REMOVE_MARKER;

                removeRouteNodeButton.BackgroundImage = Properties.Resources.mRemoveRouteNodeButtonActive;

                return;
            }

            model.CurrState = E_CURRENT_STATE.CS_DEFAULT;

            removeRouteNodeButton.BackgroundImage = Properties.Resources.mRemoveRouteNodeButton;
        }

        private void _onClearMap(object sender, EventArgs e)
        {
            IMainFormView view = mView;
            CMainModel model = mModel;

            GMapOverlay busStationsOverlay = view.Map.Overlays[1];
            GMapOverlay routeLinesOverlay = view.Map.Overlays[0];

            //Обновление представления
            view.CurrMarkerIndex = -1;

            view.NodesList.Items.Clear();

            //Добавить удаление линий после удаления маркеров
            busStationsOverlay.Markers.Clear();
            routeLinesOverlay.Polygons.Clear();

            //Обновление модели
            model.ClearRoute();

            model.CurrState = E_CURRENT_STATE.CS_DEFAULT;
        }

        private void _onZoomMapChanged(object sender, EventArgs e)
        {
            GMapControl map = mView.Map;

            if (sender == null)
            {
                mView.MapZoomValue = (int)map.Zoom - map.MinZoom;

                return;
            }

            map.Zoom = map.MinZoom + mView.MapZoomValue;
        }

        private void _onMapMouseClick(object sender, MouseEventArgs e)
        {
            IMainFormView view = mView;
            CMainModel model = mModel;

            GMapControl map = view.Map;
            GMapOverlay busStationsOverlay = map.Overlays[1];

            GMapMarker busStationMarker = null;
            PointLatLng currCorrdinates;

            StringBuilder newItemStr;

            int currMarkerIndex = view.CurrMarkerIndex;

            E_ROUTE_NODE_TYPE routeNodeType = (E_ROUTE_NODE_TYPE)view.RouteNodeTypeProperty.SelectedValue;

            Button currActiveButton = null;

            //добавление маркера на карту
            if ((e.Button == MouseButtons.Left) && (model.CurrState == E_CURRENT_STATE.CS_EDITOR_ADD_MARKER))
            {
                currCorrdinates = map.FromLocalToLatLng(e.X, e.Y);

                switch (routeNodeType)
                {
                    case E_ROUTE_NODE_TYPE.RNT_BUS_STATION:
                        busStationMarker = new GMarkerGoogle(currCorrdinates, GMarkerGoogleType.blue_dot);
                        break;
                    case E_ROUTE_NODE_TYPE.RNT_ENDING_BUS_STATION:
                        busStationMarker = new GMarkerGoogle(currCorrdinates, GMarkerGoogleType.red_dot);
                        break;
                    case E_ROUTE_NODE_TYPE.RNT_CROSSROAD:
                        busStationMarker = new GMarkerGoogle(currCorrdinates, GMarkerGoogleType.yellow_dot);
                        break;
                }

                //busStationsOverlay.Markers.Add(busStationMarker); пока оставляем, т.к, возможно, придется вернуться к этому варианту, но это мало вероятно

                busStationsOverlay.Markers.Insert(currMarkerIndex + 1, busStationMarker);
                _updateRouteLines(map, busStationsOverlay.Markers);
                
                map.Update();

                model.CurrBusRoute.InsertRouteNodeByID((uint)(currMarkerIndex + 1), null);

                //TEMP CODE
                //Переписать в более нормальном виде
                //Генерить список по списку маркеров, чтобы было правильное упорядочивание
                newItemStr = new StringBuilder();
                newItemStr.AppendFormat("{0} : ({1:F3};{2:F3})", view.NodeNameProperty, currCorrdinates.Lat, currCorrdinates.Lng);
                view.NodesList.Items.Insert(currMarkerIndex + 1, newItemStr.ToString());

                model.CurrState = E_CURRENT_STATE.CS_EDITOR_UPDATE_MARKER;
                view.CurrMarkerIndex = (currMarkerIndex + 1);

                // обновление представления соответствующей кнопки
                currActiveButton = view.ButtonsList[Properties.Resources.mAddRouteNodeButtonName];
                currActiveButton.BackgroundImage = Properties.Resources.mAddRouteNodeButton;
            }
            
            //ДОБАВИТЬ ОБНОВЛЕНИЕ МОДЕЛИ ПРИ ПЕРЕМЕЩЕНИИ МАРКЕРА И ОБНОВЛЕНИЕ ПОЛИГОНА МАРШРУТА
            if ((e.Button == MouseButtons.Left) && (model.CurrState == E_CURRENT_STATE.CS_EDITOR_UPDATE_MARKER))
            {
                currCorrdinates = map.FromLocalToLatLng(e.X, e.Y);

                busStationMarker = _getCurrMarker() as GMarkerGoogle;

                busStationMarker.Position = currCorrdinates;

                _updateRouteLines(map, busStationsOverlay.Markers); // обновление пути

                map.Update();
            }
        }

        private void _onMarkerSelected(GMapMarker item, MouseEventArgs e)
        {
            IMainFormView view = mView;
            CMainModel model = mModel;

            if (item == null)
            {
                throw new ArgumentNullException("The argument equals null", "item");
            }

            GMapOverlay routeNodesOverlay = view.Map.Overlays[1];

            int currMarkerIndex = -1;

            Button currActiveButton = null;

            if (model.CurrState == E_CURRENT_STATE.CS_DEFAULT)
            {
                model.CurrState = E_CURRENT_STATE.CS_EDITOR_UPDATE_MARKER;
                view.CurrMarkerIndex = routeNodesOverlay.Markers.IndexOf(item);
            }

            if (e.Button == MouseButtons.Left && model.CurrState == E_CURRENT_STATE.CS_EDITOR_REMOVE_MARKER)
            {
                currMarkerIndex = routeNodesOverlay.Markers.IndexOf(item);
                routeNodesOverlay.Markers.RemoveAt(currMarkerIndex);

                //Добавить удаление сведений из модели (обновление модели)

                model.CurrState = E_CURRENT_STATE.CS_DEFAULT;

                //обновление представления
                view.NodesList.Items.RemoveAt(currMarkerIndex);
                view.CurrMarkerIndex = -1;

                _updateRouteLines(view.Map, routeNodesOverlay.Markers);
                
                // обновление представления соответствующей кнопки
                currActiveButton = view.ButtonsList[Properties.Resources.mRemoveRouteNodeButtonName];
                currActiveButton.BackgroundImage = Properties.Resources.mRemoveRouteNodeButton;
            }
        }

        private void _activatePropertiesEditor(E_ROUTE_NODE_TYPE type)
        {
            IMainFormView view = mView;

            switch(type)
            {
                case E_ROUTE_NODE_TYPE.RNT_BUS_STATION:
                case E_ROUTE_NODE_TYPE.RNT_ENDING_BUS_STATION:

                    view.IsBusStationPropertiesActive = true;
                    view.IsCrossroadPropertiesActive = false;

                    break;
                case E_ROUTE_NODE_TYPE.RNT_CROSSROAD:

                    view.IsCrossroadPropertiesActive = true;
                    view.IsBusStationPropertiesActive = false;

                    break;
            }
        }

        private void _onNodeTypeChanged(object sender, EventArgs e)
        {
            IMainFormView view = mView;

            E_ROUTE_NODE_TYPE currType = (E_ROUTE_NODE_TYPE)view.RouteNodeTypeProperty.SelectedValue;

            // Обновление представления
            _activatePropertiesEditor(currType);

            // обновление вида маркера
            int currMarkerIndex = view.CurrMarkerIndex;

            if (currMarkerIndex < 0)
            {
                return;
            }

            GMapOverlay routeNodesOverlay = view.Map.Overlays[1];
            GMapMarker prevMarker = null;

            switch (currType)
            {
                case E_ROUTE_NODE_TYPE.RNT_BUS_STATION:
                    prevMarker = routeNodesOverlay.Markers[currMarkerIndex];
                    routeNodesOverlay.Markers[currMarkerIndex] = new GMarkerGoogle(prevMarker.Position, GMarkerGoogleType.blue_dot);
                    break;
                case E_ROUTE_NODE_TYPE.RNT_ENDING_BUS_STATION:
                    prevMarker = routeNodesOverlay.Markers[currMarkerIndex];
                    routeNodesOverlay.Markers[currMarkerIndex] = new GMarkerGoogle(prevMarker.Position, GMarkerGoogleType.red_dot);
                    break;
                case E_ROUTE_NODE_TYPE.RNT_CROSSROAD:
                    prevMarker = routeNodesOverlay.Markers[currMarkerIndex];
                    routeNodesOverlay.Markers[currMarkerIndex] = new GMarkerGoogle(prevMarker.Position, GMarkerGoogleType.yellow_dot);
                    break;
            }
            
            mView.Map.Update();   
        }

        private GMapMarker _getCurrMarker()
        {
            IMainFormView view = mView;

            GMapOverlay routeNodesOverlay = view.Map.Overlays[1];
            var markers = routeNodesOverlay.Markers;

            int currMarkerIndex = view.CurrMarkerIndex;

            if (currMarkerIndex >= 0)
            {
                return markers[currMarkerIndex];
            }

            if (routeNodesOverlay.Markers.Count == 0)
            {
                return null;
            }

            return routeNodesOverlay.Markers[markers.Count - 1];
        }

        private void _onSubmitProperties(object sender, EventArgs e)
        {
            IMainFormView view = mView;
            CMainModel model = mModel;

            CRouteNode tmpNode = null;

            E_ROUTE_NODE_TYPE currRouteNodeType = (E_ROUTE_NODE_TYPE)mView.RouteNodeTypeProperty.SelectedValue;

            int currMarkerIndex = mView.CurrMarkerIndex;
            PointLatLng currPosition = _getCurrMarker().Position;

            switch (currRouteNodeType)
            {
                case E_ROUTE_NODE_TYPE.RNT_BUS_STATION:

                    tmpNode = new CBusStationNode((uint)currMarkerIndex, view.NodeNameProperty, new TPoint2(currPosition.Lat, currPosition.Lng),
                                                  view.BusStationNumOfPassengersProperty, view.BusStationIntensityProperty, false);

                    break;
                case E_ROUTE_NODE_TYPE.RNT_ENDING_BUS_STATION:

                    tmpNode = new CBusStationNode((uint)currMarkerIndex, view.NodeNameProperty, new TPoint2(currPosition.Lat, currPosition.Lng),
                                                  view.BusStationNumOfPassengersProperty, view.BusStationIntensityProperty, true);

                    break;
                case E_ROUTE_NODE_TYPE.RNT_CROSSROAD:

                    tmpNode = new CCrossRoadNode((uint)currMarkerIndex, view.NodeNameProperty, new TPoint2(currPosition.Lat, currPosition.Lng),
                                                 view.CrossroadLoadProperty);

                    break;
            }

            model.UpdateRouteNodeByID((uint)currMarkerIndex, tmpNode);
            
            view.CurrNodeName = view.NodeNameProperty;

            StringBuilder newItemStr = new StringBuilder();
            newItemStr.AppendFormat("{0} : ({1:F3};{2:F3})", view.NodeNameProperty, currPosition.Lat, currPosition.Lng);
            view.NodesList.Items[currMarkerIndex] = newItemStr.ToString();
        }

        //ПЕРЕДЕЛАТЬ ДАННЫЙ МЕТОД
        private void _onNodeSelectionChanged(object sender, EventArgs e)
        {
            IMainFormView view = mView;
            CMainModel model = mModel;

            int currMarkerIndex = view.CurrMarkerIndex;

            CRouteNode currSelectedNode = model.CurrBusRoute.GetRouteNodeByID((uint)currMarkerIndex);

            if (currSelectedNode == null)
            {
                return;
            }

            CBusStationNode tmpBusStationNode = currSelectedNode as CBusStationNode;

            if (tmpBusStationNode != null)
            {
                mView.NodeNameProperty = tmpBusStationNode.Name;
                mView.CurrNodeName = tmpBusStationNode.Name;

                mView.RouteNodeTypeProperty.SelectedIndex = tmpBusStationNode.IsEndingStation ?
                                                            (int)E_ROUTE_NODE_TYPE.RNT_ENDING_BUS_STATION :
                                                            (int)E_ROUTE_NODE_TYPE.RNT_BUS_STATION;

                mView.BusStationNumOfPassengersProperty = tmpBusStationNode.CurrNumOfPassengers;
                mView.BusStationIntensityProperty = tmpBusStationNode.Intensity;
            }

            CCrossRoadNode tmpCrossRoadNode = currSelectedNode as CCrossRoadNode;

            if (tmpCrossRoadNode != null)
            {
                mView.NodeNameProperty = tmpCrossRoadNode.Name;
                mView.CurrNodeName = tmpCrossRoadNode.Name;
                mView.RouteNodeTypeProperty.SelectedIndex = (int)E_ROUTE_NODE_TYPE.RNT_CROSSROAD;
                mView.CrossroadLoadProperty = tmpCrossRoadNode.LoadCoefficient;
            }
        }

        private void _onSaveModelData(object sender, EventArgs e)
        {
            string connectionString = null;
            string filename = mModel.Name;

            if (filename != null)
            {
                connectionString = string.Format("Data Source = {0}; Version = 3;", filename);

                using (SQLiteConnection sqliteConnection = new SQLiteConnection(connectionString))
                {
                    mModel.SaveIntoDataBase(new SQLiteConnection(connectionString));
                }

                return;
            }

            SaveFileDialog saveDialog = mView.SaveFileDialog;

            DialogResult saveDialogCallResult = saveDialog.ShowDialog();

            if (saveDialogCallResult != DialogResult.OK)
            {
                return;
            }

            filename = saveDialog.FileName;
            mModel.Name = filename;

            if (!File.Exists(filename))
            {
                SQLiteConnection.CreateFile(filename);
            }

            connectionString = string.Format("Data Source = {0}; Version = 3;", filename);

            using (SQLiteConnection sqliteConnection = new SQLiteConnection(connectionString))
            {
                mModel.SaveIntoDataBase(new SQLiteConnection(connectionString));
            }

            mView.IsFastSaveAvailable = true;
        }

        private void _onLoadModelData(object sender, EventArgs e)
        {
            MessageBox.Show("Loading");
        }

        //private void _updateButtonView(Button button, E_CURRENT_STATE prevState, E_CURRENT_STATE newState)
        //{

        //}

        private void _updateRouteLines(GMapControl mapControl, GMap.NET.ObjectModel.ObservableCollectionThreadSafe<GMapMarker> markers)
        {
            GMapOverlay routeLinesOverlay = mapControl.Overlays[0];

            List<PointLatLng> updatedPoints = new List<PointLatLng>();

            foreach (GMapMarker marker in markers)
            {
                updatedPoints.Add(marker.Position);
            }

            GMapPolygon updatedPolyline = new GMapPolygon(updatedPoints, "RoutePolyline");

            updatedPolyline.Fill = new SolidBrush(Color.Transparent);
            updatedPolyline.Stroke = new Pen(Color.Blue, 2);

            routeLinesOverlay.Polygons.Clear();
            routeLinesOverlay.Polygons.Add(updatedPolyline);
        }

        private void _onLaunchBusEditor(object sender, EventArgs e)
        {
            BusEditor busEditorWindow = new BusEditor();

            busEditorWindow.Show();
        }

        private void _onShowStatisticsWindow(object sender, EventArgs e)
        {
            StatisticsWindow statisticsWindow = new StatisticsWindow();

            statisticsWindow.Show();
        }
        //protected override void _updateModelWithView(ref IBaseModel model, ref IBaseView view)
        //{
            
        //}

        //protected override void _updateViewWithModel(ref IBaseView view, ref IBaseModel model)
        //{

        //}

        #endregion
    }
}
