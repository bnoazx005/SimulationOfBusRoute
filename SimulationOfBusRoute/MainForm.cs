using System;
using System.Windows.Forms;
using SimulationOfBusRoute.Utils;
using SimulationOfBusRoute.Views;
using GMap.NET.WindowsForms;
using System.Collections.Generic;


namespace SimulationOfBusRoute
{
    public partial class MainForm : Form, IMainFormView
    {
        private Dictionary<string, Button> mButtonsList;

        public MainForm()
        {
            InitializeComponent();

            mButtonsList = new Dictionary<string, Button>();

           // Button tmpButtonUnit = null;

            //Stack<Control> currControls = new Stack<Control>();

            //foreach (Control formControl in Controls)
            //{
            //    currControls.Push(formControl);
            //}

            //foreach (Control formControl in currControls)
            //{
            //    if (formControl.HasChildren)
            //    {

            //    }

            //    if ((tmpButtonUnit = formControl as Button) != null)
            //    {
            //        mButtonsList.Add(tmpButtonUnit.Name, tmpButtonUnit);
            //    }
            //}
        }

        public event EventHandler<EventArgs> OnFormInit;

        public event EventHandler<MouseEventArgs> OnMapMouseClick;
        public event EventHandler<KeyEventArgs> OnKeyPressed;
        public event EventHandler<EventArgs> OnAbout;
        public event EventHandler<EventArgs> OnAddBusStation;
        public event EventHandler<EventArgs> OnClearMap;
        public event EventHandler<EventArgs> OnLoadBusRoute;
        public event EventHandler<EventArgs> OnMapZoomChanged;
        public event MarkerClick OnMarkerSelected;
        public event EventHandler<EventArgs> OnOpenBusEditor;
        public event EventHandler<EventArgs> OnOpenDocs;
        public event EventHandler<EventArgs> OnPauseSimulation;
        public event EventHandler<EventArgs> OnPropertiesCancel;
        public event EventHandler<EventArgs> OnPropertiesChanged;
        public event EventHandler<EventArgs> OnPropertiesSubmit;
        public event EventHandler<EventArgs> OnQuit;
        public event EventHandler<EventArgs> OnRemoveBusStation;
        public event EventHandler<EventArgs> OnRunSimulation;
        public event EventHandler<EventArgs> OnSaveBusRoute;
        public event EventHandler<EventArgs> OnShowStatistics;
        public event EventHandler<EventArgs> OnStopSimulation;

        #region Methods

        private void QuitMenuItem_Click(object sender, EventArgs e)
        {
            if (OnQuit != null)
            {
                OnQuit(this, EventArgs.Empty);
            }
        }

        private void clearRouteMenuItem_Click(object sender, EventArgs e)
        {
            if (OnClearMap != null)
            {
                OnClearMap(this, EventArgs.Empty);
            }
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            if (OnQuit != null)
            {
                OnQuit(this, EventArgs.Empty);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (OnFormInit != null)
            {
                OnFormInit(this, EventArgs.Empty);
            }
        }

        private void addStationButton_Click(object sender, EventArgs e)
        {
            if (OnAddBusStation != null)
            {
                OnAddBusStation(addStationButton, EventArgs.Empty); //ПЕРЕДЕЛАТЬ
            }
        }

        private void removeStationButton_Click(object sender, EventArgs e)
        {
            if (OnRemoveBusStation != null)
            {
                OnRemoveBusStation(removeStationButton, EventArgs.Empty); //ПЕРЕДЕЛАТЬ
            }
        }

        private void zoomBar_Scroll(object sender, EventArgs e)
        {
            if (OnMapZoomChanged != null)
            {
                OnMapZoomChanged(this, EventArgs.Empty);
            }
        }

        private void mainMap_MouseClick(object sender, MouseEventArgs e)
        {
            if (OnMapMouseClick != null)
            {
                OnMapMouseClick(this, e);
            }
        }

        private void mainMap_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            if (OnMarkerSelected != null)
            {
                OnMarkerSelected(item, e);
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (OnKeyPressed != null)
            {
                OnKeyPressed(this, e);
            }
        }

        #endregion

        #region Properties

        public TPoint2 CurrCursorPosition
        {
            get
            {
                return new TPoint2(mainMap.Position.Lat, mainMap.Position.Lng);
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

        public ListBox BusStationsList
        {
            get
            {
                return stationsList;
            }

            set
            {
                stationsList = value;
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

        #endregion
    }
}
