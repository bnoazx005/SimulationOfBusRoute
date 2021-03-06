﻿using System;
using System.Windows.Forms;


namespace SimulationOfBusRoute.Views
{
    public partial class SimulationSettingsWindow : Form, ISimulationSettingsView
    {
        public SimulationSettingsWindow()
        {
            InitializeComponent();

            Load                += (sender, e) => { if (OnFormInit != null) { OnFormInit(this, EventArgs.Empty); } };
            FormClosing         += (sender, e) => { if (OnQuit != null) { OnQuit(this, e); } };

            acceptButton.Click  += (sender, e) => { if (OnAcceptChanges != null) { OnAcceptChanges(this, EventArgs.Empty); } };
            cancelButton.Click  += (sender, e) => { if (OnDeclineChanges != null) { OnDeclineChanges(this, EventArgs.Empty); } };
        }

        public event EventHandler OnAcceptChanges;
        public event EventHandler OnDeclineChanges;
        public event EventHandler OnFormInit;
        public event FormClosingEventHandler OnQuit;

        public void Display()
        {
            ShowDialog();
        }

        public void Quit()
        {
            Close();
        }

        #region Properties
                
        public TimeSpan TimeOfStart
        {
            get
            {
                return TimeSpan.Parse(timeOfStartValue.Text);
            }

            set
            {
                timeOfStartValue.Text = value.ToString();
            }
        }

        public TimeSpan TimeOfFinish
        {
            get
            {
                return TimeSpan.Parse(timeOfFinishValue.Text);
            }

            set
            {
                timeOfFinishValue.Text = value.ToString();
            }
        }

        #endregion
    }
}
