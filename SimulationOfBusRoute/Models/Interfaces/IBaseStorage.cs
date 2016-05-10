using System;
using System.Collections.Generic;

namespace SimulationOfBusRoute.Models.Interfaces
{
    public interface IBaseStorage<T>: IDisposable
                                     where T : IBaseModel
    {
        event Action OnChanged;

        void Insert(T entity);

        void InsertAfter(T pointer, T entity);

        void Update(T entity);

        void Delete(T entity);

        void DeleteAll();

        T GetById(int id);

        List<T> GetAll();

        T GetBySpecification(ISpecification<T> specification);

        List<T> GetAllBySpecification(ISpecification<T> specification);
    }
}
