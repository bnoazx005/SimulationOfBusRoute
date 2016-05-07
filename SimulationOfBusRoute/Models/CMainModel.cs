//using MDLParser.Data;
//using SimulationOfBusRoute.Models.Interfaces;
//using SimulationOfBusRoute.Utils;
//using System;
//using System.Collections.Generic;
//using System.Data.SQLite;


//namespace SimulationOfBusRoute.Models
//{
//    //public enum E_CURRENT_STATE
//    //{
//    //    CS_EDITOR_ADD_NODE,
//    //    CS_EDITOR_REMOVE_NODE,
//    //    CS_EDITOR_UPDATE_NODE,

//    //    CS_EDITOR_ADDITION_MODE,
//    //    CS_EDITOR_REMOVE_MODE,
//    //    CS_EDITOR_SELECTION_MODE,
//    //    CS_EDITOR_MOVE_MODE,

//    //    CS_SIMULATION_IS_RUNNING,
//    //    CS_SIMULATION_IS_PAUSED,
//    //    CS_SIMULATION_IS_STOPPED,

//    //    CS_DEFAULT
//    //}


//    public class CMainModel : IBaseModel
//    {
//        private uint mIndex;

//        private string mName;
        
//        //private E_CURRENT_STATE mCurrState;

//       // private CBusRoute mCurrBusRoute;

//       // private byte mCurrNumOfEndingStations;

//        //private bool mIsChanged;

//       // public event Action OnModelChanged;

//        //private object mThreadSyncObject;

//        private uint mNumOfSimulationSteps;

//        private uint mSpeedOfSimulation;

//        private TimeSpan mStartTimeOfSimulation;

//        private TimeSpan mFinishTimeOfSimulation;

//        private CMatricesList mMatricesOfIntensitiesList;

//        private CMatricesList mBusesVelocitiesList;

//        private string mStationsEditorCode;

//        private string mBusesVelocitiesEditorCode;

//        #region Contructors

//        public CMainModel()
//        {
//            //mCurrBusRoute = new CBusRoute(0);
//            //mCurrNumOfEndingStations = 0;

//            //mIsChanged = false;

//            //mThreadSyncObject = new object();

//            mMatricesOfIntensitiesList = null;
//            mBusesVelocitiesList = null;

//            mStationsEditorCode = string.Empty;
//            mBusesVelocitiesEditorCode = string.Empty;
//    }

//        #endregion

//        #region Methods

//        //public void ClearRoute()
//        //{
//        //    CBusRoute route = mCurrBusRoute;

//        //    if (route == null)
//        //    {
//        //        return;
//        //    }

//        //    mIsChanged = route.ClearRouteNodes();

//        //    if (mIsChanged && OnModelChanged != null)
//        //    {
//        //        OnModelChanged();
//        //    }
//        //}

//        //public void InsertRouteNodeByID(uint id, CRouteNode newRouteNodeValue)
//        //{
//        //    mIsChanged = mCurrBusRoute.InsertRouteNodeByID(id, newRouteNodeValue);

//        //    if (mIsChanged && newRouteNodeValue != null && OnModelChanged != null)
//        //    {
//        //        OnModelChanged();
//        //    }
//        //}

//        //public void UpdateRouteNodeByID(uint id, CRouteNode newRouteNodeValue)
//        //{
//        //    mIsChanged = mCurrBusRoute.UpdateRouteNodeByID(id, newRouteNodeValue);

//        //    if (mIsChanged && OnModelChanged != null)
//        //    {
//        //        OnModelChanged();
//        //    }
//        //}

//        //public void RemoveRouteNode(uint id)
//        //{
//        //    mIsChanged = mCurrBusRoute.RemoveRouteNode(id);

//        //    if (mIsChanged && OnModelChanged != null)
//        //    {
//        //        OnModelChanged();
//        //    }
//        //}

