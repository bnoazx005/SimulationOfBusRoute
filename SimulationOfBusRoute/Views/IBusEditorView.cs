using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace SimulationOfBusRoute.Views
{
    public interface IBusEditorView : IBaseView
    {
        TableLayoutPanel BusLayoutPanel { get; set; }

        List<BusEditableItem.BusEditableItem> BusEditableNodes { get; set; }
        
        event EventHandler OnFormInit;

        event FormClosingEventHandler OnQuit;

        event EventHandler OnCloseForm;

        event EventHandler OnAddBus;

        event EventHandler OnClearBusesList;
    }
}
