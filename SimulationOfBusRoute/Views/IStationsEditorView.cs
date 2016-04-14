using System;
using System.Windows.Forms;


namespace SimulationOfBusRoute.Views
{
    interface IStationsEditorView : IBaseView
    {
        RichTextBox TextEditor { get; set; }

        ListBox CasesList { get; set; }

        event EventHandler OnFormInit;

        event EventHandler<FormClosingEventArgs> OnQuit;
        event EventHandler<FormClosedEventArgs> OnClose;

        event EventHandler OnAddMatrix;

        event EventHandler OnRemoveMatrix;

        event EventHandler OnTimerTick;
    }
}
