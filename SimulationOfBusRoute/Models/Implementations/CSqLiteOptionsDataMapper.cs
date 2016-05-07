using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;


namespace SimulationOfBusRoute.Models.Implementations
{
    public class CSqLiteOptionsDataMapper : CSqLiteDataMapper<COptionsList>
    {
        public CSqLiteOptionsDataMapper(string connectionString) :
            base(connectionString)
        {
            using (SQLiteCommand createTableCommand = new SQLiteCommand(Properties.Resources.mSQLQueryCreateOptionsTable, mDBConnection))
            {
                createTableCommand.ExecuteNonQuery();

                //strOptions table
                createTableCommand.CommandText = Properties.Resources.mSQLCreateStrOptionsTable;
                createTableCommand.ExecuteNonQuery();

                //intOptions table
                createTableCommand.CommandText = Properties.Resources.mSQLCreateIntOptionsTable;
                createTableCommand.ExecuteNonQuery();

                //doubleOptions table
                createTableCommand.CommandText = Properties.Resources.mSQLCreateDoubleOptionsTable;
                createTableCommand.ExecuteNonQuery();

                //boolOptions table
                createTableCommand.CommandText = Properties.Resources.mSQLCreateBoolOptionsTable;
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

        public override COptionsList Load(int id)
        {
            COptionsList options = new COptionsList();

            //Loading the int params
            string queryStr = string.Format(Properties.Resources.mSQLSimpleSelectQuery, Properties.Resources.mSQLIntOptionsTableName);

            using (SQLiteCommand readRecordCommand = new SQLiteCommand(queryStr, mDBConnection))
            {
                SQLiteDataReader dataReader = readRecordCommand.ExecuteReader();
                
                foreach (DbDataRecord record in dataReader)
                {
                    options.AddIntParam(Convert.ToString(record["name"]), Convert.ToInt32(record["value"]));
                }

                dataReader.Close();
            }

            //Loading the double params

            queryStr = string.Format(Properties.Resources.mSQLSimpleSelectQuery, Properties.Resources.mSQLDoubleOptionsTableName);

            using (SQLiteCommand readRecordCommand = new SQLiteCommand(queryStr, mDBConnection))
            {
                SQLiteDataReader dataReader = readRecordCommand.ExecuteReader();

                foreach (DbDataRecord record in dataReader)
                {
                    options.AddDoubleParam(Convert.ToString(record["name"]), Convert.ToDouble(record["value"]));
                }

                dataReader.Close();
            }

            //Loading the string params

            queryStr = string.Format(Properties.Resources.mSQLSimpleSelectQuery, Properties.Resources.mSQLStrOptionsTableName);

            using (SQLiteCommand readRecordCommand = new SQLiteCommand(queryStr, mDBConnection))
            {
                SQLiteDataReader dataReader = readRecordCommand.ExecuteReader();

                foreach (DbDataRecord record in dataReader)
                {
                    options.AddStringParam(Convert.ToString(record["name"]), Convert.ToString(record["value"]));
                }

                dataReader.Close();
            }

            //Loading the bool params

            queryStr = string.Format(Properties.Resources.mSQLSimpleSelectQuery, Properties.Resources.mSQLBoolOptionsTableName);

            using (SQLiteCommand readRecordCommand = new SQLiteCommand(queryStr, mDBConnection))
            {
                SQLiteDataReader dataReader = readRecordCommand.ExecuteReader();

                foreach (DbDataRecord record in dataReader)
                {
                    options.AddBoolParam(Convert.ToString(record["name"]), Convert.ToInt32(record["value"]) == 1 ? true : false);
                }

                dataReader.Close();
            }

            return options;
        }
        
        /// <summary>
        /// Method saves one entity into a table of opened data base.
        /// </summary>
        /// <param name="entity">An entity which should be saved</param>

        public override void Save(COptionsList entity)
        {
            DeleteAll();

            //Saving the integer parameters
            string queryStr = Properties.Resources.mSQLQueryInsertOption;

            using (SQLiteCommand insertIntOptionRecord = new SQLiteCommand(mDBConnection))
            {
                Dictionary<string, int> intParams = entity.IntParams;
                
                foreach (KeyValuePair<string, int> param in intParams)
                {
                    insertIntOptionRecord.CommandText = queryStr;

                    insertIntOptionRecord.Parameters.AddWithValue("@name", param.Key);
                    insertIntOptionRecord.Parameters.AddWithValue("@type", 0);

                    insertIntOptionRecord.ExecuteNonQuery();

                    insertIntOptionRecord.CommandText = string.Format(Properties.Resources.mSQLQueryInsertTOption, 
                                                                      Properties.Resources.mSQLIntOptionsTableName);

                    insertIntOptionRecord.Parameters.AddWithValue("@name", param.Key);
                    insertIntOptionRecord.Parameters.AddWithValue("@value", param.Value);

                    insertIntOptionRecord.ExecuteNonQuery();
                }
            }

            //Saving the double parameters
            queryStr = Properties.Resources.mSQLQueryInsertOption;

            using (SQLiteCommand insertDoubleOptionRecord = new SQLiteCommand(mDBConnection))
            {
                Dictionary<string, double> doubleParams = entity.DoubleParams;
                
                foreach (KeyValuePair<string, double> param in doubleParams)
                {
                    insertDoubleOptionRecord.CommandText = queryStr;

                    insertDoubleOptionRecord.Parameters.AddWithValue("@name", param.Key);
                    insertDoubleOptionRecord.Parameters.AddWithValue("@type", 1);

                    insertDoubleOptionRecord.ExecuteNonQuery();

                    insertDoubleOptionRecord.CommandText = string.Format(Properties.Resources.mSQLQueryInsertTOption,
                                                                      Properties.Resources.mSQLDoubleOptionsTableName);

                    insertDoubleOptionRecord.Parameters.AddWithValue("@name", param.Key);
                    insertDoubleOptionRecord.Parameters.AddWithValue("@value", param.Value);

                    insertDoubleOptionRecord.ExecuteNonQuery();
                }
            }

            //Saving the string parameters
            queryStr = Properties.Resources.mSQLQueryInsertOption;

            using (SQLiteCommand insertStrOptionRecord = new SQLiteCommand(mDBConnection))
            {
                Dictionary<string, string> stringParams = entity.StringParams;
                
                foreach (KeyValuePair<string, string> param in stringParams)
                {
                    insertStrOptionRecord.CommandText = queryStr;

                    insertStrOptionRecord.Parameters.AddWithValue("@name", param.Key);
                    insertStrOptionRecord.Parameters.AddWithValue("@type", 2);

                    insertStrOptionRecord.ExecuteNonQuery();

                    insertStrOptionRecord.CommandText = string.Format(Properties.Resources.mSQLQueryInsertTOption,
                                                                      Properties.Resources.mSQLStrOptionsTableName);

                    insertStrOptionRecord.Parameters.AddWithValue("@name", param.Key);
                    insertStrOptionRecord.Parameters.AddWithValue("@value", param.Value);

                    insertStrOptionRecord.ExecuteNonQuery();
                }
            }

            //Saving the bool parameters
            queryStr = Properties.Resources.mSQLQueryInsertOption;

            using (SQLiteCommand insertBoolOptionRecord = new SQLiteCommand(mDBConnection))
            {
                Dictionary<string, bool> boolParams = entity.BoolParams;
                
                foreach (KeyValuePair<string, bool> param in boolParams)
                {
                    insertBoolOptionRecord.CommandText = queryStr;

                    insertBoolOptionRecord.Parameters.AddWithValue("@name", param.Key);
                    insertBoolOptionRecord.Parameters.AddWithValue("@type", 3);

                    insertBoolOptionRecord.ExecuteNonQuery();

                    insertBoolOptionRecord.CommandText = string.Format(Properties.Resources.mSQLQueryInsertTOption,
                                                                      Properties.Resources.mSQLBoolOptionsTableName);

                    insertBoolOptionRecord.Parameters.AddWithValue("@name", param.Key);
                    insertBoolOptionRecord.Parameters.AddWithValue("@value", param.Value ? 1 : 0);

                    insertBoolOptionRecord.ExecuteNonQuery();
                }
            }
        }
        
        /// <summary>
        /// Method removes entities, which are stored in a table.
        /// </summary>

        public override void DeleteAll()
        {
            string queryStr = string.Format(Properties.Resources.mSQLDeleteAllRecords, Properties.Resources.mSQLOptionsTableName);

            using (SQLiteCommand deleteRecordsCommand = new SQLiteCommand(queryStr, mDBConnection))
            {
                deleteRecordsCommand.ExecuteNonQuery();
            }
        }

        #endregion
    }
}
