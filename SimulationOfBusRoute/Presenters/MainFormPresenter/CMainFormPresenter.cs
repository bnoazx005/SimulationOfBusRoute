using System;
using System.Windows.Forms;
using SimulationOfBusRoute.Views;
using GMap.NET.WindowsForms;
using GMap.NET.MapProviders;
using GMap.NET;
using System.Collections.Generic;
using SimulationOfBusRoute.Utils;
using SimulationOfBusRoute.Models.Implementations;
using NLog;
using GMap.NET.WindowsForms.Markers;
using System.Drawing;
using SimulationOfBusRoute.Presenters.BusEditorPresenter;
using SimulationOfBusRoute.Presenters.SimulationSettingsPresenter;
using SimulationOfBusRoute.Presenters.DataEditorPresenter;
using SimulationOfBusRoute.Presenters.StatisticsViewerPresenter;


namespace SimulationOfBusRoute.Presenters.MainFormPresenter
{
    public class CMainFormPresenter : CBasePresenter<CDataManager, IMainFormView>
    {                
        private CBusEditorPresenter mBusEditorPresenter;

        private CSimulationSettingsPresenter mSimulationSettingsPresenter;

        private CDataEditorPresenter mDataEditorPresenter;

        private CStatisticsViewerPresenter mStatisticsViewerPresenter;

        private List<Action> mSubscribersList;
        
        private CMainFormState mCurrState;

        private CMainFormSelectNodeState mSelectNodeState;

        private CMainFormAddNodeState mAddNodeState;

        private CMainFormRemoveNodeState mRemoveNodeState;

        private CMainFormMoveNodeState mMoveNodeState;

        private CMainFormComputationsState mComputationsState;

        private static Logger mClassLogger;
        
