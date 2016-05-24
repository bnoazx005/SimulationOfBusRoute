using System;

namespace SimulationOfBusRoute.Models.Implementations
{
    public class CDataManager : CBaseModel
    {
        public event Action OnDataChanged;
        
        private CRouteNodesListStorage mRouteNodesStorage;

        private CBusesListStorage mBusesStorage;

        private COptionsList mOptionsList;

        private CBusRoute mCurrBusRoute;

        private CComputationsResults mComputationsResults;

        private bool mIsModified;

        public CDataManager():
            base(0, "DefaultDataManager")
        {
            mIsModified = false;

            RouteNodesStorage.OnChanged += _onDataStateChanged;

            //Add default params

            //int params
            OptionsList.AddIntParam(Properties.Resources.mOptionsNumOfSimulationSteps, 0);

            //string params
            OptionsList.AddStringParam(Properties.Resources.mOptionsProjectFilename, string.Empty);
            OptionsList.AddStringParam(Properties.Resources.mOptionsStartTimeOfSimulation, TimeSpan.FromHours(6.0).ToString());
            OptionsList.AddStringParam(Properties.Resources.mOptionsFinishTimeOfSimulation, TimeSpan.FromHours(23.0).ToString());
            OptionsList.AddStringParam(Properties.Resources.mOptionsStationsEditorCode, string.Empty);
            OptionsList.AddStringParam(Properties.Resources.mOptionsVelocitiesEditorCode, string.Empty);

            //bool params
        }

        #region Methods
        
        public void ResetModelData()
        {
            mRouteNodesStorage.DeleteAll();
            mBusesStorage.DeleteAll();

            if (mComputationsResults != null)
            {
                mComputationsResults.Dispose();
            }

            if (mCurrBusRoute != null)
            {
                mCurrBusRoute.Dispose();
            }
            
            if (mOptionsList != null)
            {
                mOptionsList.Dispose();
            }            

            mComputationsResults = null;
            mCurrBusRoute = null;
            mOptionsList = null;
        }

        public void ResetModelStateFlag()
        {
            mIsModified = false;
        }
        
        /// <summary>
        /// Method is called when some data was changed
        /// </summary>

        private void _onDataStateChanged()
        {
            mIsModified = true;

            if (OnDataChanged != null)
            {
                OnDataChanged();
            }
        }

        #endregion

        #region Properties

        public bool IsModified
        {
            get
            {
                return mIsModified;
            }
        }

        public CRouteNodesListStorage RouteNodesStorage
        {
            get
            {
                if (mRouteNodesStorage == null)
                {
                    mRouteNodesStorage = new CRouteNodesListStorage();
                }

                return mRouteNodesStorage;
            }
        }
        
        public CBusesListStorage BusesStorage
        {
            get
            {
                if (mBusesStorage == null)
                {
                    mBusesStorage = new CBusesListStorage();
                }

                return mBusesStorage;
            }
        }

        public COptionsList OptionsList
        {
            get
            {
                if (mOptionsList == null)
                {
                    mOptionsList = new COptionsList();
                }

                return mOptionsList;
            }

            set
            {
                mOptionsList = value;

                _onDataStateChanged();
            }
        }

        public CBusRoute CurrBusRouteObject
        {
            get
            {
                if (mCurrBusRoute == null)
                {
                    mCurrBusRoute = new CBusRoute(this);
                }

                return mCurrBusRoute;
            }
        }

        public CComputationsResults ComputationsResults
        {
            get
            {
                if (mComputationsResults == null)
                {
                    mComputationsResults = new CComputationsResults();
                }

                return mComputationsResults;
            }
        }

        #endregion
    }
}
