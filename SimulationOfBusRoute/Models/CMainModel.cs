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

        private object mCurrMarker;

        private E_CURRENT_STATE mCurrState;

        #region Contructors
        
        public CMainModel()
        {
            mCurrMarker = null;

            mCurrState = E_CURRENT_STATE.CS_DEFAULT;
        }

        #endregion

        #region Methods

        public void LoadFromDataBase(SQLiteConnection dbConnection)
        {

        }

        public void SaveIntoDataBase(SQLiteConnection dbConnection)
        {

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
        
        public object CurrMarker
        {
            get
            {
                return mCurrMarker;
            }

            set
            {
                //проверка на корректность типа присваиваеваемой ссылки ложится на вызывающий код
                mCurrMarker = value;
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

        #endregion
    }
}
