using System;
using System.Windows.Forms;
using SimulationOfBusRoute.Utils;
using GMap.NET.WindowsForms;
using System.Collections.Generic;


namespace SimulationOfBusRoute.Views
{
    public partial class MainForm : Form, IMainFormView
    {
        private Dictionary<string, Button> mButtonsList;

        public MainForm()
        {
            InitializeComponent();

            mButtonsList = Controls.GetControlsDictionaryOfType<Button>();

            //Привязывание событий к элементам интерфейса

            Load                            += (sender, e) => { if (OnFormInit != null) { OnFormInit(this, EventArgs.Empty); } };
            FormClosing                     += (sender, e) => { if (OnQuit != null) { OnQuit(this, e); } };
            KeyDown                         += (sender, e) => { if (OnKeyPressed != null) { OnKeyPressed(this, e); } };

            //menu events
            loadDataMenuItem.Click          += (sender, e) => { if (OnLoadData != null) { OnLoadData(this, EventArgs.Empty); } };
            saveDataMenuItem.Click          += (sender, e) => { if (OnSaveData != null) { OnSaveData(this, EventArgs.Empty); } };
            saveDataAsMenuItem.Click        += (sender, e) => { if (OnSaveData != null) { OnSaveData(this, EventArgs.Empty); } };
            clearRouteMenuItem.Click        += (sender, e) => { if (OnClearMap != null) { OnClearMap(this, EventArgs.Empty); } };
            quitMenuItem.Click              += (sender, e) => { if (OnCloseForm != null) { OnCloseForm(null, EventArgs.Empty); } };

            //toolbox events
            loadDataButton.Click            += (sender, e) => { if (OnLoadData != null) { OnLoadData(this, EventArgs.Empty); } };
            saveDataButton.Click            += (sender, e) => { if (OnSaveData != null) { OnSaveData(this, EventArgs.Empty); } };
            quitButton.Click                += (sender, e) => { if (OnCloseForm != null) { OnCloseForm(this, EventArgs.Empty); } };
            addRouteNodeButton.Click        += (sender, e) => { if (OnAddRouteNode != null) { OnAddRouteNode(this, EventArgs.Empty); } };
            removeRouteNodeButton.Click     += (sender, e) => { if (OnRemoveRouteNode != null) { OnRemoveRouteNode(this, EventArgs.Empty); } };
            selectNodeButton.Click          += (sender, e) => { if (OnSelectNode != null) { OnSelectNode(this, EventArgs.Empty); } };
            moveNodeButton.Click            += (sender, e) => { if (OnMoveNode != null) { OnMoveNode(this, EventArgs.Empty); } };
            busEditorButton.Click           += (sender, e) => { if (OnOpenBusEditor != null) { OnOpenBusEditor(this, EventArgs.Empty); } };
            stationsEditorButton.Click      += (sender, e) => { if (OnOpenStationsEditor != null) { OnOpenStationsEditor(this, EventArgs.Empty); } };
            simulationSettingsButton.Click  += (sender, e) => { if (OnOpenSimulationSettings != null) { OnOpenSimulationSettings(this, EventArgs.Empty); } };
            statisticsButton.Click          += (sender, e) => { if (OnShowStatistics != null) { OnShowStatistics(this, EventArgs.Empty); } };
            startSimulationButton.Click     += (sender, e) => { if (OnRunSimulation != null) { OnRunSimulation(this, EventArgs.Empty); } };
            pauseSimulationButton.Click     += (sender, e) => { if (OnPauseSimulation != null) { OnPauseSimulation(this, EventArgs.Empty); } };
            stopSimulationButton.Click      += (sender, e) => { if (OnStopSimulation != null) { OnStopSimulation(this, EventArgs.Empty); } };
            //resetSimulationButton.Click += (sender, e) => { if (On != null) { OnLoadData(this, EventArgs.Empty); } };
            clearMapButtonAlt.Click         += (sender, e) => { if (OnClearMap != null) { OnClearMap(this, EventArgs.Empty); } };
            submitChangesButton.Click       += (sender, e) => { if (OnSubmitProperties != null) { OnSubmitProperties(this, EventArgs.Empty); } };
            abortChangesButton.Click        += (sender, e) => { if (OnAbortPropertiesChanges != null) { OnAbortPropertiesChanges(this, EventArgs.Empty); } };
            abortChangesButton.Click        += (sender, e) => { if (OnAbortPropertiesChanges != null) { OnAbortPropertiesChanges(this, EventArgs.Empty); } };

            //map events
            zoomBar.Scroll                  += (sender, e) => { if (OnMapZoomChanged != null) { OnMapZoomChanged(this, EventArgs.Empty); } };
            mainMap.OnMapZoomChanged        += () => { if (OnMapZoomChanged != null) { OnMapZoomChanged(null, EventArgs.Empty); } };
            mainMap.MouseClick              += (sender, e) => { if (OnMapMouseClick != null) { OnMapMouseClick(this, e); } };
            mainMap.OnMarkerClick           += (item, e) => { if (OnMarkerSelected != null) { OnMarkerSelected(item, e); } };

            typeOfNodeProperty.SelectedIndexChanged += (sender, e) => { if (OnNodeTypeChanged != null) { OnNodeTypeChanged(this, EventArgs.Empty); } };
            routeNodesList.SelectedIndexChanged += (sender, e) => { if (OnNodeSelectionChanged != null) { OnNodeSelectionChanged(this, EventArgs.Empty); } };
        }

