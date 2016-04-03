using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace SimulationOfBusRoute.Views
{
    public interface IBusEditorView : IBaseView
    {
        TableLayoutPanel BusLayoutPanel { get; set; }

        List<BusEditableItem.BusEditableItem> BusEditableNodes { get; set; }

        DataGridView BusesVelocitiesTable { get; set; }

        event EventHandler OnFormInit;

        event EventHandler OnQuit;

        event EventHandler OnAddBus;

        event EventHandler OnClearBusesList;

        event EventHandler<DataGridViewCellEventArgs> OnVelocitiesTableValueChanged;
    }
}
