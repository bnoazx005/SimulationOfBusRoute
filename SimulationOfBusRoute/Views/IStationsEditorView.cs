﻿using System;
using System.Windows.Forms;


namespace SimulationOfBusRoute.Views
{
    interface IStationsEditorView : IBaseView
    {
        RichTextBox TextEditor { get; set; }

        ListBox CasesList { get; set; }

        event EventHandler OnFormInit;

        event FormClosingEventHandler OnQuit;

        event EventHandler OnAddMatrix;

        event EventHandler OnRemoveMatrix;

        event EventHandler OnTimerTick;

        event EventHandler OnCloseForm;
    }
}
