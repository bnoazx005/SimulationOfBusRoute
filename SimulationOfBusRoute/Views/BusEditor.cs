using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace SimulationOfBusRoute.Views
{
    public partial class BusEditor : Form, IBusEditorView
    {
        #region Members

        private List<BusEditableItem.BusEditableItem> mBusEditableNodesList;

        #endregion

        #region Events

        public event EventHandler OnFormInit;
        public event FormClosingEventHandler OnQuit;
        public event EventHandler OnCloseForm;
        public event EventHandler OnAddBus;
        public event EventHandler OnClearBusesList;
        public event EventHandler<DataGridViewCellEventArgs> OnVelocitiesTableValueChanged;

        #endregion

        public BusEditor()
        {
            InitializeComponent();

            Load                            += (sender, e) => { if (OnFormInit != null) { OnFormInit(this, EventArgs.Empty); } };
            FormClosing                     += (sender, e) => { if (OnQuit != null) { OnQuit(this, e); } };

            //menu events
            quitMenuItem.Click              += (sender, e) => { if (OnCloseForm != null) { OnCloseForm(this, EventArgs.Empty); } };
            clearBusesListMenuItem.Click    += (sender, e) => { if (OnClearBusesList != null) { OnClearBusesList(this, EventArgs.Empty); } };

            //toolbox events
            quitButton.Click                += (sender, e) => { if (OnCloseForm != null) { OnCloseForm(this, EventArgs.Empty); } };
            addBusButton.Click              += (sender, e) => { if (OnAddBus != null) { OnAddBus(this, EventArgs.Empty); } };

            //busesVelocitiesTable.CellValueChanged += (sender, e) => { if (OnVelocitiesTableValueChanged != null) { OnVelocitiesTableValueChanged(sender, e); } };
        }
        
        public void Display()
        {
            Show();
        }

        public void Quit()
        {
            Close();
        }

        #region Properties

        public TableLayoutPanel BusLayoutPanel
        {
            get
            {
                return busLayoutPanel;
            }

            set
            {
                busLayoutPanel = value;
            }
        }

        public List<BusEditableItem.BusEditableItem> BusEditableNodes
        {
            get
            {
                return mBusEditableNodesList;
            }

            set
            {
                mBusEditableNodesList = value;
            }
        }

        //public DataGridView BusesVelocitiesTable
        //{
        //    get
        //    {
        //        return busesVelocitiesTable;
        //    }

        //    set
        //    {
        //        busesVelocitiesTable = value;
        //    }
        //}

        #endregion
       
    }
}
