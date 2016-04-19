using ScintillaNET;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace SimulationOfBusRoute.Views
{
    interface IDataEditorView : IBaseView
    {
        Scintilla StationsEditorHeaderText { get; set; }

        Scintilla StationsEditorText { get; set; }

        Scintilla BusVelocitiesHeaderText { get; set; }

        Scintilla BusVelocitiesEditorText { get; set; }

        bool CanRedoText { get; }

        bool CanUndoText { get; }

        //0 - stations' editor; 1 - buses' velocities editor
        int CurrSelectedEditorIndex { get; }

        Dictionary<string, Button> ButtonsList { get; set; }

        ToolStripStatusLabel MessageText { get; set; }

        event EventHandler OnFormInit;

        event FormClosingEventHandler OnQuit;
        
        event EventHandler OnTimerTick;

        event EventHandler OnCloseForm;

        event EventHandler OnUndoChanges;

        event EventHandler OnRedoChanges;

        event EventHandler OnCopyText;

        event EventHandler OnCutText;

        event EventHandler OnPasteText;

        event MouseEventHandler OnMouseButtonPressed;

        event EventHandler OnCompileData;
    }
}
