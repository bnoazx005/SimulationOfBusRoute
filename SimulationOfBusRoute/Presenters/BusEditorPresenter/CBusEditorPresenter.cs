using SimulationOfBusRoute.Models.Implementations;
using SimulationOfBusRoute.Views;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace SimulationOfBusRoute.Presenters.BusEditorPresenter
{
    public class CBusEditorPresenter : CBasePresenter<CDataManager, IBusEditorView>
    {
        private static int mBaseColumn;
        
        public CBusEditorPresenter(CDataManager model, IBusEditorView view):
            base(model, view)
        {
            mBaseColumn = 0;
            
            mView.OnFormInit += _onFormInit;
            mView.OnQuit += _onQuit;

            //toolbox events
            mView.OnClearBusesList += _onClearBusesList;
            mView.OnAddBus += _onAddBus;
            mView.OnCloseForm += _onCloseForm;
        }

        #region Methods
        
        private void _onFormInit(object sender, EventArgs e)
        {
            IBusEditorView view = mView;

            view.BusEditableNodes = new List<BusEditableItem.BusEditableItem>();
                        
            _updateViewWithModel(ref mView, ref mModel);
        }

        private void _onQuit(object sender, FormClosingEventArgs e)
        {
            mIsRunning = false;
        }

        private void _onCloseForm(object sender, EventArgs e)
        {
            mView.Quit();
        }

        private void _onAddBus(object sender, EventArgs e)
        {
            IBusEditorView view = mView;

            //Updating the view
            TableLayoutPanel busLayoutPanel = view.BusLayoutPanel;

            List<BusEditableItem.BusEditableItem> busEditableNodes = view.BusEditableNodes;

            busEditableNodes.Add(new BusEditableItem.BusEditableItem());
            int numOfItems = busEditableNodes.Count;

            BusEditableItem.BusEditableItem currItem = busEditableNodes[numOfItems - 1];

            currItem.HeaderText = string.Format(Properties.Resources.mBusesHeaderInEditor, numOfItems - 1);
            currItem.OnDeleteButtonClick += _onRemoveBus;
            currItem.OnChanged += _onUpdateBusItem;

            int rowIndex = busLayoutPanel.RowStyles.Count;

            if (numOfItems > 1)
            {
                busLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                busLayoutPanel.RowCount = ++rowIndex;
            }

            busLayoutPanel.Controls.Add(currItem, mBaseColumn, rowIndex - 1);

            //Updating the model
            CBusesListStorage busesStorage = mModel.BusesStorage;

            busesStorage.Insert(new CBus(0, "Bus", currItem.MaxNumOfPassengers, currItem.AlightingTimePerPassenger,
                                         currItem.BoardingTimePerPassenger, currItem.TimeOfStart));
        }

        private void _onRemoveBus(object sender, EventArgs e)
        {
            IBusEditorView view = mView;

            BusEditableItem.BusEditableItem currItem = sender as BusEditableItem.BusEditableItem;

            //removing the view element, which represents bus
            TableLayoutPanel busLayoutPanel = view.BusLayoutPanel;

            List<BusEditableItem.BusEditableItem> busEditableNodes = view.BusEditableNodes;

            int indexOfItem = busEditableNodes.IndexOf(currItem);

            busLayoutPanel.Controls.Remove(currItem);

            //busLayoutPanel.RowStyles.RemoveAt(indexOfItem);
            //busLayoutPanel.RowCount = busLayoutPanel.RowStyles.Count;

            busEditableNodes.RemoveAt(indexOfItem);

            currItem.Dispose();

            // remove entity which identifier equals to indexOfItem
            
            CBusesListStorage busesStorage = mModel.BusesStorage;
            busesStorage.Delete(busesStorage.GetById(indexOfItem));

            int numOfItems = busEditableNodes.Count;

            for (; indexOfItem < numOfItems; indexOfItem++) //recompute ID for view's elements
            {
                busEditableNodes[indexOfItem].HeaderText = string.Format(Properties.Resources.mBusesHeaderInEditor, indexOfItem);
            }
        }

        private void _onUpdateBusItem(object sender, EventArgs e)
        {
            BusEditableItem.BusEditableItem currBusItem = sender as BusEditableItem.BusEditableItem;

            TableLayoutPanel layoutPanel = mView.BusLayoutPanel;

            int id = layoutPanel.Controls.IndexOf(currBusItem);

            CBus busEntity = mModel.BusesStorage.GetById(id);

            busEntity.MaxBusCapacity = currBusItem.MaxNumOfPassengers;
            busEntity.TimeOfStart = currBusItem.TimeOfStart;
            busEntity.AlightingTimePerPassenger = currBusItem.AlightingTimePerPassenger;
            busEntity.BoardingTimePerPassenger = currBusItem.BoardingTimePerPassenger;
        }

        private void _onClearBusesList(object sender, EventArgs e)
        {
            IBusEditorView view = mView;

            TableLayoutPanel busLayoutPanel = view.BusLayoutPanel;

            List<BusEditableItem.BusEditableItem> busEditableNodes = view.BusEditableNodes;

            busLayoutPanel.RowStyles.Clear();

            busLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            busLayoutPanel.RowCount = 1;

            busLayoutPanel.Controls.Clear();

            busEditableNodes.Clear();

            //updating the model
            mModel.BusesStorage.DeleteAll();
        }

        private void _updateViewWithModel(ref IBusEditorView view, ref CDataManager model)
        {
            List<BusEditableItem.BusEditableItem> busEditableNodes = view.BusEditableNodes;
            TableLayoutPanel layoutPanel = view.BusLayoutPanel;

            List<CBus> busesList = model.BusesStorage.GetAll();
            CBus currBus = null;

            BusEditableItem.BusEditableItem currEditableItem = null;

            int busesListCount = busesList.Count;

            for (int i = 0; i < busesListCount; i++)
            {
                currBus = busesList[i];

                currEditableItem = new BusEditableItem.BusEditableItem();

                currEditableItem.MaxNumOfPassengers = currBus.MaxBusCapacity;
                currEditableItem.TimeOfStart = currBus.TimeOfStart;
                currEditableItem.AlightingTimePerPassenger = currBus.AlightingTimePerPassenger;
                currEditableItem.BoardingTimePerPassenger = currBus.BoardingTimePerPassenger;

                currEditableItem.HeaderText = string.Format(Properties.Resources.mBusesHeaderInEditor, currBus.ID);
                currEditableItem.OnDeleteButtonClick += _onRemoveBus;
                currEditableItem.OnChanged += _onUpdateBusItem;

                busEditableNodes.Add(currEditableItem);

                if (i > 0)
                {
                    layoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                    layoutPanel.RowCount = layoutPanel.RowStyles.Count;
                }

                layoutPanel.Controls.Add(currEditableItem, mBaseColumn, i);
            }
        }

        #endregion
    }
}
