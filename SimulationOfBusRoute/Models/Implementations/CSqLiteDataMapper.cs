using SimulationOfBusRoute.Models.Interfaces;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Text.RegularExpressions;


namespace SimulationOfBusRoute.Models.Implementations
{
    public abstract class CSqLiteDataMapper<T> : IDataMapper<T>
                                                where T : IBaseModel
    {
        protected SQLiteConnection mDBConnection;

        /// <summary>
        /// A contructor of the class.
        /// It creates a new file if the specified one doesn't exist.
        /// </summary>
        /// <param name="connectionString">A connection string of a data base (SqLite)</param>

        public CSqLiteDataMapper(string connectionString)
        {
            Regex connectionStringPattern = new Regex(".*?Data\\sSource\\s*=\\s*(.*?);.*?", RegexOptions.Singleline);

            Match filenameMatch = connectionStringPattern.Match(connectionString);

            string filename = filenameMatch.Groups[1].Value;

            if (!File.Exists(filename))
            {
                SQLiteConnection.CreateFile(filename);
            }

            mDBConnection = new SQLiteConnection(connectionString);
            mDBConnection.Open();
        }

        #region Methods

        public virtual void Dispose()
        {
            mDBConnection.Close();
            mDBConnection.Dispose();
        }

        /// <summary>
        /// Method loads one specified record from a table of a data base. If you need another criteria 
        /// then a better way is to use Load(ISpeficiation) overload of this method.
        /// </summary>
        /// <param name="id">Identifier of the record in the table.</param>
        /// <returns>Record of an entity which contains specified id. </returns>

        public abstract T Load(int id);
        
        /// <summary>
        /// Method saves one entity into a table of opened data base.
        /// </summary>
        /// <param name="entity">An entity which should be saved</param>

        public abstract void Save(T entity);
        
        /// <summary>
        /// Method removes entities, which are stored in a table.
        /// </summary>

        public abstract void DeleteAll();

        #endregion
    }
}