//        //public CRouteNode GetRouteNodeByID(uint id)
//        //{
//        //    return mCurrBusRoute.GetRouteNodeByID(id);
//        //}

//        //public void AddBusInfo(ushort maxNumOfPassengers, uint startTime, uint alightingTimePerPassenger,
//        //                   uint boardingTimePerPassenger)
//        //{
//        //    mIsChanged = mCurrBusRoute.AddBus(maxNumOfPassengers, startTime, alightingTimePerPassenger, boardingTimePerPassenger);

//        //    if (mIsChanged && OnModelChanged != null)
//        //    {
//        //        OnModelChanged();
//        //    }
//        //}

//        //public void UpdateBusInfo(uint id, ushort maxNumOfPassengers, uint startTime, uint alightingTimePerPassenger,
//        //                          uint boardingTimePerPassenger)
//        //{
//        //    mIsChanged = mCurrBusRoute.UpdateBusInfo(id, maxNumOfPassengers, startTime, alightingTimePerPassenger, boardingTimePerPassenger);

//        //    if (mIsChanged && OnModelChanged != null)
//        //    {
//        //        OnModelChanged();
//        //    }
//        //}

//        //public void RemoveBusInfo(uint id)
//        //{
//        //    mIsChanged = mCurrBusRoute.RemoveBusInfo(id);

//        //    if (mIsChanged && OnModelChanged != null)
//        //    {
//        //        OnModelChanged();
//        //    }
//        //}

//        //public void ClearBusesInfo()
//        //{
//        //    CBusRoute route = mCurrBusRoute;

//        //    if (route == null)
//        //    {
//        //        return;
//        //    }

//        //    mIsChanged = route.ClearBusesInfo();

//        //    if (mIsChanged && OnModelChanged != null)
//        //    {
//        //        OnModelChanged();
//        //    }
//        //}

//        //public void UpdateVelocityOfSpanByIndex(int index, double velocity)
//        //{
//        //    List<CRouteNode> busStations = mCurrBusRoute.BusStationNodes;

//        //    CBusStation currBusStation = busStations[index] as CBusStation;

//        //    if (currBusStation == null)
//        //    {
//        //        //добавить обработку исключений
//        //        return;
//        //    }

//        //    currBusStation.VelocityOfSpan = velocity;

//        //    if (OnModelChanged != null)
//        //    {
//        //        OnModelChanged();
//        //    }
//        //}

//        public void LoadFromDataBase(SQLiteConnection dbConnection)
//        {
//            if (dbConnection == null)
//            {
//                throw new ArgumentNullException();
//            }

//            ClearRoute();
//            ClearBusesInfo();

//            dbConnection.Open();

//            //!!! добавить try для проверки на исключения, чтобы гарантировать загрузку данных

//            mCurrBusRoute.LoadFromDataBase(dbConnection);

//            //чтение настроек моделирования
//            using (SQLiteCommand currCommand = new SQLiteCommand(dbConnection))
//            {
//                //чтение таблицы settings
//                currCommand.CommandText = string.Format(Properties.Resources.mSQLSimpleSelectQuery, Properties.Resources.mSQLSettingsTableName);

//                SQLiteDataReader reader = currCommand.ExecuteReader();

//                string name;
//                string value;
                
//                foreach (System.Data.Common.DbDataRecord record in reader)
//                {
//                    name = (string)record["name"];
//                    value = (string)record["value"];

//                    if (name == Properties.Resources.mStartTimeOfSimulationOption)
//                    {
//                        mStartTimeOfSimulation = TimeSpan.Parse(value);
//                    }
//                    else if (name == Properties.Resources.mFinishTimeOfSimulationOption)
//                    {
//                        mFinishTimeOfSimulation = TimeSpan.Parse(value);
//                    }
//                    else if (name == Properties.Resources.mSpeedOfSimulationOption)
//                    {
//                        mSpeedOfSimulation = uint.Parse(value);
//                    }
//                }
                
