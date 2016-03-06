using System;
using SimulationOfBusRoute.Utils;
using GMap.NET.WindowsForms;
using System.Windows.Forms;
using System.Collections.Generic;


namespace SimulationOfBusRoute.Views
{
    public interface IMainFormView : IBaseView
    {
        TPoint2 CurrCursorPosition { get; set; } //положение курсора в географических координатах (широта, долгота)

        int MapZoomValue { get; set; }

        GMapControl Map { get; set; }

        ListBox NodesList { get; set; }

        bool IsPropertyActive { get; set; }

        bool IsBusStationPropertiesActive { get; set; }

        bool IsCrossroadPropertiesActive { get; set; }

        string NodeNameProperty { get; set; }

        ushort BusStationNumOfPassengersProperty { get; set; }

        ushort BusStationIntensityProperty { get; set; }

        double CrossroadLoadProperty { get; set; }

        ComboBox RouteNodeTypeProperty { get; set; }

        string CurrNodeName { get; set; }

        Dictionary<string, Button> ButtonsList { get; set; }

        int CurrMarkerIndex { get; set; }

        string StatusLine { get; set; }

        OpenFileDialog OpenFileDialog { get; set; }

        SaveFileDialog SaveFileDialog { get; set; }

        bool IsFastSaveAvailable { get; set; }

        event EventHandler<EventArgs> OnFormInit;
        
        #region KeyboardEvents

        event EventHandler<KeyEventArgs> OnKeyPressed;

        #endregion

        #region ToolboxEvents

        event EventHandler<EventArgs> OnRunSimulation;

        event EventHandler<EventArgs> OnPauseSimulation;

        event EventHandler<EventArgs> OnStopSimulation;

        event EventHandler<EventArgs> OnAddRouteNode;

        event EventHandler<EventArgs> OnRemoveRouteNode;

        event EventHandler<EventArgs> OnOpenBusEditor;

        event EventHandler<EventArgs> OnShowStatistics;

        #endregion

        #region MapEvents

        event EventHandler<EventArgs> OnMapZoomChanged;

        event MarkerClick OnMarkerSelected;

        event EventHandler<MouseEventArgs> OnMapMouseClick;

        #endregion

        #region PropertiesEvents

        //УДАЛИТЬ НЕНУЖНЫЕ
        event EventHandler<EventArgs> OnNodeSelectionChanged;

        event EventHandler<EventArgs> OnNodeTypeChanged;

        event EventHandler<EventArgs> OnPropertiesChanged;

        event EventHandler<EventArgs> OnSubmitProperties;

        event EventHandler<EventArgs> OnAbortPropertiesChanges;

        #endregion

        #region MenuEvents

        event EventHandler<EventArgs> OnClearMap;

        event EventHandler<EventArgs> OnLoadData;

        event EventHandler<EventArgs> OnSaveData;

        event EventHandler<EventArgs> OnQuit;

        event EventHandler<EventArgs> OnAbout;

        event EventHandler<EventArgs> OnOpenDocs;

        #endregion
    }
}
