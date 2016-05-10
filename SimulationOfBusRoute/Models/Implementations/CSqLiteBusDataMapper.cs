using SimulationOfBusRoute.Models.Implementations.Bus;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;

namespace SimulationOfBusRoute.Models.Implementations
{
    public class CSqLiteBusDataMapper : CSqLiteDataMapper<CBus>
    {
        public CSqLiteBusDataMapper(string connectionString):
            base(connectionString)
        {
            using (SQLiteCommand createTableCommand = new SQLiteCommand(Properties.Resources.mSQLQueryCreateBusesTable, mDBConnection))
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

        public override CBus Load(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method loads all data from a table of a data base.
        /// </summary>
        /// <returns>List of loaded entities</returns>

        public virtual List<CBus> LoadAll()
        {
            List<CBus> readRecords = new List<CBus>();

            string queryStr = string.Format(Properties.Resources.mSQLSimpleSelectQuery, Properties.Resources.mSQLBusesTableName);

            using (SQLiteCommand readRecordCommand = new SQLiteCommand(queryStr, mDBConnection))
            {
                SQLiteDataReader dataReader = readRecordCommand.ExecuteReader();
                
                foreach (DbDataRecord record in dataReader)
                {
                    readRecords.Add(new CBus(Convert.ToInt32(record["id"]),
                                             Convert.ToString(record["name"]),
                                             Convert.ToUInt32(record["maxCapacity"]),
                                             Convert.ToByte(record["alightingTimePerPassenger"]),
                                             Convert.ToByte(record["boardingTimePerPassenger"]),
                                             Convert.ToUInt32(record["startTime"])));
                }

                dataReader.Close();
            }

            return readRecords;
        }

        /// <summary>
        /// Method saves one entity into a table of opened data base.
        /// </summary>
        /// <param name="entity">An entity which should be saved</param>

        public override void Save(CBus entity)
        {
            using (SQLiteCommand insertRecordCommand = new SQLiteCommand(Properties.Resources.mSQLQueryInsertBus, mDBConnection))
            {
                insertRecordCommand.Parameters.AddWithValue("@id", entity.ID);
                insertRecordCommand.Parameters.AddWithValue("@name", entity.Name);
                insertRecordCommand.Parameters.AddWithValue("@maxCapacity", entity.MaxBusCapacity);
                insertRecordCommand.Parameters.AddWithValue("@startTime", entity.TimeOfStart);
                insertRecordCommand.Parameters.AddWithValue("@alightingTimePerPassenger", entity.AlightingTimePerPassenger);
                insertRecordCommand.Parameters.AddWithValue("@boardingTimePerPassenger", entity.BoardingTimePerPassenger);

                insertRecordCommand.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Method saves all entities into a table.
        /// </summary>
        /// <param name="entities">List of entities</param>

        public virtual void SaveAll(List<CBus> entities)
        {
            DeleteAll();

            foreach (CBus entity in entities)
            {
                Save(entity);
            }
        }

        /// <summary>
        /// Method removes entities, which are stored in a table.
        /// </summary>

        public override void DeleteAll()
        {
            string queryStr = string.Format(Properties.Resources.mSQLDeleteAllRecords, Properties.Resources.mSQLBusesTableName);

            using (SQLiteCommand deleteRecordsCommand = new SQLiteCommand(queryStr, mDBConnection))
            {
                deleteRecordsCommand.ExecuteNonQuery();
            }
        }

        #endregion
    }
}
