using System;
using System.Windows.Forms;


namespace SimulationOfBusRoute.Views
{
    public interface ISimulationSettingsView : IBaseView
    {
        TimeSpan TimeOfStart { get; set; }

        TimeSpan TimeOfFinish { get; set; }
        
        event EventHandler OnAcceptChanges;

        event EventHandler OnDeclineChanges;

        event EventHandler OnFormInit;

        event FormClosingEventHandler OnQuit;
    }
}
