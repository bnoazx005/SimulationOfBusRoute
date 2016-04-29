using DataModel.Interfaces;
using System.Data.SQLite;
using System.Collections.Generic;


namespace DataModel.Implementations
{
    public abstract class CSqLiteDataMapper<T> : IDataMapper<T>
                                                where T : IBaseModel
    {
        protected SQLiteConnection mDBConnection;

        public CSqLiteDataMapper(string connectionString)
        {
            mDBConnection = new SQLiteConnection(connectionString);
        }

        #region Methods

        public virtual void Dispose()
        {
            mDBConnection.Dispose();
        }

        public abstract T Load(uint id);

        public abstract List<T> LoadAll();

        public abstract void Save(T entity);
        
        public abstract void SaveAll(List<T> entities);
        
        #endregion
    }
}