//                reader.Close();

//                //чтение таблицы textData
//                currCommand.CommandText = string.Format(Properties.Resources.mSQLSimpleSelectQuery, Properties.Resources.mSQLTextDataTableName);

//                reader = currCommand.ExecuteReader();
                
//                foreach (System.Data.Common.DbDataRecord record in reader)
//                {
//                    name = (string)record["name"];
//                    value = (string)record["value"];

//                    if (name == Properties.Resources.mMatricesOfIntensitiesName)
//                    {
//                        mStationsEditorCode = value;
//                    }
//                    else if (name == Properties.Resources.mBusesVelocitiesName)
//                    {
//                        mBusesVelocitiesEditorCode = value;
//                    }
//                }

//                reader.Close();
//            }

//            mNumOfSimulationSteps = (uint)mFinishTimeOfSimulation.Subtract(mStartTimeOfSimulation).TotalSeconds;

//            dbConnection.Close();
//            dbConnection.Dispose();

//            mIsChanged = true;

//            if (OnModelChanged != null)
//            {
//                OnModelChanged();
//            }
//        }

//        public void SaveIntoDataBase(SQLiteConnection dbConnection)
//        {
//            if ((dbConnection == null) || (mCurrBusRoute == null))
//            {
//                throw new ArgumentNullException();
//            }

//            dbConnection.Open();

//            mCurrBusRoute.SaveIntoDataBase(dbConnection);

//            //сохранение настроек моделирования
//            using (SQLiteCommand currCommand = new SQLiteCommand(dbConnection))
//            {
//                currCommand.CommandText = string.Format(Properties.Resources.mSQLQueryDropTable, Properties.Resources.mSQLSettingsTableName);
//                currCommand.ExecuteNonQuery();

//                //создание таблицы settings
//                currCommand.CommandText = Properties.Resources.mSQLQueryCreateSettingsTable;
//                currCommand.ExecuteNonQuery();

//                //добавление данных в таблицу settings
//                currCommand.CommandText = Properties.Resources.mSQLQueryInsertSettings;
                
//                currCommand.Parameters.AddWithValue("@name", Properties.Resources.mStartTimeOfSimulationOption);
//                currCommand.Parameters.AddWithValue("@value", mStartTimeOfSimulation.ToString());

//                currCommand.ExecuteNonQuery();

//                currCommand.Parameters.AddWithValue("@name", Properties.Resources.mFinishTimeOfSimulationOption);
//                currCommand.Parameters.AddWithValue("@value", mFinishTimeOfSimulation.ToString());

//                currCommand.ExecuteNonQuery();

//                currCommand.Parameters.AddWithValue("@name", Properties.Resources.mSpeedOfSimulationOption);
//                currCommand.Parameters.AddWithValue("@value", mSpeedOfSimulation.ToString());

//                currCommand.ExecuteNonQuery();

//                //таблица textData
//                currCommand.CommandText = string.Format(Properties.Resources.mSQLQueryDropTable, Properties.Resources.mSQLTextDataTableName);
//                currCommand.ExecuteNonQuery();
                
//                currCommand.CommandText = Properties.Resources.mSQLCreateTextDataTable;
//                currCommand.ExecuteNonQuery();
                
//                currCommand.CommandText = Properties.Resources.mSQLQueryInsertTextData;

//                currCommand.Parameters.AddWithValue("@name", Properties.Resources.mMatricesOfIntensitiesName);
//                currCommand.Parameters.AddWithValue("@value", mStationsEditorCode);
                
//                currCommand.ExecuteNonQuery();

//                currCommand.CommandText = Properties.Resources.mSQLQueryInsertTextData;

//                currCommand.Parameters.AddWithValue("@name", Properties.Resources.mBusesVelocitiesName);
//                currCommand.Parameters.AddWithValue("@value", mBusesVelocitiesEditorCode);

