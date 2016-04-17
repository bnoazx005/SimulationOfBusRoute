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
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;       //TEMP USING SHOULD BE DELETED


namespace SimulationOfBusRoute.Presenters
{
    public enum E_CURRENT_STATE
    {
        CS_EDITOR_ADD_NODE,
        CS_EDITOR_REMOVE_NODE,
        CS_EDITOR_UPDATE_NODE,

        CS_EDITOR_ADDITION_MODE,
        CS_EDITOR_REMOVE_MODE,
        CS_EDITOR_SELECTION_MODE,
        CS_EDITOR_MOVE_MODE,

        CS_SIMULATION_IS_RUNNING,
        CS_SIMULATION_IS_PAUSED,
        CS_SIMULATION_IS_STOPPED,

        CS_DEFAULT
    }

    public class CMainFormPresenter : CBasePresenter<CMainModel, IMainFormView>
    {
        //возможно стоит определить отдельный класс CSimulator или еще как-то
        //чтобы не торчало лишних методов снаружи

        private Task mSimulationJob;

        private object mJobSyncObject;

        private bool mIsSimulationPaused;
        
        private CBusEditorPresenter mBusEditorPresenter;

        private CSimulationSettingsPresenter mSimulationSettingsPresenter;

        private CDataEditorPresenter mDataEditorPresenter;

        private List<Action> mSubscribersList;

        private E_CURRENT_STATE mCurrState;

        public CMainFormPresenter(CMainModel model, IMainFormView view):
            base(model, view)
        {
            mJobSyncObject = new object();

            mIsSimulationPaused = false;

            mSubscribersList = new List<Action>();

            mBusEditorPresenter = new CBusEditorPresenter(mModel, new BusEditor());

            mSimulationSettingsPresenter = new CSimulationSettingsPresenter(mModel, new SimulationSettingsWindow());

            mDataEditorPresenter = new CDataEditorPresenter(mModel, new DataEditor());
            
            mCurrState = E_CURRENT_STATE.CS_EDITOR_SELECTION_MODE;

            mView.OnFormInit += _onFormInit;
            mView.OnQuit += _onQuit;

            //keyboard events
            mView.OnKeyPressed += _onKeyPressed;

            //toolbox events
            mView.OnAddRouteNode += _onAddRouteNode;
            mView.OnRemoveRouteNode += _onRemoveRouteNode;
            mView.OnSelectNode += _onSelectNode;
            mView.OnMoveNode += _onMoveNode;
            mView.OnOpenBusEditor += _onLaunchBusEditor;
            mView.OnOpenStationsEditor += _onLaunchDataEditor;
            mView.OnShowStatistics += _onShowStatisticsWindow;
            mView.OnRunSimulation += _onRunSimulation;
            mView.OnPauseSimulation += _onPauseSimulation;
            mView.OnOpenSimulationSettings += _onOpenSimulationSettings;

            //map events
            mView.OnMapZoomChanged += _onZoomMapChanged;
            mView.OnMarkerSelected += _onMarkerSelected;
            mView.OnMapMouseClick += _onMapMouseClick;

            //properties events
            mView.OnNodeTypeChanged += _onNodeTypeChanged;
            mView.OnSubmitProperties += _onSubmitProperties;
            mView.OnAbortPropertiesChanges += _onWritePropertiesOfNode;
            mView.OnNodeSelectionChanged += _onWritePropertiesOfNode;

            //menu events
            mView.OnLoadData += _onLoadModelData;
            mView.OnSaveData += _onSaveModelData;
            mView.OnClearMap += _onClearMap;
            mView.OnCloseForm += _onCloseForm;

            //привязка к событию изменения модели
            mModel.OnModelChanged += _onModelChanged;
            
            Application.ThreadException += _onExceptionWasCaught;
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

            _onClearMap(null, EventArgs.Empty);
            _updateViewWithModel(ref mView, ref mModel);

            _updateViewWithState(ref mView, mCurrState, mCurrState);
            
            //выбирать то окно нода какого типа активна в данный момент
            _activatePropertiesEditor((E_ROUTE_NODE_TYPE)routeNodeType.SelectedValue);
        }
        
        public void Subscribe(Action subscribersEvent)
        {
            if (subscribersEvent == null)
            {
                return;
            }

            mSubscribersList.Add(subscribersEvent);
        }

        public void Unsubscribe(Action subscribersEvent)
        {
            if (subscribersEvent == null)
            {
                return;
            }

            mSubscribersList.Remove(subscribersEvent);
        }

