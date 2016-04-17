using SimulationOfBusRoute.Models;
using SimulationOfBusRoute.Utils;
using SimulationOfBusRoute.Views;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace SimulationOfBusRoute.Presenters
{
    public class CBusEditorPresenter : CBasePresenter<CMainModel, IBusEditorView>
    {
        private static int mBaseColumn;

        private List<CVelocity> mBusesVelocitiesList;

        public CBusEditorPresenter(CMainModel model, IBusEditorView view):
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
        
        //public void OnModelChanged()
        //{
        //    if (!mIsRunning)
        //    {
        //        return;
        //    }

        //    _updateBusesVelocitiesData(mView.BusesVelocitiesTable, mModel);
        //}

        private void _onFormInit(object sender, EventArgs e)
        {
            IBusEditorView view = mView;

            view.BusEditableNodes = new List<BusEditableItem.BusEditableItem>();
                        
            _updateViewWithModel(ref mView, ref mModel);

            //привязка сделана после обновления, чтобы не гонять данные между моделью и представлением
           // mView.OnVelocitiesTableValueChanged += _onVelocitiesTableValueChanged;
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

            // обновление представления

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

            // обновление модели

            mModel.AddBusInfo(currItem.MaxNumOfPassengers, currItem.TimeInterval, currItem.AlightingTimePerPassenger, currItem.BoardingTimePerPassenger);
        }

        private void _onRemoveBus(object sender, EventArgs e)
        {
            IBusEditorView view = mView;

            BusEditableItem.BusEditableItem currItem = sender as BusEditableItem.BusEditableItem;

            // удаление из представления
            TableLayoutPanel busLayoutPanel = view.BusLayoutPanel;

            List<BusEditableItem.BusEditableItem> busEditableNodes = view.BusEditableNodes;

            //int indexOfItem = busLayoutPanel.Controls.IndexOf(currItem);
            int indexOfItem = busEditableNodes.IndexOf(currItem);

            busLayoutPanel.Controls.Remove(currItem);
            
            //busLayoutPanel.RowStyles.RemoveAt(indexOfItem);
            //busLayoutPanel.RowCount = busLayoutPanel.RowStyles.Count;

            busEditableNodes.RemoveAt(indexOfItem);

            currItem.Dispose();

            // удаление из модели

            mModel.RemoveBusInfo((uint)indexOfItem);

            int numOfItems = busEditableNodes.Count;

            for (; indexOfItem < numOfItems; indexOfItem++) //перерасчет ID для элементов в представлении и модели
            {
                busEditableNodes[indexOfItem].HeaderText = string.Format(Properties.Resources.mBusesHeaderInEditor, indexOfItem);
            }
        }

        private void _onUpdateBusItem(object sender, EventArgs e)
        {
            BusEditableItem.BusEditableItem currBusItem = sender as BusEditableItem.BusEditableItem;

            TableLayoutPanel layoutPanel = mView.BusLayoutPanel;

            uint id = (uint)layoutPanel.Controls.IndexOf(currBusItem);

            mModel.UpdateBusInfo(id, currBusItem.MaxNumOfPassengers, currBusItem.TimeInterval, currBusItem.AlightingTimePerPassenger,
                                 currBusItem.BoardingTimePerPassenger);
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

            mModel.ClearBusesInfo();
        }

        private void _updateViewWithModel(ref IBusEditorView view, ref CMainModel model)
        {
            List<BusEditableItem.BusEditableItem> busEditableNodes = view.BusEditableNodes;
            TableLayoutPanel layoutPanel = view.BusLayoutPanel;

            List<CBus> busesList = model.CurrBusRoute.Buses;
            CBus currBus = null;

            BusEditableItem.BusEditableItem currEditableItem = null;

            int busesListCount = busesList.Count;

            for (int i = 0; i < busesListCount; i++)
            {
                currBus = busesList[i];

                currEditableItem = new BusEditableItem.BusEditableItem();
                              
                currEditableItem.MaxNumOfPassengers = currBus.MaxNumOfPassengers;
                currEditableItem.TimeInterval = currBus.StartTime;
                currEditableItem.AlightingTimePerPassenger = currBus.AlightingTimePerPassenger;
                currEditableItem.BoardingTimePerPassenger = currBus.BoardingTimePerPassenger;

                currEditableItem.HeaderText = string.Format(Properties.Resources.mBusesHeaderInEditor, (int)currBus.ID);
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

            //_updateBusesVelocitiesData(view.BusesVelocitiesTable, mModel);
        }

        private void _updateBusesVelocitiesData(DataGridView table, CMainModel model)
        {
            //Подумать над изменением данного кода, чтобы можно было обновлять каждый раз, но с малыми затратами ресурсов
            if (mBusesVelocitiesList != null && mBusesVelocitiesList.Count == (model.CurrNumOfStations - 1))
            {
                return;
            }

            DataGridView busesVelocitiesTable = table;

            mBusesVelocitiesList = new List<CVelocity>();

            int currNumOfStations = model.CurrNumOfStations;
            List<CRouteNode> busStationsList = model.CurrBusRoute.BusStationNodes;

            CBusStationNode currBusStationNode = null;
            
            for (int i = 0; i < currNumOfStations - 1; i++)
            {
                currBusStationNode = busStationsList[i] as CBusStationNode;

                mBusesVelocitiesList.Add(new CVelocity(currBusStationNode.VelocityOfSpan));
            }

            busesVelocitiesTable.DataSource = mBusesVelocitiesList;

            DataGridViewColumn col = busesVelocitiesTable.Columns[0];

            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            col.ValueType = typeof(double);

            col.HeaderText = "Скорость автобусов (км./ч.)";

            DataGridViewRow currRow = null;

            for (int i = 0; i < currNumOfStations - 1; i++)
            {
                currRow = busesVelocitiesTable.Rows[i];

                currRow.HeaderCell.Value = busStationsList[i].Name + "\n->\n" + busStationsList[i + 1].Name;
            }
        }

        private void _onVelocitiesTableValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;

            if (index < 0)
            {
                return;
            }

            mModel.UpdateVelocityOfSpanByIndex(index, mBusesVelocitiesList[index].Value);
        }

        #endregion
    }
}
