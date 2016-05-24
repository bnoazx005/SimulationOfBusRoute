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
    }
}