        private void _onKeyPressed(object sender, KeyEventArgs e)
        {
            //MessageBox.Show("Pressed" + e.KeyValue.ToString());
            // mModel.AddBusStation(TPoint2.mNullPoint, 42, 3);

            //if (e.KeyCode == Keys.C) //временное решение, будет переделано позже
            //{
            //    mView.Map.Position = new PointLatLng(56.855079, 53.239444);               
            //}

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
        
        //вызывается при закрытии формы

        private void _onQuit(object sender, FormClosingEventArgs e)
        {
            if (!mModel.IsChanged)  //данные не были изменены, можно сразу закрыть форму
            {
                e.Cancel = false;

                return;
            }
            
            DialogResult result = MessageBox.Show("Были обнаружены изменения данных. Сохранить их?", "Сохранить изменения?", MessageBoxButtons.YesNoCancel);
            
            if (result == DialogResult.Yes)
            {
                _onSaveModelData(this, EventArgs.Empty);
            }       
            else if (result == DialogResult.Cancel)
            {
                e.Cancel = true; //отмена закрытия формы

                return;
            }

            mIsRunning = false;
        }

        // провоцирует закрытие формы

        private void _onCloseForm(object sender, EventArgs e)
        {
            mView.Quit();
        }

        private void _onAddRouteNode(object sender, EventArgs e)
        {
            IMainFormView view = mView;

            if (mCurrState != E_CURRENT_STATE.CS_EDITOR_ADDITION_MODE)
            {
                _updateState(mCurrState, E_CURRENT_STATE.CS_EDITOR_ADDITION_MODE);

                view.IsPropertyActive = true;

                _onSubmitProperties(this, EventArgs.Empty); //записать данные предыдущего узла

                return;
            }

            _updateState(mCurrState, E_CURRENT_STATE.CS_EDITOR_SELECTION_MODE);
        }

        private void _onRemoveRouteNode(object sender, EventArgs e)
        {
            if (mCurrState != E_CURRENT_STATE.CS_EDITOR_REMOVE_MODE)
            {
                _updateState(mCurrState, E_CURRENT_STATE.CS_EDITOR_REMOVE_MODE);

                return;
            }

            _updateState(mCurrState, E_CURRENT_STATE.CS_EDITOR_SELECTION_MODE);
        }

        private void _onSelectNode(object sender, EventArgs e)
        {
            if (mCurrState != E_CURRENT_STATE.CS_EDITOR_SELECTION_MODE)
            {
                _updateState(mCurrState, E_CURRENT_STATE.CS_EDITOR_SELECTION_MODE);

                return;
            }

            _updateState(mCurrState, E_CURRENT_STATE.CS_EDITOR_SELECTION_MODE);
        }

        private void _onMoveNode(object sender, EventArgs e)
        {
            if (mCurrState != E_CURRENT_STATE.CS_EDITOR_MOVE_MODE)
            {
                _updateState(mCurrState, E_CURRENT_STATE.CS_EDITOR_MOVE_MODE);

                return;
            }

            _updateState(mCurrState, E_CURRENT_STATE.CS_EDITOR_SELECTION_MODE);
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

            view.IsPropertyActive = false;

            //Добавить удаление линий после удаления маркеров
            busStationsOverlay.Markers.Clear();
            routeLinesOverlay.Polygons.Clear();

            //Обновление модели
            model.ClearRoute();
            
            mCurrState = E_CURRENT_STATE.CS_EDITOR_SELECTION_MODE;
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
            PointLatLng currCoordinates;

            StringBuilder newItemStr;

            int currMarkerIndex = view.CurrMarkerIndex;

            E_ROUTE_NODE_TYPE routeNodeType = (E_ROUTE_NODE_TYPE)view.RouteNodeTypeProperty.SelectedValue;
            
            CRouteNode currNode = null;

            //добавление маркера на карту
            if ((e.Button == MouseButtons.Left) && (mCurrState == E_CURRENT_STATE.CS_EDITOR_ADDITION_MODE))
            {
                currCoordinates = map.FromLocalToLatLng(e.X, e.Y);
                
                switch (routeNodeType)
                {
                    case E_ROUTE_NODE_TYPE.RNT_BUS_STATION:
                        busStationMarker = new GMarkerGoogle(currCoordinates, GMarkerGoogleType.blue_dot);

                        currNode = new CBusStationNode((uint)(currMarkerIndex + 1), view.NodeNameProperty, false);

                        //busStationMarker = new CGMapImageMarker(currCoordinates, Properties.Resources.mAddRouteNodeButton)
                        break;
                    case E_ROUTE_NODE_TYPE.RNT_ENDING_BUS_STATION:
                        busStationMarker = new GMarkerGoogle(currCoordinates, GMarkerGoogleType.red_dot);

                        currNode = new CBusStationNode((uint)(currMarkerIndex + 1), view.NodeNameProperty, true);

                        break;
                    case E_ROUTE_NODE_TYPE.RNT_CROSSROAD:
                        busStationMarker = new GMarkerGoogle(currCoordinates, GMarkerGoogleType.yellow_dot);

                        currNode = new CCrossRoadNode((uint)(currMarkerIndex + 1), view.NodeNameProperty);

                        break;
                }

                //busStationsOverlay.Markers.Add(busStationMarker); пока оставляем, т.к, возможно, придется вернуться к этому варианту, но это мало вероятно

                busStationsOverlay.Markers.Insert(currMarkerIndex + 1, busStationMarker);
                _updateRouteLines(map, busStationsOverlay.Markers);
                
                map.Update();

                model.InsertRouteNodeByID((uint)(currMarkerIndex + 1), currNode);

                //TEMP CODE
                //Переписать в более нормальном виде
                //Генерить список по списку маркеров, чтобы было правильное упорядочивание
                newItemStr = new StringBuilder();
                newItemStr.AppendFormat("{0} : ({1:F3};{2:F3})", view.NodeNameProperty, currCoordinates.Lat, currCoordinates.Lng);
                view.NodesList.Items.Insert(currMarkerIndex + 1, newItemStr.ToString());

                //mCurrState = E_CURRENT_STATE.CS_EDITOR_UPDATE_NODE;
                view.CurrMarkerIndex = (currMarkerIndex + 1);

                view.CurrNodeName = "-";
                view.NodeNameProperty = "";
                view.RouteNodeTypeProperty.SelectedIndex = (int)E_ROUTE_NODE_TYPE.RNT_BUS_STATION;                
                view.BusStationNumOfPassengersProperty = 0;
                view.BusStationIntensityProperty = 0;
                view.CrossroadLoadProperty = 0.0;                
            }
            
            //ДОБАВИТЬ ОБНОВЛЕНИЕ МОДЕЛИ ПРИ ПЕРЕМЕЩЕНИИ МАРКЕРА И ОБНОВЛЕНИЕ ПОЛИГОНА МАРШРУТА
            if ((e.Button == MouseButtons.Left) && (mCurrState == E_CURRENT_STATE.CS_EDITOR_MOVE_MODE))
            {
                currCoordinates = map.FromLocalToLatLng(e.X, e.Y);

                busStationMarker = _getCurrMarker() as GMarkerGoogle;

                if (busStationMarker == null)
                {
                    return;
                }

                busStationMarker.Position = currCoordinates;

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
            
            if (mCurrState == E_CURRENT_STATE.CS_EDITOR_SELECTION_MODE)
            {
                view.CurrMarkerIndex = routeNodesOverlay.Markers.IndexOf(item);
            }

            if (e.Button == MouseButtons.Left && mCurrState == E_CURRENT_STATE.CS_EDITOR_REMOVE_MODE)
            {
                currMarkerIndex = routeNodesOverlay.Markers.IndexOf(item);
                routeNodesOverlay.Markers.RemoveAt(currMarkerIndex);

                //Добавить удаление сведений из модели (обновление модели)
                model.RemoveRouteNode((uint)currMarkerIndex);

                //mCurrState = E_CURRENT_STATE.CS_DEFAULT;
                
                //обновление представления
                view.NodesList.Items.RemoveAt(currMarkerIndex);
                view.CurrMarkerIndex = -1;

                _updateRouteLines(view.Map, routeNodesOverlay.Markers);                
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

            if (currMarkerIndex < 0)
            {
                return;
            }

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
        private void _onWritePropertiesOfNode(object sender, EventArgs e)
        {
            IMainFormView view = mView;
            CMainModel model = mModel;

            int currMarkerIndex = view.CurrMarkerIndex;

            CRouteNode currSelectedNode = model.GetRouteNodeByID((uint)currMarkerIndex);

            if (currSelectedNode == null)
            {
                return;
            }

            CBusStationNode tmpBusStationNode = null;
            CCrossRoadNode tmpCrossRoadNode = null;

            switch (currSelectedNode.NodeType)
            {
                case E_ROUTE_NODE_TYPE.RNT_BUS_STATION:
                case E_ROUTE_NODE_TYPE.RNT_ENDING_BUS_STATION:

                    tmpBusStationNode = currSelectedNode as CBusStationNode;

                    mView.NodeNameProperty = tmpBusStationNode.Name;
                    mView.CurrNodeName = tmpBusStationNode.Name;

                    mView.RouteNodeTypeProperty.SelectedIndex = tmpBusStationNode.IsEndingStation ?
                                                                (int)E_ROUTE_NODE_TYPE.RNT_ENDING_BUS_STATION :
                                                                (int)E_ROUTE_NODE_TYPE.RNT_BUS_STATION;

                    mView.BusStationNumOfPassengersProperty = tmpBusStationNode.CurrNumOfPassengers;
                    mView.BusStationIntensityProperty = tmpBusStationNode.Intensity;

                    break;
                case E_ROUTE_NODE_TYPE.RNT_CROSSROAD:

                    tmpCrossRoadNode = currSelectedNode as CCrossRoadNode;

                    mView.NodeNameProperty = tmpCrossRoadNode.Name;
                    mView.CurrNodeName = tmpCrossRoadNode.Name;
                    mView.RouteNodeTypeProperty.SelectedIndex = (int)E_ROUTE_NODE_TYPE.RNT_CROSSROAD;
                    mView.CrossroadLoadProperty = tmpCrossRoadNode.LoadCoefficient;

                    break;
            }
        }

        private void _onSaveModelData(object sender, EventArgs e)
        {
            string connectionString = null;
            string filename = mModel.Name;

            if (filename != null)
            {
                //выполняется в фоновом потоке

                CHelper.BackgroundModelOperation(ref mModel, "Выполняется сохранение\n данных...", () =>
                {
                    connectionString = string.Format("Data Source = {0}; Version = 3;", filename);

                    using (SQLiteConnection sqliteConnection = new SQLiteConnection(connectionString))
                    {
                        mModel.SaveIntoDataBase(sqliteConnection);
                    }
                });

                //connectionString = string.Format("Data Source = {0}; Version = 3;", filename);

                //using (SQLiteConnection sqliteConnection = new SQLiteConnection(connectionString))
                //{
                //    mModel.SaveIntoDataBase(new SQLiteConnection(connectionString));
                //}

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

            //выполняется в фоновом потоке

            CHelper.BackgroundModelOperation(ref mModel, "Выполняется сохранение\n данных...", () =>
            {
                connectionString = string.Format("Data Source = {0}; Version = 3;", filename);

                using (SQLiteConnection sqliteConnection = new SQLiteConnection(connectionString))
                {
                    mModel.SaveIntoDataBase(sqliteConnection);
                }
            });
            
            //connectionString = string.Format("Data Source = {0}; Version = 3;", filename);

            //using (SQLiteConnection sqliteConnection = new SQLiteConnection(connectionString))
            //{
            //    mModel.SaveIntoDataBase(sqliteConnection);
            //}

            mView.IsFastSaveAvailable = true;
        }

        private void _onLoadModelData(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = mView.OpenFileDialog;

            DialogResult openDialogCallResult = openFileDialog.ShowDialog();
            
            if (openDialogCallResult != DialogResult.OK)
            {
                return;
            }

            _onClearMap(null, EventArgs.Empty);

            //загрузка данных в модель

            CHelper.BackgroundModelOperation(ref mModel, "Выполняется загрузка\n данных...", () =>
            {
                string filename = openFileDialog.FileName;

                string connectionString = string.Format("Data Source = {0}; Version = 3;", filename);

                using (SQLiteConnection sqliteConnection = new SQLiteConnection(connectionString))
                {
                    mModel.LoadFromDataBase(sqliteConnection);
                }

                mModel.Name = openFileDialog.FileName;
            });

            //string filename = openFileDialog.FileName;

            //string connectionString = string.Format("Data Source = {0}; Version = 3;", filename);

            //using (SQLiteConnection sqliteConnection = new SQLiteConnection(connectionString))
            //{
            //    mModel.LoadFromDataBase(sqliteConnection);
            //}

            //mModel.Name = openFileDialog.FileName;

            mView.IsFastSaveAvailable = true;

            _updateViewWithModel(ref mView, ref mModel);
        }

        //private void _updateButtonView(Button button, E_CURRENT_STATE prevState, E_CURRENT_STATE newState)
        //{

        //}

        private void _updateRouteLines(GMapControl mapControl, GMap.NET.ObjectModel.ObservableCollectionThreadSafe<GMapMarker> markers)
        {
            if (markers.Count < 2) //если маркеров меньше двух, то линию построить невозможно
            {
                return;
            }

            GMapOverlay routeLinesOverlay = mapControl.Overlays[0];

            List<PointLatLng> updatedPoints = new List<PointLatLng>();

            foreach (GMapMarker marker in markers)
            {
                updatedPoints.Add(marker.Position);
            }

            List<GMapPolygon> polylinesList = new List<GMapPolygon>();

            int updatedPointsCount = updatedPoints.Count;

            GMapPolygon currPolyline = null;

            Brush currBrush = new SolidBrush(Color.Transparent);
            Pen currPen = new Pen(Color.Blue, 2);

            routeLinesOverlay.Polygons.Clear(); //удаление старых линий

            for (int i = 0; i < updatedPointsCount - 1; i++)
            {
                currPolyline = new GMapPolygon(updatedPoints.GetRange(i, 2), "routePolyline" + i.ToString());
                currPolyline.Fill = currBrush;
                currPolyline.Stroke = currPen;

                routeLinesOverlay.Polygons.Add(currPolyline);
            }
        }

        private void _onLaunchBusEditor(object sender, EventArgs e)
        {
            if (mBusEditorPresenter.IsRunning)
            {
                return;
            }

            mBusEditorPresenter = new CBusEditorPresenter(mModel, new BusEditor());

            //Subscribe(mBusEditorPresenter.OnModelChanged);

            mBusEditorPresenter.Run();
        }

        private void _onLaunchDataEditor(object sender, EventArgs e)
        {
            if (mDataEditorPresenter.IsRunning)
            {
                return;
            }

            mDataEditorPresenter = new CDataEditorPresenter(mModel, new DataEditor());

            Subscribe(mDataEditorPresenter.OnModelChanged);

            mDataEditorPresenter.Run();
        }

        private void _onOpenSimulationSettings(object sender, EventArgs e)
        {
            if (mSimulationSettingsPresenter.IsRunning)
            {
                return;
            }

            mSimulationSettingsPresenter = new CSimulationSettingsPresenter(mModel, new SimulationSettingsWindow());

            mSimulationSettingsPresenter.Run();
        }

        private void _onShowStatisticsWindow(object sender, EventArgs e)
        {
            //StatisticsWindow statisticsWindow = new StatisticsWindow();

            //statisticsWindow.Show();
        }

        private void _onRunSimulation(object sender, EventArgs e)
        {
            mCurrState = E_CURRENT_STATE.CS_SIMULATION_IS_RUNNING;

            uint time = 0;

            mSimulationJob = new Task(() =>
            {
                while(true)
                {
                    while (mIsSimulationPaused)
                        ;

                    Debug.WriteLine("curr time: {0}", time++);
                    Thread.Sleep(100);
                }
            });

            mSimulationJob.Start();
            
            var buttonsList = mView.ButtonsList;

            buttonsList["pauseSimulationButton"].Enabled = true;
            buttonsList["stopSimulationButton"].Enabled = true;
        }

        private void _onPauseSimulation(object sender, EventArgs e)
        {
            lock (mJobSyncObject)
            {
                mIsSimulationPaused = !mIsSimulationPaused;

                mCurrState = E_CURRENT_STATE.CS_SIMULATION_IS_PAUSED;
            }
           // mSimulationJob.Pa
        }

        private void _onStopSimulation(object sender, EventArgs e)
        {
        }

        private void _updateViewWithModel(ref IMainFormView view, ref CMainModel model)
        {
            if (!model.IsChanged)
            {
                return;
            }

            CBusRoute currRoute = model.CurrBusRoute;
            List<CRouteNode> routeNodes = currRoute.RouteNodes;
            TPoint2 tmpPoint;

            GMapControl map = view.Map;
            GMapOverlay routeNodesOverlay = map.Overlays[1];
            GMapMarker currMarker = null;
            PointLatLng currCoordinates;

            ListBox nodesList = view.NodesList;

            string newItemInList;

            int id;

            foreach (CRouteNode routeNode in routeNodes)
            {
                id = (int)routeNode.ID;

                tmpPoint = routeNode.Position;
                currCoordinates = new PointLatLng(tmpPoint.X, tmpPoint.Y);

                switch (routeNode.NodeType)
                {
                    case E_ROUTE_NODE_TYPE.RNT_BUS_STATION:
                        currMarker = new GMarkerGoogle(currCoordinates, GMarkerGoogleType.blue_dot);
                        break;
                    case E_ROUTE_NODE_TYPE.RNT_ENDING_BUS_STATION:
                        currMarker = new GMarkerGoogle(currCoordinates, GMarkerGoogleType.red_dot);
                        break;
                    case E_ROUTE_NODE_TYPE.RNT_CROSSROAD:
                        currMarker = new GMarkerGoogle(currCoordinates, GMarkerGoogleType.yellow_dot);
                        break;
                }

                routeNodesOverlay.Markers.Insert(id, currMarker);
                _updateRouteLines(map, routeNodesOverlay.Markers);

                map.Update();

                newItemInList = string.Format("{0} : ({1:F3};{2:F3})", routeNode.Name, currCoordinates.Lat, currCoordinates.Lng);
                view.NodesList.Items.Insert(id, newItemInList);

                mCurrState = E_CURRENT_STATE.CS_EDITOR_UPDATE_NODE;
                view.CurrMarkerIndex = (id);
            }

            mView.IsPropertyActive = mModel.IsChanged;
        }

        //protected override void _updateModelWithView(ref IBaseModel model, ref IBaseView view)
        //{

        //}

        private void _updateState(E_CURRENT_STATE prevState, E_CURRENT_STATE newState)
        {
            if (prevState == newState)
            {
                return;
            }

            mCurrState = newState;

            _updateViewWithState(ref mView, prevState, newState);
        }

        private void _updateViewWithState(ref IMainFormView view, E_CURRENT_STATE prevState, E_CURRENT_STATE newState)
        {
            Dictionary<string, Button> buttons = view.ButtonsList;

            switch (prevState)
            {
                case E_CURRENT_STATE.CS_EDITOR_ADDITION_MODE:
                    buttons[Properties.Resources.mAddRouteNodeButtonName].BackgroundImage = Properties.Resources.mAddNodeButton;
                    break;
                case E_CURRENT_STATE.CS_EDITOR_REMOVE_MODE:
                    buttons[Properties.Resources.mRemoveRouteNodeButtonName].BackgroundImage = Properties.Resources.mRemoveNodeButton;
                    break;
                case E_CURRENT_STATE.CS_EDITOR_MOVE_MODE:
                    buttons[Properties.Resources.mMoveNodeButtonName].BackgroundImage = Properties.Resources.mMoveNodeButton;
                    break;
                case E_CURRENT_STATE.CS_EDITOR_SELECTION_MODE:
                case E_CURRENT_STATE.CS_DEFAULT:
                    buttons[Properties.Resources.mSelectNodeButtonName].BackgroundImage = Properties.Resources.mSelectNodeButton;
                    break;
            }

            switch (newState)
            {
                case E_CURRENT_STATE.CS_EDITOR_ADDITION_MODE:
                    buttons[Properties.Resources.mAddRouteNodeButtonName].BackgroundImage = Properties.Resources.mAddNodeButtonActive;
                    mView.StatusMessage = string.Format(Properties.Resources.mStatusLabelMessage, Properties.Resources.mAddMode);
                    break;
                case E_CURRENT_STATE.CS_EDITOR_REMOVE_MODE:
                    buttons[Properties.Resources.mRemoveRouteNodeButtonName].BackgroundImage = Properties.Resources.mRemoveNodeButtonActive;
                    mView.StatusMessage = string.Format(Properties.Resources.mStatusLabelMessage, Properties.Resources.mRemoveMode);
                    break;
                case E_CURRENT_STATE.CS_EDITOR_MOVE_MODE:
                     buttons[Properties.Resources.mMoveNodeButtonName].BackgroundImage = Properties.Resources.mMoveNodeButtonActive;
                    mView.StatusMessage = string.Format(Properties.Resources.mStatusLabelMessage, Properties.Resources.mMoveMode);
                    break;
                case E_CURRENT_STATE.CS_EDITOR_SELECTION_MODE:
                case E_CURRENT_STATE.CS_DEFAULT:
                    buttons[Properties.Resources.mSelectNodeButtonName].BackgroundImage = Properties.Resources.mSelectNodeButtonActive;
                    mView.StatusMessage = string.Format(Properties.Resources.mStatusLabelMessage, Properties.Resources.mSelectionMode);
                    break;
            }
        }

        private void _onModelChanged()
        {
            Debug.WriteLine("A state of the model was changed");

            foreach (Action subscribersAction in mSubscribersList)
            {
                subscribersAction();
            }
        }

        private void _onExceptionWasCaught(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message, Properties.Resources.mErrorMessageTitle);
        }

        #endregion        
    }
}
