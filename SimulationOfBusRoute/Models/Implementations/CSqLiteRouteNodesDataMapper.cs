using GMap.NET;
using SimulationOfBusRoute.Utils;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;


namespace SimulationOfBusRoute.Models.Implementations
{
    public class CSqLiteRouteNodesDataMapper : CSqLiteDataMapper<CRouteNode>
    {
        public CSqLiteRouteNodesDataMapper(string connectionString) :
            base(connectionString)
        {
            using (SQLiteCommand createTableCommand = new SQLiteCommand(Properties.Resources.mSQLQueryCreateRouteNodesTable, mDBConnection))
            {
                createTableCommand.ExecuteNonQuery();
            }
        }

        #region Methods

        /// <summary>
        /// Method loads one specified record from a table of a data base. If you need another criteria 
        /// then a better way is to use Load(ISpeficiation) overload of this method.
        /// </summary>
        /// <param name="id">Identifier of the record in the table.</param>
        /// <returns>Record of an entity which contains specified id. </returns>

        public override CRouteNode Load(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method loads all data from a table of a data base.
        /// </summary>
        /// <returns>List of loaded entities</returns>

        public virtual List<CRouteNode> LoadAll()
        {
            List<CRouteNode> readRecords = new List<CRouteNode>();

            string queryStr = string.Format(Properties.Resources.mSQLSimpleSelectQuery, Properties.Resources.mSQLRouteNodesTableName);

            using (SQLiteCommand readRecordCommand = new SQLiteCommand(queryStr, mDBConnection))
            {
                SQLiteDataReader dataReader = readRecordCommand.ExecuteReader();
                
                int id;
                string name;
                CRouteNode.E_ROUTE_NODE_TYPE type;
                string positionStr;

                PointLatLng position;

                foreach (DbDataRecord record in dataReader)
                {
                    id = Convert.ToInt32(record["id"]);
                    name = Convert.ToString(record["name"]);
                    positionStr = Convert.ToString(record["position"]);
                    type = (CRouteNode.E_ROUTE_NODE_TYPE)Convert.ToInt32(record["type"]);

                    position = CPointLatLngHelper.Parse(positionStr);

                    switch (type)
                    {
                        case CRouteNode.E_ROUTE_NODE_TYPE.RNT_INITIAL_BUS_STATION:
                            readRecords.Add(new CBusStation(CBusStation.E_BUS_STATION_TYPE.BST_INITIAL, id, name, position));
                            break;

                        case CRouteNode.E_ROUTE_NODE_TYPE.RNT_BUS_STATION:
                            readRecords.Add(new CBusStation(CBusStation.E_BUS_STATION_TYPE.BST_DEFAULT, id, name, position));
                            break;

                        case CRouteNode.E_ROUTE_NODE_TYPE.RNT_FINAL_BUS_STATION:
                            readRecords.Add(new CBusStation(CBusStation.E_BUS_STATION_TYPE.BST_FINAL, id, name, position));
                            break;

                        case CRouteNode.E_ROUTE_NODE_TYPE.RNT_UTILITY:
                            readRecords.Add(new CUtilityNode(id, name, position));
                            break;
                    }
                }

                dataReader.Close();
            }

            return readRecords;
        }

        /// <summary>
        /// Method saves one entity into a table of opened data base.
        /// </summary>
        /// <param name="entity">An entity which should be saved</param>

        public override void Save(CRouteNode entity)
        {
            using (SQLiteCommand insertRecordCommand = new SQLiteCommand(Properties.Resources.mSQLQueryInsertRouteNode, mDBConnection))
            {
                insertRecordCommand.Parameters.AddWithValue("@id", entity.ID);
                insertRecordCommand.Parameters.AddWithValue("@name", entity.Name);
                insertRecordCommand.Parameters.AddWithValue("@position", entity.Position.ToDbString());
                insertRecordCommand.Parameters.AddWithValue("@type", entity.NodeType);

                insertRecordCommand.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Method saves all entities into a table.
        /// </summary>
        /// <param name="entities">List of entities</param>

        public virtual void SaveAll(List<CRouteNode> entities)
        {
            DeleteAll();

            foreach (CRouteNode entity in entities)
            {
                Save(entity);
            }
        }

        /// <summary>
        /// Method removes entities, which are stored in a table.
        /// </summary>

        public override void DeleteAll()
        {
            string queryStr = string.Format(Properties.Resources.mSQLDeleteAllRecords, Properties.Resources.mSQLRouteNodesTableName);

            using (SQLiteCommand deleteRecordsCommand = new SQLiteCommand(queryStr, mDBConnection))
            {
                deleteRecordsCommand.ExecuteNonQuery();
            }
        }

        #endregion
    }
}
