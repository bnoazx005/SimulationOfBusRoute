using System;
using System.Data.SQLite;


namespace SimulationOfBusRoute.Models
{
    public enum E_CURRENT_STATE
    {
        CS_EDITOR_ADD_MARKER,
        CS_EDITOR_REMOVE_MARKER,
        CS_EDITOR_UPDATE_MARKER,

        CS_SIMULATION_IS_RUNNING,
        CS_SIMULATION_IS_PAUSED,
        CS_SIMULATION_IS_STOPPED,

        CS_DEFAULT
    }


    public class CMainModel : IBaseModel
    {
        private uint mIndex;

        private string mName;
        
        private E_CURRENT_STATE mCurrState;

        private CBusRoute mCurrBusRoute;

        private byte mCurrNumOfEndingStations;

        private bool mIsChanged;

        #region Contructors
        
        public CMainModel()
        {
            mCurrBusRoute = new CBusRoute(0);
            mCurrNumOfEndingStations = 0;

            mIsChanged = false;

            mCurrState = E_CURRENT_STATE.CS_DEFAULT;
        }

        #endregion

        #region Methods

        public void ClearRoute()
        {
            CBusRoute route = mCurrBusRoute;

            if (route == null)
            {
                return;
            }

            route.Clear();

            mIsChanged = true;
        }

        public void UpdateRouteNodeByID(uint id, CRouteNode newRouteNodeValue)
        {
            mCurrBusRoute.UpdateRouteNodeByID(id, newRouteNodeValue);

            mIsChanged = true;
        }

        public void LoadFromDataBase(SQLiteConnection dbConnection)
        {
            throw new NotImplementedException("LoadFromDataBase method was called, but it's not implemented yet");
            
            mIsChanged = true;
        }

        public void SaveIntoDataBase(SQLiteConnection dbConnection)
        {
            if (dbConnection == null)
            {
                throw new ArgumentNullException();
            }

            dbConnection.Open();

            mCurrBusRoute.SaveIntoDataBase(dbConnection);

            dbConnection.Close();
            dbConnection.Dispose();

            mIsChanged = false;
        }

        #endregion

        #region Properties

        public uint ID
        {
            get
            {
                return mIndex;
            }

            set
            {
                mIndex = value;
            }
        }

        public string Name
        {
            get
            {
                return mName;
            }

            set
            {
                mName = value;
            }
        }
        
        public E_CURRENT_STATE CurrState
        {
            get
            {
                return mCurrState;
            }

            set
            {
                mCurrState = value;
            }
        }

        public CBusRoute CurrBusRoute
        {
            get
            {
                return mCurrBusRoute;
            }

            set
            {
                mCurrBusRoute = value;
            }
        }

        public byte CurrNumOfEndingStations
        {
            get
            {
                return mCurrNumOfEndingStations;
            }

            set
            {
                mCurrNumOfEndingStations = value;
            }
        }
        public bool IsChanged
        {
            get
            {
                return mIsChanged;
            }

            //set
            //{
            //    mIsChanged = value;
            //}
        }

        #endregion
    }
}
