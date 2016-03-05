using System;
using System.Windows.Forms;
using SimulationOfBusRoute.Utils;
using SimulationOfBusRoute.Views;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;


namespace SimulationOfBusRoute
{
    public partial class MainForm : Form, IMainFormView
    {
        private GMapOverlay mMapOverlay = new GMapOverlay();

        public MainForm()
        {
            InitializeComponent();
        }

        public event EventHandler<EventArgs> OnAbout;
        public event EventHandler<EventArgs> OnAddBusStation;
        public event EventHandler<EventArgs> OnClearMap;
        public event EventHandler<EventArgs> OnLoadBusRoute;
        public event EventHandler<EventArgs> OnMapZoomChanged;
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

        private void quitButton_Click(object sender, EventArgs e)
        {
            if (OnQuit != null)
            {
                OnQuit(this, EventArgs.Empty);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            mainMap.Manager.Mode = GMap.NET.AccessMode.ServerAndCache;
            mainMap.MapProvider = YandexMapProvider.Instance;
            mainMap.SetPositionByKeywords("Russia, Izhevsk");
        }

        private void zoomBar_Scroll(object sender, EventArgs e)
        {
            if (OnMapZoomChanged != null)
            {
                OnMapZoomChanged(this, EventArgs.Empty);
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

        #endregion
    }
}
