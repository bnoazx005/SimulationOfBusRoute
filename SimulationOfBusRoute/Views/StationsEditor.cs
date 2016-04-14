﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulationOfBusRoute.Views
{
    public partial class StationsEditor : Form, IStationsEditorView
    {
        public StationsEditor()
        {
            InitializeComponent();

            Load                        += (sender, e) => { if (OnFormInit != null) { OnFormInit(this, EventArgs.Empty); } };
            FormClosing                 += (sender, e) => { if (OnQuit != null) { OnQuit(this, e); } };

            editorTimer.Tick            += (sender, e) => { if (OnTimerTick != null) { OnTimerTick(editorTimer, EventArgs.Empty); } };

            quitButton.Click            += (sender, e) => { if (OnCloseForm != null) { OnCloseForm(null, EventArgs.Empty); } };
            addMatrixButton.Click       += (sender, e) => { if (OnAddMatrix != null) { OnAddMatrix(this, EventArgs.Empty); } };
            removeMatrixButton.Click    += (sender, e) => { if (OnRemoveMatrix != null) { OnRemoveMatrix(this, EventArgs.Empty); } };
        }

        public event EventHandler OnAddMatrix;
        public event EventHandler OnFormInit;
        public event FormClosingEventHandler OnQuit;
        public event EventHandler OnCloseForm;
        public event EventHandler OnRemoveMatrix;
        public event EventHandler OnTimerTick;

        public void Display()
        {
            Show();
        }

        public void Quit()
        {
            Close();
        }

        #region Properties

        public ListBox CasesList
        {
            get
            {
                return listOfStationsMatrices;
            }

            set
            {
                listOfStationsMatrices = value;
            }
        }

        public RichTextBox TextEditor
        {
            get
            {
                return dataEditor;
            }

            set
            {
                dataEditor = value;
            }
        }

        #endregion
    }
}