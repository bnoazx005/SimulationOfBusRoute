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

        private List<CRouteNode> mRouteNodes;

        public CBusRoute(uint id) //конструктор использует дефолтные значения
        {
            mIndex = id;
            mName = "Route" + id.ToString();

            mBuses = new List<CBus>();
            mRouteNodes = new List<CRouteNode>();
        }

        public CBusRoute(uint id, CBus[] buses, CRouteNode[] routeNodes)
        {
            mIndex = id;

            if (buses == null)
            {
                throw new ArgumentNullException("The array \"buses\" is empty or uninitialized");
            }

            if (routeNodes == null)
            {
                throw new ArgumentNullException("The array \"stations\" is empty or uninitialized");
            }

            mBuses = new List<CBus>(buses);
            mRouteNodes = new List<CRouteNode>(routeNodes);
        }

        #region Methods

        public void AddBus(uint startStationIndex, ushort maxNumOfPassengers)
        {
            if (startStationIndex < mRouteNodes.Count)
            {
                throw new ArgumentException("Incorrect value of the parameter", "startStationIndex");
            }

            uint newBusID = Convert.ToUInt32(mBuses.Count + 1);

            //отладочная информация
            Debug.Assert(startStationIndex < mRouteNodes.Count);
            Debug.Assert(newBusID > mBuses.Count);

            mBuses.Add(new CBus(newBusID, startStationIndex, mRouteNodes[(int)startStationIndex].Position, maxNumOfPassengers));
        }

        public void AddBusStation(string name, TPoint2 position, ushort startNumOfPassengers,
                                  ushort intensity, bool isEnding)
        {
            uint newBusStationID = Convert.ToUInt32(mRouteNodes.Count + 1);

            //отладочная информация
            Debug.Assert(newBusStationID > mRouteNodes.Count);

            mRouteNodes.Add(new CBusStationNode(newBusStationID, name, position, startNumOfPassengers, intensity, isEnding));
        }

        public void UpdateBusStationData(uint id, string name, TPoint2 position, ushort startNumOfPassengers,
                                         ushort intensity, bool isEnding)
        {
            if (id > mRouteNodes.Count)
            {
                throw new ArgumentException("Incorrect value of an argument", "id");
            }

            CBusStationNode currBusStation = mRouteNodes[(int)id] as CBusStationNode;

            if (currBusStation == null)
            {
                throw new InvalidCastException("Can't cast a base class instance to derived one");
            }

            currBusStation.Name = name;
            currBusStation.Position = position;
            currBusStation.CurrNumOfPassengers = startNumOfPassengers;
            currBusStation.Intensity = intensity;
            currBusStation.IsEndingStation = isEnding;
        }

        public void AddCrossRoad(string name, TPoint2 position, double loadCoefficient)
        {
            uint newCrossRoadID = Convert.ToUInt32(mRouteNodes.Count + 1);

            //отладочная информация
            Debug.Assert(newCrossRoadID > mRouteNodes.Count);

            mRouteNodes.Add(new CCrossRoadNode(newCrossRoadID, name, position, loadCoefficient));
        }

        public void InsertRouteNodeByID(uint id, CRouteNode newRouteNodeValue)
        {
            if (id > mRouteNodes.Count)
            {
                throw new ArgumentException("Incorrect value of an argument", "id");
            }

            mRouteNodes.Insert((int)id, newRouteNodeValue);
        }

        public void UpdateRouteNodeByID(uint id, CRouteNode newRouteNodeValue)
        {
            //проверка аргументов делается вызывающим кодом
            mRouteNodes[(int)id] = newRouteNodeValue;
        }

        public void Clear()
        {
            List<CRouteNode> route = mRouteNodes;

            if (route == null || route.Count == 0)
            {
                return;
            }

            route.Clear();
        }

        public CRouteNode GetRouteNodeByID(uint id)
        {
            if (id >= mRouteNodes.Count)
            {
                return null;
            }

            return mRouteNodes[(int)id];
        }

        public void LoadFromDataBase(SQLiteConnection dbConnection)
        {
            throw new System.NotImplementedException();
        }

        public void SaveIntoDataBase(SQLiteConnection dbConnection)
        {
            //Сохранение данных о маршруте

            //пересоздание таблицы, так как в БД хранится информация только о текущем маршруте
            //Properties.Resources.mSQLQueryClearTable содержит параметр имени таблицы, которую надо удалить

            using (SQLiteCommand currComand = new SQLiteCommand(dbConnection))
            {
                currComand.CommandText = string.Format(Properties.Resources.mSQLQueryDropTable, Properties.Resources.mSQLRouteNodesTableName);
                currComand.ExecuteNonQuery();

                //создание таблицы routeNodes
                currComand.CommandText = Properties.Resources.mSQLQueryCreateRouteNodesTable;
                currComand.ExecuteNonQuery();

                currComand.CommandText = string.Format(Properties.Resources.mSQLQueryDropTable, Properties.Resources.mSQLBusStationNodesTableName);
                currComand.ExecuteNonQuery();

                //создание таблицы busStationNodes
                currComand.CommandText = Properties.Resources.mSQLQueryCreateBusStationNodesTable;
                currComand.ExecuteNonQuery();

                //аналогичная операция для таблицы с информацией о перекрестках
                currComand.CommandText = string.Format(Properties.Resources.mSQLQueryDropTable, Properties.Resources.mSQLCrossroadNodesTableName);
                currComand.ExecuteNonQuery();

                //создание таблицы crossroadNodes
                currComand.CommandText = Properties.Resources.mSQLQueryCreateCrossroadNodesTable;
                currComand.ExecuteNonQuery();

                foreach (CRouteNode currRouteNode in mRouteNodes)
                {
                    currRouteNode.SaveIntoDataBase(dbConnection);
                }

                //Сохранение данных об автобусах

                currComand.CommandText = string.Format(Properties.Resources.mSQLQueryDropTable, Properties.Resources.mSQLBusesTableName);
                currComand.ExecuteNonQuery();

                currComand.CommandText = Properties.Resources.mSQLQueryCreateBusesTable;
                currComand.ExecuteNonQuery();

                foreach (CBus currBus in mBuses)
                {
                    currBus.SaveIntoDataBase(dbConnection);
                }
            }
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

        public List<CBus> Buses
        {
            get
            {
                return mBuses;
            }

            set
            {
                mBuses = value;
            }
        }

        public List<CRouteNode> RouteNodes
        {
            get
            {
                return mRouteNodes;
            }

            set
            {
                mRouteNodes = value;
            }
        }

        public int NumOfNodes
        {
            get
            {
                return mRouteNodes.Count;
            }
        }

        #endregion
    }
}
