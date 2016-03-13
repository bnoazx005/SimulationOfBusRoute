﻿using System;
using System.Windows.Forms;
using SimulationOfBusRoute.Utils;
using SimulationOfBusRoute.Views;
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

            mButtonsList = new Dictionary<string, Button>();

            List<Control> buttons = new List<Control>(CControlHelper.FindControlsByType<Button>(Controls));
            
            foreach(Control control in buttons)
            {
                mButtonsList.Add(control.Name, control as Button);
            }

            //Привязывание событий к элементам интерфейса

            Load                            += (sender, e) => { if (OnFormInit != null) { OnFormInit(this, EventArgs.Empty); } };
            KeyDown                         += (sender, e) => { if (OnKeyPressed != null) { OnKeyPressed(this, e); } };

            //menu events
            loadDataMenuItem.Click          += (sender, e) => { if (OnLoadData != null) { OnLoadData(this, EventArgs.Empty); } };
            saveDataMenuItem.Click          += (sender, e) => { if (OnSaveData != null) { OnSaveData(this, EventArgs.Empty); } };
            saveDataAsMenuItem.Click        += (sender, e) => { if (OnSaveData != null) { OnSaveData(this, EventArgs.Empty); } };
            clearRouteMenuItem.Click        += (sender, e) => { if (OnClearMap != null) { OnClearMap(this, EventArgs.Empty); } };
            quitMenuItem.Click              += (sender, e) => { if (OnQuit != null) { OnQuit(this, EventArgs.Empty); } };

            //toolbox events
            loadDataButton.Click            += (sender, e) => { if (OnLoadData != null) { OnLoadData(this, EventArgs.Empty); } };
            saveDataButton.Click            += (sender, e) => { if (OnSaveData != null) { OnSaveData(this, EventArgs.Empty); } };
            quitButton.Click                += (sender, e) => { if (OnQuit != null) { OnQuit(this, EventArgs.Empty); } };
            addRouteNodeButton.Click        += (sender, e) => { if (OnAddRouteNode != null) { OnAddRouteNode(this, EventArgs.Empty); } };
            removeRouteNodeButton.Click     += (sender, e) => { if (OnRemoveRouteNode != null) { OnRemoveRouteNode(this, EventArgs.Empty); } };
            busEditorButton.Click           += (sender, e) => { if (OnOpenBusEditor != null) { OnOpenBusEditor(this, EventArgs.Empty); } };
            statisticsButton.Click          += (sender, e) => { if (OnShowStatistics != null) { OnShowStatistics(this, EventArgs.Empty); } };
            startSimulationButton.Click     += (sender, e) => { if (OnRunSimulation != null) { OnRunSimulation(this, EventArgs.Empty); } };
            pauseSimulationButton.Click     += (sender, e) => { if (OnPauseSimulation != null) { OnPauseSimulation(this, EventArgs.Empty); } };
            stopSimulationButton.Click      += (sender, e) => { if (OnStopSimulation != null) { OnStopSimulation(this, EventArgs.Empty); } };
            //resetSimulationButton.Click += (sender, e) => { if (On != null) { OnLoadData(this, EventArgs.Empty); } };
            clearMapButtonAlt.Click         += (sender, e) => { if (OnClearMap != null) { OnClearMap(this, EventArgs.Empty); } };
            submitChangesButton.Click       += (sender, e) => { if (OnSubmitProperties != null) { OnSubmitProperties(this, EventArgs.Empty); } };
            abortChangesButton.Click        += (sender, e) => { if (OnAbortPropertiesChanges != null) { OnAbortPropertiesChanges(this, EventArgs.Empty); } };

            //map events
            zoomBar.Scroll                  += (sender, e) => { if (OnMapZoomChanged != null) { OnMapZoomChanged(this, EventArgs.Empty); } };
            mainMap.OnMapZoomChanged        += () => { if (OnMapZoomChanged != null) { OnMapZoomChanged(null, EventArgs.Empty); } };
            mainMap.MouseClick              += (sender, e) => { if (OnMapMouseClick != null) { OnMapMouseClick(this, e); } };
            mainMap.OnMarkerClick           += (item, e) => { if (OnMarkerSelected != null) { OnMarkerSelected(item, e); } };

            typeOfNodeProperty.SelectedIndexChanged += (sender, e) => { if (OnNodeTypeChanged != null) { OnNodeTypeChanged(this, EventArgs.Empty); } };
            routeNodesList.SelectedIndexChanged += (sender, e) => { if (OnNodeSelectionChanged != null) { OnNodeSelectionChanged(this, EventArgs.Empty); } };
        }

        public event EventHandler<EventArgs> OnFormInit;

        public event EventHandler<MouseEventArgs> OnMapMouseClick;
        public event EventHandler<KeyEventArgs> OnKeyPressed;
        public event EventHandler<EventArgs> OnAbout;
        public event EventHandler<EventArgs> OnAddRouteNode;
        public event EventHandler<EventArgs> OnClearMap;
        public event EventHandler<EventArgs> OnLoadData;
        public event EventHandler<EventArgs> OnMapZoomChanged;
        public event MarkerClick OnMarkerSelected;
        public event EventHandler<EventArgs> OnOpenBusEditor;
        public event EventHandler<EventArgs> OnOpenDocs;
        public event EventHandler<EventArgs> OnPauseSimulation;
        public event EventHandler<EventArgs> OnNodeSelectionChanged;
        public event EventHandler<EventArgs> OnNodeTypeChanged;
        public event EventHandler<EventArgs> OnAbortPropertiesChanges;
        public event EventHandler<EventArgs> OnPropertiesChanged;
        public event EventHandler<EventArgs> OnSubmitProperties;
        public event EventHandler<EventArgs> OnQuit;
        public event EventHandler<EventArgs> OnRemoveRouteNode;
        public event EventHandler<EventArgs> OnRunSimulation;
        public event EventHandler<EventArgs> OnSaveData;
        public event EventHandler<EventArgs> OnShowStatistics;
        public event EventHandler<EventArgs> OnStopSimulation;

        public void Display()
        {
            Application.Run(this);            
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

        public ushort BusStationNumOfPassengersProperty
        {
            get
            {
                return Convert.ToUInt16(stationNumOfPassengersProperty.Value);
            }

            set
            {
                stationNumOfPassengersProperty.Value = value;
            }
        }

        public ushort BusStationIntensityProperty
        {
            get
            {
                return Convert.ToUInt16(stationIntensityProperty.Value);
            }

            set
            {
                stationIntensityProperty.Value = value;
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

        public bool IsBusStationPropertiesActive
        {
            get
            {
                return stationProperties.Visible;
            }

            set
            {
                stationProperties.Visible = value;
            }
        }

        public bool IsCrossroadPropertiesActive
        {
            get
            {
                return crossroadProperties.Visible;
            }

            set
            {
                crossroadProperties.Visible = value;
            }
        }

        public double CrossroadLoadProperty
        {
            get
            {
                return Convert.ToDouble(crossroadLoadProperty.Value);
            }

            set
            {
                crossroadLoadProperty.Value = Convert.ToDecimal(value);
            }
        }

        public string StatusLine
        {
            get
            {
                return statusInfo1.Text;
            }

            set
            {
                statusInfo1.Text = value;
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
        
        public string CurrNodeName
        {
            get
            {
                return currNodeName.Text;
            }

            set
            {
                currNodeName.Text = value;
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

        #endregion
    }
}
