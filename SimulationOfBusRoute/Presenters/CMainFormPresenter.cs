using System;
using System.Windows.Forms;
using SimulationOfBusRoute.Models;
using SimulationOfBusRoute.Views;
using SimulationOfBusRoute.Utils;
using GMap.NET.WindowsForms;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms.Markers;
using GMap.NET;


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
            mView.OnAddBusStation += _onAddBusStation;
            mView.OnRemoveBusStation += _onRemoveBusStation;

            //map events
            mView.OnMapZoomChanged += _onZoomMapChanged;
            mView.OnMarkerSelected += _onMarkerSelected;
            mView.OnMapMouseClick += _onMapMouseClick;

            //properties events
            //menu events
            mView.OnQuit += _onQuit;
            mView.OnClearMap += _onClearMap;
        }

        #region Methods

        private void _onFormInit(object sender, EventArgs e)
        {
            GMapControl map = mView.Map;

#if DEBUG
            map.Manager.Mode = GMap.NET.AccessMode.ServerOnly;
#else
            map.Manager.Mode = GMap.NET.AccessMode.ServerAndCache;
#endif

            map.MapProvider = YandexMapProvider.Instance;
            map.SetPositionByKeywords("Russia, Izhevsk");

            map.Overlays.Add(new GMapOverlay("Stations"));
        }

        private void _onKeyPressed(object sender, KeyEventArgs e)
        {
            //MessageBox.Show("Pressed" + e.KeyValue.ToString());
            // mModel.AddBusStation(TPoint2.mNullPoint, 42, 3);

            if (e.KeyCode == Keys.C) //временное решение, будет переделано позже
            {
                mView.Map.Position = new GMap.NET.PointLatLng(56.855079, 53.239444);
            }
        }
        
        private void _onQuit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void _onClearMap(object sender, EventArgs e)
        {
            GMapOverlay busStationsOverlay = mView.Map.Overlays[0];

            busStationsOverlay.Markers.Clear();

            mModel.CurrMarker = null;

            //удалять также все остановки внутри модели
        }

        private void _onAddBusStation(object sender, EventArgs e)
        {
            Button addBusStationButton = sender as Button;  //заменить в будущем на обращение к mView

            if (mModel.CurrState != E_CURRENT_STATE.CS_EDITOR_ADD_MARKER)
            {
                mModel.CurrState = E_CURRENT_STATE.CS_EDITOR_ADD_MARKER;

                addBusStationButton.BackgroundImage = Properties.Resources.add_station_button_active;

                return;
            }

            mModel.CurrState = E_CURRENT_STATE.CS_DEFAULT;

            addBusStationButton.BackgroundImage = Properties.Resources.add_station_button;

            //GMapControl map = mView.Map;
            //GMapOverlay mapOverlay = map.Overlays[0];

            //GMapMarker newBusStationMarker = new GMarkerGoogle(map.Position, GMarkerGoogleType.blue_dot);

            //mapOverlay.Markers.Add(newBusStationMarker);
        }

        private void _onRemoveBusStation(object sender, EventArgs e)
        {
            Button removeBusStationButton = sender as Button;  //заменить в будущем на обращение к mView

            if (mModel.CurrState != E_CURRENT_STATE.CS_EDITOR_REMOVE_MARKER)
            {
                mModel.CurrState = E_CURRENT_STATE.CS_EDITOR_REMOVE_MARKER;

                removeBusStationButton.BackgroundImage = Properties.Resources.remove_station_button_active;

                return;
            }

            mModel.CurrState = E_CURRENT_STATE.CS_DEFAULT;

            removeBusStationButton.BackgroundImage = Properties.Resources.remove_station_button;
        }

        private void _onZoomMapChanged(object sender, EventArgs e)
        {
            GMapControl map = mView.Map;

            map.Zoom = map.MinZoom + mView.MapZoomValue;
        }

        private void _onMapMouseClick(object sender, MouseEventArgs e)
        {
            GMapControl map = mView.Map;
            GMapOverlay busStationsOverlay = map.Overlays[0];

            GMapMarker newBusStationMarker = null;
            PointLatLng currCorrdinates;

            //ЗАСТАВИТЬ ОБНОВЛЯТЬСЯ КНОПКИ ПОСЛЕ ЗАВЕРШЕНИЯ СОБЫТИЯ

            if ((e.Button == MouseButtons.Left) && (mModel.CurrState == E_CURRENT_STATE.CS_EDITOR_ADD_MARKER))
            {
                currCorrdinates = map.FromLocalToLatLng(e.X, e.Y);

                newBusStationMarker = new GMarkerGoogle(currCorrdinates, GMarkerGoogleType.blue_dot);

                busStationsOverlay.Markers.Add(newBusStationMarker);
                map.Update();

                mModel.CurrState = E_CURRENT_STATE.CS_EDITOR_UPDATE_MARKER;
                mModel.CurrMarker = newBusStationMarker;
            }
        }

        private void _onMarkerSelected(GMapMarker item, MouseEventArgs e)
        {
            if (item == null)
            {
                throw new ArgumentNullException("The argument equals null", "item");
            }

            if (mModel.CurrState == E_CURRENT_STATE.CS_DEFAULT)
            {
                mModel.CurrState = E_CURRENT_STATE.CS_EDITOR_UPDATE_MARKER;
                mModel.CurrMarker = item;
            }

            GMapOverlay busStationsOverlay = mView.Map.Overlays[0];

            if (e.Button == MouseButtons.Left && mModel.CurrState == E_CURRENT_STATE.CS_EDITOR_REMOVE_MARKER)
            {
                busStationsOverlay.Markers.Remove(item);

                //Добавить удаление сведений из модели

                mModel.CurrState = E_CURRENT_STATE.CS_DEFAULT;
                mModel.CurrMarker = null;
            }
        }

        #endregion
    }
}
