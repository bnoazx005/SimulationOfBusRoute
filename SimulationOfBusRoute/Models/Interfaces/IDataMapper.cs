using System;


namespace SimulationOfBusRoute.Models.Interfaces
{
    public interface IDataMapper<T> : IDisposable
                                    where T : IBaseModel
    {
        void Save(T entity);

        T Load(int id);

        void DeleteAll();
    }
}
