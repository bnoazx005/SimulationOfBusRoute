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
            
            Load                            += (sender, e) => { if (OnFormInit != null) { OnFormInit(this, e); } };
            FormClosing                     += (sender, e) => { if (OnQuit != null) { OnQuit(this, e); } };
            KeyDown                         += (sender, e) => { if (OnKeyPressed != null) { OnKeyPressed(this, e); } };

            //menu events
            loadDataMenuItem.Click          += (sender, e) => { if (OnLoadData != null) { OnLoadData(this, e); } };
            saveDataMenuItem.Click          += (sender, e) => { if (OnSaveData != null) { OnSaveData(this, e); } };
            saveDataAsMenuItem.Click        += (sender, e) => { if (OnSaveDataAs != null) { OnSaveDataAs(this, e); } };
            clearRouteMenuItem.Click        += (sender, e) => { if (OnClearMap != null) { OnClearMap(this, e); } };
            quitMenuItem.Click              += (sender, e) => { if (OnCloseForm != null) { OnCloseForm(null, e); } };
            openBusEditorMenuItem.Click     += (sender, e) => { if (OnOpenBusEditor != null) { OnOpenBusEditor(this, e); } };
            openDataEditorMenuItem.Click    += (sender, e) => { if (OnOpenDataEditor != null) { OnOpenDataEditor(this, e); } };
            runSimulationMenuItem.Click     += (sender, e) => { if (OnRunSimulation != null) { OnRunSimulation(this, e); } };
            showResultsMenuItem.Click       += (sender, e) => { if (OnShowResults != null) { OnShowResults(this, e); } };

            //toolbox events
            loadDataButton.Click            += (sender, e) => { if (OnLoadData != null) { OnLoadData(this, e); } };
            saveDataButton.Click            += (sender, e) => { if (OnSaveData != null) { OnSaveData(this, e); } };
            quitButton.Click                += (sender, e) => { if (OnCloseForm != null) { OnCloseForm(this, e); } };
            addRouteNodeButton.Click        += (sender, e) => { if (OnAddRouteNode != null) { OnAddRouteNode(this, e); } };
            removeRouteNodeButton.Click     += (sender, e) => { if (OnRemoveRouteNode != null) { OnRemoveRouteNode(this, e); } };
            selectNodeButton.Click          += (sender, e) => { if (OnSelectNode != null) { OnSelectNode(this, e); } };
            moveNodeButton.Click            += (sender, e) => { if (OnMoveNode != null) { OnMoveNode(this, e); } };
            busEditorButton.Click           += (sender, e) => { if (OnOpenBusEditor != null) { OnOpenBusEditor(this, e); } };
            dataEditorButton.Click          += (sender, e) => { if (OnOpenDataEditor != null) { OnOpenDataEditor(this, e); } };
            simulationSettingsButton.Click  += (sender, e) => { if (OnOpenSimulationSettings != null) { OnOpenSimulationSettings(this, e); } };
            showResultsButton.Click          += (sender, e) => { if (OnShowResults != null) { OnShowResults(this, e); } };
            startSimulationButton.Click     += (sender, e) => { if (OnRunSimulation != null) { OnRunSimulation(this, e); } };
            clearMapButtonAlt.Click         += (sender, e) => { if (OnClearMap != null) { OnClearMap(this, e); } };
            submitChangesButton.Click       += (sender, e) => { if (OnSubmitProperties != null) { OnSubmitProperties(this, EventArgs.Empty); } };
            abortChangesButton.Click        += (sender, e) => { if (OnAbortPropertiesChanges != null) { OnAbortPropertiesChanges(this, e); } };
            abortChangesButton.Click        += (sender, e) => { if (OnAbortPropertiesChanges != null) { OnAbortPropertiesChanges(this, e); } };

            //map events
            zoomBar.Scroll                  += (sender, e) => { if (OnMapZoomChanged != null) { OnMapZoomChanged(this, e); } };
            mainMap.OnMapZoomChanged        += () => { if (OnMapZoomChanged != null) { OnMapZoomChanged(null, EventArgs.Empty); } };
            mainMap.MouseClick              += (sender, e) => { if (OnMapMouseClick != null) { OnMapMouseClick(this, e); } };
            mainMap.OnMarkerClick           += (item, e) => { if (OnMarkerSelected != null) { OnMarkerSelected(item, e); } };

            typeOfNodeProperty.SelectedIndexChanged += (sender, e) => { if (OnNodeTypeChanged != null) { OnNodeTypeChanged(this, e); } };
            routeNodesList.SelectedIndexChanged     += (sender, e) => { if (OnNodeSelectionChanged != null) { OnNodeSelectionChanged(this, e); } };
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
        //public event EventHandler OnPauseSimulation;
        public event EventHandler OnNodeSelectionChanged;
        public event EventHandler OnNodeTypeChanged;
        public event EventHandler OnAbortPropertiesChanges;
        //public event EventHandler OnPropertiesChanged;
        public event EventHandler OnSubmitProperties;
        public event FormClosingEventHandler OnQuit;
        public event EventHandler OnCloseForm;
        public event EventHandler OnRemoveRouteNode;
        public event EventHandler OnRunSimulation;
        public event EventHandler OnSaveData;
        public event EventHandler OnShowResults;
        //public event EventHandler OnStopSimulation;
        public event EventHandler OnMoveNode;
        public event EventHandler OnSelectNode;
        public event EventHandler OnOpenSimulationSettings;
        public event EventHandler OnOpenDataEditor;
        public event EventHandler OnSaveDataAs;

        public void Display()
        {
            Application.Run(this);            
        }

        public void Quit()
        {
            Close();
        }
        
        #region Properties
        
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

        public bool IsFastResultsViewAvailable
        {
            get
            {
                return showResultsButton.Enabled;
            }

            set
            {
                showResultsButton.Enabled   = value;
                showResultsMenuItem.Enabled = value;
            }
        }

        #endregion
    }
}