        public CMainFormPresenter(CDataManager model, IMainFormView view):
            base(model, view)
        {
            mSubscribersList = new List<Action>();

            mBusEditorPresenter = new CBusEditorPresenter(mModel, new BusEditor());

            mSimulationSettingsPresenter = new CSimulationSettingsPresenter(mModel, new SimulationSettingsWindow());

            mDataEditorPresenter = new CDataEditorPresenter(mModel, new DataEditor());

            mStatisticsViewerPresenter = new CStatisticsViewerPresenter(mModel, new StatisticsViewer());
            
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
            mView.OnOpenDataEditor += _onLaunchDataEditor;
            mView.OnShowResults += _onShowStatistics;
            mView.OnRunSimulation += _onRunSimulation;
            //mView.OnPauseSimulation += _onPauseSimulation;
            mView.OnOpenSimulationSettings += _onOpenSimulationSettings;

            //map events
            mView.OnMapZoomChanged += _onZoomMapChanged;
            mView.OnMarkerSelected += _onMarkerSelected;
            mView.OnMapMouseClick += _onMapMouseClick;

            //properties events
            mView.OnNodeTypeChanged += _onNodeTypeChanged;
            mView.OnSubmitProperties += _onSubmitProperties;
            mView.OnAbortPropertiesChanges += _onUpdateNodeProperties;
            mView.OnNodeSelectionChanged += _onUpdateNodeProperties;

            //menu events
            mView.OnLoadData   += _onLoadModelData;
            mView.OnSaveData   += _onSaveModelData;
            mView.OnSaveDataAs += _onSaveModelDataAs;
            mView.OnClearMap   += _onClearMap;
            mView.OnCloseForm  += _onCloseForm;
            mView.OnAbout      += _onShowAbout;
            mView.OnOpenDocs   += _onOpenDocs;

            //привязка к событию изменения модели
            mModel.OnDataChanged += _onModelChanged;

            //States' initialization
            mSelectNodeState = new CMainFormSelectNodeState(this);

            mSelectNodeState.OnNeedSubmitProperties += _onSubmitProperties;
            mSelectNodeState.OnNeedUpdateRouteLines += _updateRouteLines;

            mAddNodeState = new CMainFormAddNodeState(this);

            mAddNodeState.OnNeedSubmitProperties += _onSubmitProperties;
            mAddNodeState.OnNeedUpdateRouteLines += _updateRouteLines;

            mRemoveNodeState = new CMainFormRemoveNodeState(this);

            mRemoveNodeState.OnNeedSubmitProperties += _onSubmitProperties;
            mRemoveNodeState.OnNeedUpdateRouteLines += _updateRouteLines;

            mMoveNodeState = new CMainFormMoveNodeState(this);

            mMoveNodeState.OnNeedSubmitProperties += _onSubmitProperties;
            mMoveNodeState.OnNeedUpdateRouteLines += _updateRouteLines;
            mMoveNodeState.OnNeedGetCurrMarker += _getCurrMarker;

            mComputationsState = new CMainFormComputationsState(this);

            mComputationsState.OnNeedSubmitProperties += _onSubmitProperties;
            mComputationsState.OnNeedUpdateRouteLines += _updateRouteLines;
            
            mCurrState = mSelectNodeState;

            mClassLogger = LogManager.GetCurrentClassLogger();
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
            
            ComboBox routeNodeType = mView.RouteNodeTypeProperty;

            //привязка перечисления типов узлов к элементу Combobox
            routeNodeType.DisplayMember = "Key";
            routeNodeType.ValueMember = "Value";
            routeNodeType.DataSource = typeof(CRouteNode.E_ROUTE_NODE_TYPE).ToDescriptionsList();
 
            _onClearMap(null, EventArgs.Empty);

            _updateViewWithModel(ref mView, ref mModel);

            mClassLogger.Info("Main form was sucessfully initialized");
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

        public void SetState(CMainFormState state)
        {
            if (state == null)
            {
                throw new ArgumentNullException("state", "A null state is impossible");
            }

            mCurrState = state;
        }

        private void _onKeyPressed(object sender, KeyEventArgs e)
        {
            //MessageBox.Show("Pressed" + e.KeyValue.ToString());
            // mModel.AddBusStation(TPoint2.mNullPoint, 42, 3);

            //if (e.KeyCode == Keys.C) //временное решение, будет переделано позже
            //{
            //    mView.Map.Position = new PointLatLng(56.855079, 53.239444);               
            //}
            
            if (e.KeyCode == Keys.D1 && e.Control)
            {
                mCurrState.SelectNodeMode();
            }

            if (e.KeyCode == Keys.D2 && e.Control)
            {
                mCurrState.AddNodeMode();
            }

            if (e.KeyCode == Keys.D3 && e.Control)
            {
                mCurrState.RemoveNodeMode();
            }

            if (e.KeyCode == Keys.D4 && e.Control)
            {
                mCurrState.MoveNodeMode();
            }
        }
        
        //вызывается при закрытии формы
        private void _onQuit(object sender, FormClosingEventArgs e)
        {
            if (!mModel.IsModified)  //data wasn't changed, we can close this window
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
                e.Cancel = true; //cancellation of the form's closing

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
            mCurrState.AddNodeMode();
        }

        private void _onRemoveRouteNode(object sender, EventArgs e)
        {
            mCurrState.RemoveNodeMode();
        }

        private void _onSelectNode(object sender, EventArgs e)
        {
            mCurrState.SelectNodeMode();
        }

        private void _onMoveNode(object sender, EventArgs e)
        {
            mCurrState.MoveNodeMode();
        }

        private void _onClearMap(object sender, EventArgs e)
        {
            IMainFormView view = mView;
            CDataManager model = mModel;

            GMapOverlay busStationsOverlay = view.Map.Overlays[1];
            GMapOverlay routeLinesOverlay = view.Map.Overlays[0];

            //Updating the view
            view.CurrMarkerIndex = -1;

            view.NodesList.Items.Clear();

            view.IsPropertyActive = false;
            
            busStationsOverlay.Markers.Clear();
            routeLinesOverlay.Routes.Clear();

            //Update the model
            model.RouteNodesStorage.DeleteAll();

            mCurrState.SelectNodeMode();
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
            mCurrState.OnMapMouseClick(sender, e);
        }

        private void _onMarkerSelected(GMapMarker item, MouseEventArgs e)
        {
            mCurrState.OnMarkerSelected(item, e);
        }

        private void _onNodeTypeChanged(object sender, EventArgs e)
        {
            IMainFormView view = mView;

            CRouteNode.E_ROUTE_NODE_TYPE currType = (CRouteNode.E_ROUTE_NODE_TYPE)view.RouteNodeTypeProperty.SelectedValue;
            
            //Updating the marker's view
            int currMarkerIndex = view.CurrMarkerIndex;

            if (currMarkerIndex < 0)
            {
                return;
            }

            GMapOverlay routeNodesOverlay = view.Map.Overlays[1];
            GMapMarker  lastUpdatedMarker = routeNodesOverlay.Markers[currMarkerIndex];

            switch (currType)
            {
                case CRouteNode.E_ROUTE_NODE_TYPE.RNT_INITIAL_BUS_STATION:
                    routeNodesOverlay.Markers[currMarkerIndex] = new GMarkerGoogle(lastUpdatedMarker.Position, GMarkerGoogleType.red_dot);
                    break;

                case CRouteNode.E_ROUTE_NODE_TYPE.RNT_BUS_STATION:
                    routeNodesOverlay.Markers[currMarkerIndex] = new GMarkerGoogle(lastUpdatedMarker.Position, GMarkerGoogleType.blue_dot);
                    break;

                case CRouteNode.E_ROUTE_NODE_TYPE.RNT_FINAL_BUS_STATION:
                    routeNodesOverlay.Markers[currMarkerIndex] = new GMarkerGoogle(lastUpdatedMarker.Position, GMarkerGoogleType.red_dot);
                    break;

                case CRouteNode.E_ROUTE_NODE_TYPE.RNT_UTILITY:
                    routeNodesOverlay.Markers[currMarkerIndex] = new GMarkerGoogle(lastUpdatedMarker.Position, GMarkerGoogleType.yellow_dot);
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
            CDataManager model = mModel;
            
            CRouteNode.E_ROUTE_NODE_TYPE currRouteNodeType = (CRouteNode.E_ROUTE_NODE_TYPE)mView.RouteNodeTypeProperty.SelectedValue;

            int currMarkerIndex = mView.CurrMarkerIndex;

            if (currMarkerIndex < 0)
            {
                return;
            }

            PointLatLng currPosition = _getCurrMarker().Position;

            CRouteNodesListStorage routeNodesStorage = model.RouteNodesStorage;

            CRouteNode currNode = routeNodesStorage.GetById(currMarkerIndex);

            if (currNode == null)
            {
                mClassLogger.Error("currCode equals to null in _onSubmitProperties() method", currPosition, currMarkerIndex);

                throw new ArgumentNullException("currNode");
            }

            //Node's type hasn't changed, just update its values
            if (currRouteNodeType == currNode.NodeType)
            {
                currNode.Name = view.NodeNameProperty;
                currNode.Position = currPosition;

                view.NodesList.Items[currMarkerIndex] = string.Format("{0} : ({1:F3};{2:F3})", view.NodeNameProperty, currPosition.Lat, currPosition.Lng);

                return;
            }

            switch (currRouteNodeType)
            {
                case CRouteNode.E_ROUTE_NODE_TYPE.RNT_INITIAL_BUS_STATION:
                    currNode = new CBusStation(CBusStation.E_BUS_STATION_TYPE.BST_INITIAL, currNode.ID, view.NodeNameProperty, currPosition);
                    break;

                case CRouteNode.E_ROUTE_NODE_TYPE.RNT_BUS_STATION:
                    currNode = new CBusStation(CBusStation.E_BUS_STATION_TYPE.BST_DEFAULT, currNode.ID, view.NodeNameProperty, currPosition);
                    break;

                case CRouteNode.E_ROUTE_NODE_TYPE.RNT_FINAL_BUS_STATION:
                    currNode = new CBusStation(CBusStation.E_BUS_STATION_TYPE.BST_FINAL, currNode.ID, view.NodeNameProperty, currPosition);
                    break;

                case CRouteNode.E_ROUTE_NODE_TYPE.RNT_UTILITY:
                    currNode = new CUtilityNode(currNode.ID, view.NodeNameProperty, currPosition);
                    break;
            }

            routeNodesStorage.Update(currNode);
            
            view.NodesList.Items[currMarkerIndex] = string.Format("{0} : ({1:F3};{2:F3})", view.NodeNameProperty, currPosition.Lat, currPosition.Lng);         
        }
        
        private void _onUpdateNodeProperties(object sender, EventArgs e)
        {
            IMainFormView view = mView;
            CDataManager model = mModel;

            int currMarkerIndex = view.CurrMarkerIndex;

            CRouteNode currSelectedNode = model.RouteNodesStorage.GetById(currMarkerIndex);

            if (currSelectedNode == null)
            {
                return;
            }
            
            string nodeName = currSelectedNode.Name;

            view.NodeNameProperty = nodeName;
            view.RouteNodeTypeProperty.SelectedIndex = (int)currSelectedNode.NodeType;            
        }

        private void _onSaveModelData(object sender, EventArgs e)
        {
            COptionsList options = mModel.OptionsList;

            string filename = options.GetStringParam("ProjectFilename");

            if (filename == null || filename == string.Empty)
            {
                _onSaveModelDataAs(sender, e);

                return;
            }

            //save all data in background mode
            CBackgroundJobHelper.BackgroundModelOperation(ref mModel, "Выполняется сохранение\n данных...", () =>
            {
                mModel.SaveIntoFile(filename);
            });
        }

        private void _onSaveModelDataAs(object sender, EventArgs e)
        {
            COptionsList options = mModel.OptionsList;
            
            SaveFileDialog saveDialog = mView.SaveFileDialog;

            DialogResult saveDialogCallResult = saveDialog.ShowDialog();

            if (saveDialogCallResult != DialogResult.OK)
            {
                return;
            }

            string filename = saveDialog.FileName;

            options.AddStringParam(Properties.Resources.mOptionsProjectFilename, filename);

            //save all data in background mode
            CBackgroundJobHelper.BackgroundModelOperation(ref mModel, "Выполняется сохранение\n данных...", () =>
            {
                mModel.SaveIntoFile(filename);
            });

            mView.IsFastSaveAvailable = true;
        }

        private void _onLoadModelData(object sender, EventArgs e)
        {
            if (mModel.IsModified)
            {
                DialogResult messageBoxResult = MessageBox.Show(Properties.Resources.mPreLoadSaveMessage,
                                                                Properties.Resources.mWarningMessageTitle,
                                                                MessageBoxButtons.YesNoCancel);

                if (messageBoxResult == DialogResult.Yes)
                {
                    _onSaveModelData(null, EventArgs.Empty);
                }
                else if (messageBoxResult == DialogResult.Cancel)
                {
                    return;
                }
            }

            IMainFormView view = mView;

            OpenFileDialog openFileDialog = view.OpenFileDialog;

            DialogResult openDialogCallResult = openFileDialog.ShowDialog();

            if (openDialogCallResult != DialogResult.OK)
            {
                return;
            }

            _onClearMap(null, EventArgs.Empty);
            mModel.BusesStorage.DeleteAll();

            //Loading the data
            string filename = openFileDialog.FileName;

            CBackgroundJobHelper.BackgroundModelOperation(ref mModel, "Выполняется загрузка\n данных...", () =>
            {
                mModel.LoadFromFile(filename);
            });

            mModel.Name = openFileDialog.FileName;
            
            view.IsFastSaveAvailable = true;
            view.IsFastResultsViewAvailable = false;

            mModel.ComputationsResults.ClearData();

            _updateViewWithModel(ref view, ref mModel);
        }

        private void _onLaunchBusEditor(object sender, EventArgs e)
        {
            if (mBusEditorPresenter.IsRunning)
            {
                return;
            }

            mBusEditorPresenter = new CBusEditorPresenter(mModel, new BusEditor());

            Subscribe(mBusEditorPresenter.OnModelChanged);

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

        private void _onShowStatistics(object sender, EventArgs e)
        {
            mStatisticsViewerPresenter = new CStatisticsViewerPresenter(mModel, new StatisticsViewer());

            mStatisticsViewerPresenter.Run();
        }

        private void _onRunSimulation(object sender, EventArgs e)
        {
            mCurrState.ComputationsMode();

            mModel.ComputationsResults.ClearData();
            
            try
            {
                mModel.CurrBusRouteObject.Build(mView.Map.Overlays[0].Routes);
            }
            catch (Exception exception)
            {
                Application.OnThreadException(exception);
                return;
            }
            
            if (mStatisticsViewerPresenter.IsRunning)
            {
                return;
            }

            //_optimize();

            mStatisticsViewerPresenter = new CStatisticsViewerPresenter(mModel, new StatisticsViewer());
            mStatisticsViewerPresenter.Run();

            SetState(mSelectNodeState);

            mView.IsFastResultsViewAvailable = true;
        }
        
        private void _updateViewWithModel(ref IMainFormView view, ref CDataManager model)
        {
            if (!model.IsModified)
            {
                return;
            }
            
            GMapControl map = view.Map;
            GMapOverlay routeNodesOverlay = map.Overlays[1];
            GMapMarker currMarker = null;
            PointLatLng currCoordinates;

            ListBox nodesList = view.NodesList;
            
            int id;

            CRouteNodesListStorage routeNodesStorage = model.RouteNodesStorage;

            foreach (CRouteNode routeNode in routeNodesStorage.GetAll())
            {
                currCoordinates = routeNode.Position;

                id = routeNode.ID;

                switch (routeNode.NodeType)
                {                    
                    case CRouteNode.E_ROUTE_NODE_TYPE.RNT_INITIAL_BUS_STATION:
                    case CRouteNode.E_ROUTE_NODE_TYPE.RNT_FINAL_BUS_STATION:
                        currMarker = new GMarkerGoogle(currCoordinates, GMarkerGoogleType.red_dot);
                        break;

                    case CRouteNode.E_ROUTE_NODE_TYPE.RNT_BUS_STATION:
                        currMarker = new GMarkerGoogle(currCoordinates, GMarkerGoogleType.blue_dot);
                        break;

                    case CRouteNode.E_ROUTE_NODE_TYPE.RNT_UTILITY:
                        currMarker = new GMarkerGoogle(currCoordinates, GMarkerGoogleType.yellow_dot);
                        break;
                }

                routeNodesOverlay.Markers.Insert(id, currMarker);
                _updateRouteLines(map, routeNodesOverlay.Markers);

                map.Update();
                
                view.NodesList.Items.Insert(id, string.Format("{0} : ({1:F3};{2:F3})", routeNode.Name, currCoordinates.Lat, currCoordinates.Lng));                
                view.CurrMarkerIndex = id;
            }

            mCurrState = mSelectNodeState;
        }

        private void _onModelChanged()
        {
            mClassLogger.Debug("A state of the model was changed");
            
            foreach (Action subscribersAction in mSubscribersList)
            {
                subscribersAction();
            }
        }

        private void _updateRouteLines(GMapControl mapControl, GMap.NET.ObjectModel.ObservableCollectionThreadSafe<GMapMarker> markers)
        {
            if (markers.Count < 2) // It's impossible to construct route if there are no at least two points in the list
            {
                return;
            }

            GMapOverlay routeLinesOverlay = mapControl.Overlays[0];

            List<PointLatLng> updatedPoints = new List<PointLatLng>();

            foreach (GMapMarker marker in markers)
            {
                updatedPoints.Add(marker.Position);
            }

            List<PointLatLng> routeList = new List<PointLatLng>();

            int updatedPointsCount = updatedPoints.Count;

            GMapRoute currRoute = null;

            routeLinesOverlay.Routes.Clear(); //remove old routes

            for (int i = 0; i < updatedPointsCount - 1; i++)
            {
                currRoute = new GMapRoute(updatedPoints.GetRange(i, 2), "span " + i.ToString());
                currRoute.Stroke.Width = 2;
                currRoute.Stroke.Color = Color.Blue;

                routeLinesOverlay.Routes.Add(currRoute);
            }

            //a closuring of route
            routeList.Add(updatedPoints[updatedPointsCount - 1]);
            routeList.Add(updatedPoints[0]);

            currRoute = new GMapRoute(routeList, "end");
            currRoute.Stroke.Width = 2;
            currRoute.Stroke.Color = Color.Blue;

            routeLinesOverlay.Routes.Add(currRoute);
        }

        private void _onShowAbout(object sender, EventArgs e)
        {
            Help.ShowHelp(sender as Control, Properties.Resources.mHelpSource, HelpNavigator.Topic, "/About.htm");
        }

        private void _onOpenDocs(object sender, EventArgs e)
        {
            Help.ShowHelp(sender as Control, Properties.Resources.mHelpSource, HelpNavigator.Topic, "/MainWindowInterface.htm");
        }

        #endregion

        public CMainFormSelectNodeState SelectNodeState
        {
            get
            {
                return mSelectNodeState;
            }
        }

        public CMainFormAddNodeState AddNodeState
        {
            get
            {
                return mAddNodeState;
            }
        }

        public CMainFormRemoveNodeState RemoveNodeState
        {
            get
            {
                return mRemoveNodeState;
            }
        }

        public CMainFormMoveNodeState MoveNodeState
        {
            get
            {
                return mMoveNodeState;
            }
        }

        public CMainFormComputationsState ComputationsState
        {
            get
            {
                return mComputationsState;
            }
        }


        //Random mRandomGenerator = new Random();

        //private void _optimize()
        //{
        //    const int numOfBuses = 17;
        //    const int interval = 15;
        //    const int numOfExperiments = 4;

        //    CTimer timer = new CTimer(0, 1);

        //    int numOfSteps = mModel.OptionsList.GetIntParam(Properties.Resources.mOptionsNumOfSimulationSteps);

        //    foreach (CBusStation station in mModel.CurrBusRouteObject.BusStationsList)
        //    {
        //        timer.Subscribe(station);
        //        station.OnGetData += _onStation;
        //    }

        //    var buses = mModel.BusesStorage;

        //    int iterations = 0;
        //    uint[][] v = new uint[numOfExperiments][];
        //    int[] f = new int[numOfExperiments];

        //    for (int i = 0; i < numOfExperiments; i++)
        //    {
        //        buses.DeleteAll();

        //        uint rand = 0;
                
        //        v[i] = new uint[numOfBuses];

        //        for (int j = 0; j < numOfBuses; j++)
        //        {
        //            rand = (uint)mRandomGenerator.Next((int)rand, (int)rand + interval);
        //            buses.Insert(new CBus(j, "Bus" + j, 50, 1, 2, rand));

        //            v[i][j] = rand;
        //        }

        //        mModel.CurrBusRouteObject.Build(mView.Map.Overlays[0].Routes);

        //        foreach (CBus bus in buses.GetAll())
        //        {
        //            timer.Subscribe(bus);
        //            bus.OnGetData += _onBus;
        //        }

        //        timer.Reset();

        //        while (timer.CurrTime < numOfSteps)
        //        {
        //            timer.Tick();
        //        }

        //        uint max = 0;

        //        foreach (TStationTableEntity e in mModel.ComputationsResults.StationsRecords)
        //        {
        //            if (max < e.CurrNumOfPassengers)
        //            {
        //                max = e.CurrNumOfPassengers;
        //            }
        //        }

        //        f[i] = (int)max;

        //        if (f[i] <= 15)
        //        {
        //            MessageBox.Show("I found your solution");
        //            return;
        //        }

        //        mModel.ComputationsResults.ClearData();

        //        foreach (CBus bus in buses.GetAll())
        //        {
        //            timer.Unsubscribe(bus);
        //            bus.OnGetData -= _onBus;
        //        }
        //    }

        //    uint[][] temp = new uint[numOfExperiments][];

        //    while (iterations < 25)
        //    {
        //        double[] l = new double[numOfExperiments];

        //        double sum = 0.0;

        //        foreach (uint fit in f)
        //        {
        //            sum += 1.0 / fit;
        //        }

        //        double last = 0.0;

        //        for (int i = 0; i < numOfExperiments; i++)
        //        {
        //            l[i] = last + ((1.0 / f[i]) / sum);
        //            last = l[i];
        //        }

        //        //creating of new population

        //        for (int i = 0; i < numOfExperiments; i++)
        //        {
        //            int p1 = 0;
        //            int p2 = 0;
        //            int counter = 0;

        //            while (p1 == p2 && _areSame(v[p1], v[p2]))
        //            {
        //                p1 = _getIndex(l, mRandomGenerator.NextDouble());
        //                p2 = _getIndex(l, mRandomGenerator.NextDouble());

        //                if (++counter > numOfExperiments * numOfExperiments)
        //                {
        //                    break;
        //                }
        //            }

        //            temp[i] = _breed(v[p1], p1, v[p2], p2);
        //        }

        //        for (int i = 0; i < numOfExperiments; i++)
        //        {
        //            v[i] = temp[i];
        //        }

        //        //recompute fintness function
        //        for (int i = 0; i < numOfExperiments; i++)
        //        {
        //            buses.DeleteAll();

        //            uint rand = 0;

        //            //int numOfBuses = 16/*mRandomGenerator.Next(1, 39)*/;

        //            v[i] = new uint[numOfBuses];

        //            for (int j = 0; j < numOfBuses; j++)
        //            {
        //                rand = (uint)mRandomGenerator.Next((int)rand, (int)rand + interval);
        //                buses.Insert(new CBus(j, "Bus" + j, 50, 1, 2, rand));

        //                v[i][j] = rand;
        //            }

        //            mModel.CurrBusRouteObject.Build(mView.Map.Overlays[0].Routes);

        //            foreach (CBus bus in buses.GetAll())
        //            {
        //                timer.Subscribe(bus);
        //                bus.OnGetData += _onBus;
        //            }

        //            timer.Reset();

        //            while (timer.CurrTime < numOfSteps)
        //            {
        //                timer.Tick();
        //            }

        //            uint max = 0;

        //            foreach (TStationTableEntity e in mModel.ComputationsResults.StationsRecords)
        //            {
        //                if (max < e.CurrNumOfPassengers)
        //                {
        //                    max = e.CurrNumOfPassengers;
        //                }
        //            }

        //            f[i] = (int)max;

        //            if (f[i] <= 15)
        //            {
        //                MessageBox.Show("I found your solution");
        //                break;
        //            }

        //            mModel.ComputationsResults.ClearData();

        //            foreach (CBus bus in buses.GetAll())
        //            {
        //                timer.Unsubscribe(bus);
        //                bus.OnGetData -= _onBus;
        //            }
        //        }

        //        iterations++;
        //    }
        //    ;
        //}

        //private uint[] _breed(uint[] p1Gene, int p1, uint[] p2Gene, int p2)
        //{
        //    //if (p1Gene.Length > p2Gene.Length)
        //    //{
        //    //    return _breedC1(p1Gene, p1, p2Gene, p2);
        //    //}
        //    //else if (p1Gene.Length < p2Gene.Length)
        //    //{
        //    //    return _breedC2(p1Gene, p1, p2Gene, p2);
        //    //}

        //    return _breedC3(p1Gene, p1, p2Gene, p2);
        //}

        ////private uint[] _breedC1(uint[] p1Gene, int p1, uint[] p2Gene, int p2)
        ////{
        ////    int length = p1Gene.Length;

        ////    int crossover = mRandomGenerator.Next(0, length);
        ////    int first = mRandomGenerator.Next(0, 100);

        ////    uint[] child = null;

        ////    if (first < 50)
        ////    {
        ////        child = new uint[length];
        ////        Array.Copy(p1Gene, child, length);

        ////        for (int i = crossover; i < length; i++)
        ////        {
        ////            if (i < p2Gene.Length)
        ////            {
        ////                child[i] = p2Gene[i];
        ////            }

        ////            if ((mRandomGenerator.Next(0, 100) < 15 && i != 0) || i >= p2Gene.Length)
        ////            {
        ////                child[i] = (uint)mRandomGenerator.Next(0, 360);
        ////            }
        ////        }
        ////    }
        ////    else
        ////    {
        ////        child = new uint[p2Gene.Length];
        ////        Array.Copy(p2Gene, child, p2Gene.Length);

        ////        crossover = mRandomGenerator.Next(0, p2Gene.Length);

        ////        for (int i = crossover; i < child.Length; i++)
        ////        {
        ////            child[i] = p1Gene[i];

        ////            if (mRandomGenerator.Next(0, 100) < 15 && i != 0)
        ////            {
        ////                child[i] = (uint)mRandomGenerator.Next(0, 360);
        ////            }
        ////        }
        ////    }

        ////    return child;
        ////}

        ////private uint[] _breedC2(uint[] p1Gene, int p1, uint[] p2Gene, int p2)
        ////{
        ////    int length = p2Gene.Length;

        ////    int crossover = mRandomGenerator.Next(0, length) + 1;
        ////    int first = mRandomGenerator.Next(0, 100);

        ////    uint[] child = null;

        ////    if (first < 50)
        ////    {
        ////        child = new uint[p1Gene.Length];
        ////        Array.Copy(p1Gene, child, p1Gene.Length);

        ////        crossover = mRandomGenerator.Next(0, p1Gene.Length);

        ////        for (int i = crossover; i < p1Gene.Length; i++)
        ////        {
        ////            child[i] = p2Gene[i];

        ////            if (mRandomGenerator.Next(0, 100) < 15 && i != 0)
        ////            {
        ////                child[i] = (uint)mRandomGenerator.Next(0, 360);
        ////            }
        ////        }
        ////    }
        ////    else
        ////    {
        ////        child = new uint[length];
        ////        Array.Copy(p2Gene, child, length);

        ////        for (int i = crossover; i < child.Length; i++)
        ////        {
        ////            if (i < p1Gene.Length)
        ////            {
        ////                child[i] = p1Gene[i];
        ////            }

        ////            if ((mRandomGenerator.Next(0, 100) < 15 && i != 0) || i >= p1Gene.Length)
        ////            {
        ////                child[i] = (uint)mRandomGenerator.Next(0, 360);
        ////            }
        ////        }
        ////    }

        ////    return child;
        ////}

        //private uint[] _breedC3(uint[] p1Gene, int p1, uint[] p2Gene, int p2)
        //{
        //    int length = p1Gene.Length;

        //    int crossover = mRandomGenerator.Next(0, length / 2 + 1);
        //    int first = mRandomGenerator.Next(0, 100);

        //    uint[] child = new uint[length];
        //    Array.Copy(p1Gene, child, length);

        //    int initial = 0;
        //    int final = length;

        //    if (first < 50)
        //    {
        //        initial = crossover;
        //    }
        //    else
        //    {
        //        final = crossover;
        //    }

        //    for (int i = initial; i < final; i++)
        //    {
        //        child[i] = p2Gene[i];

        //        if (mRandomGenerator.Next(0, 100) < 5)
        //        {
        //            int max = Math.Max((int)p1Gene[i], (int)p2Gene[i]);
        //            int min = Math.Min((int)p1Gene[i], (int)p2Gene[i]);

        //            child[i] = (uint)mRandomGenerator.Next(min, max);
        //        }
        //    }

        //    return child;
        //}

        //private bool _areSame(uint[] l1, uint[] l2)
        //{
        //    if (l1.Length != l2.Length)
        //    {
        //        return false;
        //    }

        //    for (int i = 0; i < l1.Length; i++)
        //    {
        //        if (l1[i] != l2[i])
        //        {
        //            return false;
        //        }
        //    }

        //    return true;
        //}

        //private int _getIndex(double[] f, double value)
        //{
        //    double last = 0.0;

        //    for (int i = 0; i < f.Length; i++)
        //    {
        //        if ((last < value || Math.Abs(last - value) < 1e-6) && (value < f[i] || Math.Abs(f[i] - value) < 1e-6))
        //        {
        //            return i;
        //        }
        //        else
        //        {
        //            last = f[i];
        //        }
        //    }

        //    return f.Length - 1;
        //}

        //private void _onBus(CBus bus)
        //{
        //    mModel.ComputationsResults.BusesRecords.Add(bus.ToTableEntity());
        //}

        //private void _onStation(CBusStation station)
        //{
        //    mModel.ComputationsResults.StationsRecords.Add(station.ToTableEntity());
        //}
    }
}
