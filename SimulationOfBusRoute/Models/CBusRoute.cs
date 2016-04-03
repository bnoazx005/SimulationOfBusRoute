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

        public bool AddBus(ushort maxNumOfPassengers, uint startTime, uint alightingTimePerPassenger, uint boardingTimePerPassenger)
        {
            uint newBusID = Convert.ToUInt32(mBuses.Count);
            
            mBuses.Add(new CBus(newBusID, maxNumOfPassengers, startTime, alightingTimePerPassenger, boardingTimePerPassenger));

            return true;
        }

        public bool UpdateBusInfo(uint id, ushort maxNumOfPassengers, uint startTime, uint alightingTimePerPassenger,
                                  uint boardingTimePerPassenger)
        {
            if (id >= mBuses.Count)
            {
                return false;
            }

            CBus currBus = mBuses[(int)id];

            currBus.MaxNumOfPassengers = maxNumOfPassengers;
            currBus.StartTime = startTime;
            currBus.AlightingTimePerPassenger = alightingTimePerPassenger;
            currBus.BoardingTimePerPassenger = boardingTimePerPassenger;

            return true;
        }

        public bool RemoveBusInfo(uint id)
        {
            uint busesCount = (uint)mBuses.Count;

            if (id >= busesCount)
            {
                return false;
            }

            mBuses.RemoveAt((int)id);

            //пересчет id автобусов, если был удален автобус из середины списка

            if (id == busesCount - 1) //был удален последний элемент пересчет не требуется
            {
                return true;
            }

            uint idCounter = 0;

            mBuses.ForEach(bus => { bus.ID = idCounter++; bus.Name = "bus" + bus.ID.ToString(); });

            return true;
        }
        
        public bool InsertRouteNodeByID(uint id, CRouteNode newRouteNodeValue)
        {
            if (id > mRouteNodes.Count)
            {
                //throw new ArgumentException("Incorrect value of an argument", "id");

                return false;
            }

            mRouteNodes.Insert((int)id, newRouteNodeValue);

            return true;
        }

        public bool UpdateRouteNodeByID(uint id, CRouteNode newRouteNodeValue)
        {
            if (id > mRouteNodes.Count)
            {
                //throw new ArgumentException("Incorrect value of an argument", "id");

                return false;
            }
            
            mRouteNodes[(int)id] = newRouteNodeValue;

            return true;
        }

        public bool ClearRouteNodes()
        {
            List<CRouteNode> route = mRouteNodes;

            if (route == null || route.Count == 0)
            {
                return false;
            }

            route.Clear();

            return true;
        }

        public bool ClearBusesInfo()
        {
            List<CBus> buses = mBuses;

            if (buses == null || buses.Count == 0)
            {
                return false;
            }

            buses.Clear();

            return true;
        }
        public CRouteNode GetRouteNodeByID(uint id)
        {
            if (id >= mRouteNodes.Count)
            {
                return null;
            }

            return mRouteNodes[(int)id];
        }

        public bool RemoveRouteNode(uint id)
        {
            if (id >= mRouteNodes.Count)
            {
                return false;
            }

            mRouteNodes.RemoveAt((int)id);

            return true;
        }

        public void LoadFromDataBase(SQLiteConnection dbConnection)
        {
            using (SQLiteCommand currCommand = new SQLiteCommand(dbConnection))
            {
                //чтение таблицы routeNodes

                currCommand.CommandText = string.Format(Properties.Resources.mSQLSimpleSelectQuery, Properties.Resources.mSQLRouteNodesTableName);

                SQLiteDataReader reader = currCommand.ExecuteReader();
                
                string tmpStr;

                uint tmpId = 0;
                int tmpType;

                foreach(System.Data.Common.DbDataRecord record in reader)
                {
                    tmpId = Convert.ToUInt32(record["id"]);
                    tmpType = Convert.ToInt32(record["type"]);
                    tmpStr = (string)record["name"];

                    switch (tmpType)
                    {
                        case 0: /*RNT_BUS_STATION*/
                            mRouteNodes.Add(new CBusStationNode(tmpId, tmpStr));
                            break;
                        case 1: /*RNT_ENDING_BUS_STATION*/
                            mRouteNodes.Add(new CBusStationNode(tmpId, tmpStr, true));
                            break;
                        case 2: /*RNT_CROSSROAD*/
                            mRouteNodes.Add(new CCrossRoadNode(tmpId, tmpStr));
                            break;
                    }

                    mRouteNodes[mRouteNodes.Count - 1].Position = TPoint2.TryParse((string)record["position"]);
                }

                reader.Close();

                //чтение данных об остановках

                currCommand.CommandText = string.Format(Properties.Resources.mSQLSimpleSelectQuery, Properties.Resources.mSQLBusStationNodesTableName);
                reader = currCommand.ExecuteReader();

                CBusStationNode tmpBusStationNode = null;

                foreach (System.Data.Common.DbDataRecord record in reader)
                {
                    tmpId = Convert.ToUInt32(record["id"]);

                    tmpBusStationNode = mRouteNodes[(int)tmpId] as CBusStationNode;

                    //дописать остальные параметры
                    tmpBusStationNode.Intensity = Convert.ToDouble(reader["intensity"]);
                    tmpBusStationNode.VelocityOfSpan = Convert.ToDouble(reader["velocityOfSpan"]);
                }

                reader.Close();

                //чтение данных о перекрестках

                currCommand.CommandText = string.Format(Properties.Resources.mSQLSimpleSelectQuery, Properties.Resources.mSQLCrossroadNodesTableName);
                reader = currCommand.ExecuteReader();

                foreach(System.Data.Common.DbDataRecord record in reader)
                {
                    tmpId = Convert.ToUInt32(record["id"]);

                    (mRouteNodes[(int)tmpId] as CCrossRoadNode).LoadCoefficient = Convert.ToDouble(reader["loadCoefficient"]);
                }

                reader.Close();

                //чтение данных об автобусах

                currCommand.CommandText = string.Format(Properties.Resources.mSQLSimpleSelectQuery, Properties.Resources.mSQLBusesTableName);

                reader = currCommand.ExecuteReader();

                foreach (System.Data.Common.DbDataRecord record in reader)
                {
                    tmpId = Convert.ToUInt32(record["id"]);

                    mBuses.Add(new CBus(tmpId, Convert.ToUInt16(reader["maxNumOfPassengers"]), 
                                        Convert.ToUInt32(reader["startTime"]),
                                        Convert.ToUInt32(reader["alightingTimePerPassenger"]),
                                        Convert.ToUInt32(reader["boardingTimePerPassenger"])));
                }

                reader.Close();
            }
        }

        public void SaveIntoDataBase(SQLiteConnection dbConnection)
        {
            //пересчет ID для остановок (так как порядок мог быть нарушен из-за удаления/добавления элементов)

            uint currIDCounter = 0;

            mRouteNodes.ForEach(routeNode => { if (routeNode != null) routeNode.ID = currIDCounter++; });

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

        public List<CRouteNode> BusStationNodes
        {
            get
            {
                return mRouteNodes.FindAll(t => t.NodeType != E_ROUTE_NODE_TYPE.RNT_CROSSROAD);
            }
        }

        public int NumOfNodes
        {
            get
            {
                return mRouteNodes.Count;
            }
        }

        public int NumOfBusStations
        {
            get
            {
                return mRouteNodes.FindAll(t => t.NodeType != E_ROUTE_NODE_TYPE.RNT_CROSSROAD).Count;
            }
        }

        #endregion
    }
}
