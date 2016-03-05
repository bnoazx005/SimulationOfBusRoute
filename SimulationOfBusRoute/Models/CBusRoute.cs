using SimulationOfBusRoute.Utils;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;


namespace SimulationOfBusRoute.Models
{
    public class CBusRoute : IBaseModel
    {
        private uint mIndex;

        private string mName;

        private List<CBus> mBuses;

        private List<CBusStation> mBusStations;

        public CBusRoute(uint id) //конструктор использует дефолтные значения
        {
            mIndex = id;
        }

        public CBusRoute(uint id, CBus[] buses, CBusStation[] stations)
        {
            mIndex = id;

            if (buses == null)
            {
                throw new ArgumentNullException("The array \"buses\" is empty or uninitialized");
            }

            if (stations == null)
            {
                throw new ArgumentNullException("The array \"stations\" is empty or uninitialized");
            }

            mBuses = new List<CBus>(buses);
            mBusStations = new List<CBusStation>(stations);
        }

        #region Methods

        public void AddBus(uint startStationIndex, ushort maxNumOfPassengers)
        {
            if (startStationIndex < mBusStations.Count)
            {
                throw new ArgumentException("Incorrect value of the parameter", "startStationIndex");
            }

            uint newBusID = Convert.ToUInt32(mBuses.Count + 1);

            //отладочная информация
            Debug.Assert(startStationIndex < mBusStations.Count);
            Debug.Assert(newBusID > mBuses.Count);

            mBuses.Add(new CBus(newBusID, startStationIndex, mBusStations[(int)startStationIndex].Position, maxNumOfPassengers));
        }

        public void AddBusStation(TPoint2 position, ushort startNumOfPassengers, uint intensity)
        {
            uint newBusStationID = Convert.ToUInt32(mBusStations.Count + 1);

            //отладочная информация
            Debug.Assert(newBusStationID > mBusStations.Count);

            mBusStations.Add(new CBusStation(newBusStationID, position, startNumOfPassengers, intensity));
        }

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

        #endregion
    }
}
