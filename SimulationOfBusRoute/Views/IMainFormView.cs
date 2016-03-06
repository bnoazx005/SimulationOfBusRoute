using System;
using SimulationOfBusRoute.Utils;
using GMap.NET.WindowsForms;
using System.Windows.Forms;
using System.Collections.Generic;


namespace SimulationOfBusRoute.Views
{
    public interface IMainFormView : IBaseView
    {
        TPoint2 CurrCursorPosition { get; } //положение курсора в географических координатах (широта, долгота)

        int MapZoomValue { get; set; }

        GMapControl Map { get; set; }

        ListBox BusStationsList { get; set; }

        Dictionary<string, Button> ButtonsList { get; set; }

        event EventHandler<EventArgs> OnFormInit;

        #region MouseEvents

        event EventHandler<MouseEventArgs> OnMapMouseClick;

        #endregion

        #region KeyboardEvents

        event EventHandler<KeyEventArgs> OnKeyPressed;

        #endregion

        #region ToolboxEvents

        event EventHandler<EventArgs> OnRunSimulation;

        event EventHandler<EventArgs> OnPauseSimulation;

        event EventHandler<EventArgs> OnStopSimulation;

        event EventHandler<EventArgs> OnAddBusStation;

        event EventHandler<EventArgs> OnRemoveBusStation;

        event EventHandler<EventArgs> OnOpenBusEditor;

        event EventHandler<EventArgs> OnShowStatistics;

        #endregion

        #region MapEvents

        event EventHandler<EventArgs> OnMapZoomChanged;

        event MarkerClick OnMarkerSelected;

        #endregion

        #region PropertiesEvents

        event EventHandler<EventArgs> OnPropertiesChanged;

        event EventHandler<EventArgs> OnPropertiesSubmit;

        event EventHandler<EventArgs> OnPropertiesCancel;

        #endregion

        #region MenuEvents

        event EventHandler<EventArgs> OnClearMap;

        event EventHandler<EventArgs> OnLoadBusRoute;

        event EventHandler<EventArgs> OnSaveBusRoute;

        event EventHandler<EventArgs> OnQuit;

        event EventHandler<EventArgs> OnAbout;

        event EventHandler<EventArgs> OnOpenDocs;

        #endregion
    }
}
