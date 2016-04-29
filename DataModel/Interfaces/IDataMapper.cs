using System;
using System.Collections.Generic;


namespace DataModel.Interfaces
{
    public interface IDataMapper<T>: IDisposable
                                    where T : IBaseModel
    {
        void Save(T entity);

        void SaveAll(List<T> entities);

        T Load(uint id);

        List<T> LoadAll();
    }
}
