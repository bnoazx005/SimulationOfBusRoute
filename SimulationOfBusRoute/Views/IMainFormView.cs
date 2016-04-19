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
        
        string NodeNameProperty { get; set; }

        double BusStationNumOfPassengersProperty { get; set; }
        
        ComboBox RouteNodeTypeProperty { get; set; }

        string CurrNodeName { get; set; }

        Dictionary<string, Button> ButtonsList { get; set; }

        int CurrMarkerIndex { get; set; }

        string StatusLine { get; set; }

        OpenFileDialog OpenFileDialog { get; set; }

        SaveFileDialog SaveFileDialog { get; set; }

        bool IsFastSaveAvailable { get; set; }

        string StatusMessage { get; set; }

        event EventHandler OnFormInit;
        
        #region KeyboardEvents

        event EventHandler<KeyEventArgs> OnKeyPressed;

        #endregion

        #region ToolboxEvents

        event EventHandler OnRunSimulation;

        event EventHandler OnPauseSimulation;

        event EventHandler OnStopSimulation;

        event EventHandler OnAddRouteNode;

        event EventHandler OnRemoveRouteNode;

        event EventHandler OnMoveNode;

        event EventHandler OnSelectNode;

        event EventHandler OnOpenBusEditor;

        event EventHandler OnOpenStationsEditor;

        event EventHandler OnShowStatistics;

        event EventHandler OnOpenSimulationSettings;

        #endregion

        #region MapEvents

        event EventHandler OnMapZoomChanged;

        event MarkerClick OnMarkerSelected;

        event EventHandler<MouseEventArgs> OnMapMouseClick;

        #endregion

        #region PropertiesEvents

        //УДАЛИТЬ НЕНУЖНЫЕ
        event EventHandler OnNodeSelectionChanged;

        event EventHandler OnNodeTypeChanged;

        event EventHandler OnPropertiesChanged;

        event EventHandler OnSubmitProperties;

        event EventHandler OnAbortPropertiesChanges;

        #endregion

        #region MenuEvents

        event EventHandler OnClearMap;

        event EventHandler OnLoadData;

        event EventHandler OnSaveData;

        event FormClosingEventHandler OnQuit;

        event EventHandler OnCloseForm;

        event EventHandler OnAbout;

        event EventHandler OnOpenDocs;

        #endregion
    }
}