//                currCommand.ExecuteNonQuery();
//            }

//            dbConnection.Close();
//            dbConnection.Dispose();

//            mIsChanged = false;
//        }

//        #endregion

//        #region Properties

//        //public uint ID
//        //{
//        //    get
//        //    {
//        //        return mIndex;
//        //    }

//        //    set
//        //    {
//        //        mIndex = value;
//        //    }
//        //}

//        //public string Name
//        //{
//        //    get
//        //    {
//        //        return mName;
//        //    }

//        //    set
//        //    {
//        //        mName = value;
//        //    }
//        //}
        
//        //public E_CURRENT_STATE CurrState
//        //{
//        //    get
//        //    {
//        //        return mCurrState;
//        //    }

//        //    set
//        //    {
//        //        mCurrState = value;
//        //    }
//        //}

//        //public CBusRoute CurrBusRoute
//        //{
//        //    get
//        //    {
//        //        return mCurrBusRoute;
//        //    }
//        //}

//        //public byte CurrNumOfEndingStations
//        //{
//        //    get
//        //    {
//        //        return mCurrNumOfEndingStations;
//        //    }

//        //    set
//        //    {
//        //        mCurrNumOfEndingStations = value;
//        //    }
//        //}

//        //public int CurrNumOfStations
//        //{
//        //    get
//        //    {
//        //        return mCurrBusRoute.NumOfBusStations;
//        //    }
//        //}

//        //public bool IsChanged
//        //{
//        //    get
//        //    {
//        //        return mIsChanged;
//        //    }

//        //    //set
//        //    //{
//        //    //    mIsChanged = value;
//        //    //}
//        //}

//        //public object ThreadSyncObject
//        //{
//        //    get
//        //    {
//        //        return mThreadSyncObject;
//        //    }

//        //    set
//        //    {
//        //        mThreadSyncObject = value;
//        //    }
//        //}

//        public uint NumOfSimulationSteps
//        {
//            get
//            {
//                return mNumOfSimulationSteps;
//            }

//            set
//            {
//                mNumOfSimulationSteps = value;
//            }
//        }

//        public uint SpeedOfSimulation
//        {
//            get
//            {
//                return mSpeedOfSimulation;
//            }

//            set
//            {
//                mSpeedOfSimulation = value;
//            }
//        }

//        public TimeSpan StartTimeOfSimulation
//        {
//            get
//            {
//                return mStartTimeOfSimulation;
//            }

//            set
//            {
//                mStartTimeOfSimulation = value;
//            }
//        }

//        public TimeSpan FinishTimeOfSimulation
//        {
//            get
//            {
//                return mFinishTimeOfSimulation;
//            }

//            set
//            {
//                mFinishTimeOfSimulation = value;
//            }
//        }

//        public CMatricesList MatricesOfIntensitiesList
//        {
//            get
//            {
//                return mMatricesOfIntensitiesList;
//            }

//            set
//            { 
//                mMatricesOfIntensitiesList = value;

//                mIsChanged = true;

//                if (OnModelChanged != null)
//                {
//                    OnModelChanged();
//                }
//            }
//        }

//        public CMatricesList BusesVelocitiesList
//        {
//            get
//            {
//                return mBusesVelocitiesList;
//            }

//            set
//            {
//                mBusesVelocitiesList = value;

//                mIsChanged = true;

//                if (OnModelChanged != null)
//                {
//                    OnModelChanged();
//                }
//            }
//        }

//        public string StationsEditorCode
//        {
//            get
//            {
//                return mStationsEditorCode;
//            }

//            set
//            {
//                mStationsEditorCode = value;
//            }
//        }

//        public string BusesVelocitiesEditorCode
//        {
//            get
//            {
//                return mBusesVelocitiesEditorCode;
//            }

//            set
//            {
//                mBusesVelocitiesEditorCode = value;
//            }
//        }

//        #endregion
//    }
//}
