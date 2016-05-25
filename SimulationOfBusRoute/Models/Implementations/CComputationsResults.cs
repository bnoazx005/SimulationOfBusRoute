using SimulationOfBusRoute.Models.Implementations.Bus;
using System;
using System.ComponentModel;


namespace SimulationOfBusRoute.Models.Implementations
{ 
    public class CComputationsResults: CBaseModel, IDisposable
    {
        private BindingList<TBusTableEntity> mBusesRecords;

        private BindingList<TStationTableEntity> mStationsRecords;

        public CComputationsResults():
            base(0, "DefaultResults")
        {
        }

        public void Dispose()
        {
            if (mBusesRecords != null)
            {
                mBusesRecords.Clear();
            }

            if (mStationsRecords != null)
            {
                mStationsRecords.Clear();
            }

            GC.SuppressFinalize(this);
        }

        public void ClearData()
        {
            if (mBusesRecords != null)
            {
                mBusesRecords.Clear();
            }

            if (mStationsRecords != null)
            {
                mStationsRecords.Clear();
            }
        }

        public BindingList<TBusTableEntity> BusesRecords
        {
            get
            {
                if (mBusesRecords == null)
                {
                    mBusesRecords = new BindingList<TBusTableEntity>();
                }
                
                return mBusesRecords;
            }
        }

        public BindingList<TStationTableEntity> StationsRecords
        {
            get
            {
                if (mStationsRecords == null)
                {
                    mStationsRecords = new BindingList<TStationTableEntity>();
                }

                return mStationsRecords;
            }
        }

        public bool IsEmpty
        {
            get
            {
                if (mBusesRecords == null && mStationsRecords == null)
                {
                    return true;
                }
                else if ((mBusesRecords != null && mBusesRecords.Count > 0) || (mStationsRecords != null && mStationsRecords.Count > 0))
                {
                    return false;
                }

                return mBusesRecords.Count == 0 && mStationsRecords.Count == 0;
            }
        }
    }
}
