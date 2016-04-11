using System;


namespace SimulationOfBusRoute.Views
{
    public interface ISimulationSettingsView : IBaseView
    {
        TimeSpan TimeOfStart { get; set; }

        TimeSpan TimeOfFinish { get; set; }

        int SpeedOfSimulationTrackBar { get; set; }

        int SpeedOfSimulation { get; set; }

        int MaxSpeedOfSimulation { get; }
        
        event EventHandler OnSpeedOfSimulationValueChanged;

        event EventHandler OnAcceptChanges;

        event EventHandler OnDeclineChanges;

        event EventHandler OnFormInit;
    }
}