        public event EventHandler OnFormInit;
        
        public event EventHandler<MouseEventArgs> OnMapMouseClick;
        public event EventHandler<KeyEventArgs> OnKeyPressed;
        public event EventHandler OnAbout;
        public event EventHandler OnAddRouteNode;
        public event EventHandler OnClearMap;
        public event EventHandler OnLoadData;
        public event EventHandler OnMapZoomChanged;
        public event MarkerClick OnMarkerSelected;
        public event EventHandler OnOpenBusEditor;
        public event EventHandler OnOpenDocs;
        public event EventHandler OnPauseSimulation;
        public event EventHandler OnNodeSelectionChanged;
        public event EventHandler OnNodeTypeChanged;
        public event EventHandler OnAbortPropertiesChanges;
        public event EventHandler OnPropertiesChanged;
        public event EventHandler OnSubmitProperties;
        public event FormClosingEventHandler OnQuit;
        public event EventHandler OnCloseForm;
        public event EventHandler OnRemoveRouteNode;
        public event EventHandler OnRunSimulation;
        public event EventHandler OnSaveData;
        public event EventHandler OnShowStatistics;
        public event EventHandler OnStopSimulation;
        public event EventHandler OnMoveNode;
        public event EventHandler OnSelectNode;
        public event EventHandler OnOpenSimulationSettings;
        public event EventHandler OnOpenStationsEditor;

        public void Display()
        {
            Application.Run(this);            
        }

        public void Quit()
        {
            Close();
        }
        
        #region Properties

        public TPoint2 CurrCursorPosition
        {
            get
            {
                return new TPoint2(mainMap.Position.Lat, mainMap.Position.Lng);
            }

            set
            {
                mainMap.Position = new GMap.NET.PointLatLng(value.X, value.Y);
            }
        }

        public int MapZoomValue
        {
            get
            {
                return zoomBar.Value;
            }

            set
            {
                zoomBar.Value = value;
            }
        }

        public GMapControl Map
        {
            get
            {
                return mainMap;
            }

            set
            {
                mainMap = value;
            }
        }

        public ListBox NodesList
        {
            get
            {
                return routeNodesList;
            }

            set
            {
                routeNodesList = value;
            }
        }

        public Dictionary<string, Button> ButtonsList
        {
            get
            {
                return mButtonsList;
            }

            set
            {
                mButtonsList = value;
            }
        }

        public string NodeNameProperty
        {
            get
            {
                return nodeNameProperty.Text;
            }

            set
            {
                nodeNameProperty.Text = value;
            }
        }
        
        public bool IsPropertyActive
        {
            get
            {
                return splitContainer1.Panel2.Enabled;
            }

            set
            {
                splitContainer1.Panel2.Enabled = value;
            }
        }

        public string StatusLine
        {
            get
            {
                return statusLabel.Text;
            }

            set
            {
                statusLabel.Text = value;
            }
        }
        
        public ComboBox RouteNodeTypeProperty
        {
            get
            {
                return typeOfNodeProperty;
            }

            set
            {
                typeOfNodeProperty = value;
            }
        }

        public int CurrMarkerIndex
        {
            get
            {               
                return routeNodesList.SelectedIndex;
            }

            set
            {
                routeNodesList.SelectedIndex = value;
            }
        }
        
        public OpenFileDialog OpenFileDialog
        {
            get
            {
                return openFileDialog;
            }

            set
            {
                openFileDialog = value;
            }
        }

        public SaveFileDialog SaveFileDialog
        {
            get
            {
                return saveFileDialog;
            }

            set
            {
                saveFileDialog = value;
            }
        }

        public bool IsFastSaveAvailable
        {
            get
            {
                return saveDataMenuItem.Enabled;
            }

            set
            {
                saveDataMenuItem.Enabled = value;
            }
        }

        public string StatusMessage
        {
            get
            {
                return statusLabel.Text;
            }

            set
            {
                statusLabel.Text = value;
            }
        }

        #endregion
    }
}
