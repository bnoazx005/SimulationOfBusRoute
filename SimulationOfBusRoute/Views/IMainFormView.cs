using System;
using SimulationOfBusRoute.Utils;


namespace SimulationOfBusRoute.Views
{
    public interface IMainFormView : IBaseView
    {
        TPoint2 CurrCursorPosition { get; } //положение курсора в географических координатах (широта, долгота)

        #region MouseEvents

        // event EventHandler<EventArgs> OnMouseClick;

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
