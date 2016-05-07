using System;
using System.Linq.Expressions;


namespace SimulationOfBusRoute.Models.Interfaces
{
    public interface ISpecification<T>
                                       where T : IBaseModel
    {
        bool IsSatisfied(T entity);
        
        Expression<Func<T, bool>> ToExpression();
    }
}
