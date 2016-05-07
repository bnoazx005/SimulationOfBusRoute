using System;
using System.Linq.Expressions;
using SimulationOfBusRoute.Models.Interfaces;

namespace SimulationOfBusRoute.Models.Implementations
{
    public abstract class CSpecification<T>: ISpecification<T>
                                            where T : IBaseModel
    {
        public CSpecification()
        {
        }

        /// <summary>
        /// The method is predicate that returns 'true' if specified condition is satisfied and 'false' in other case
        /// </summary>
        /// <param name="entity">A test entity</param>
        /// <returns>Returns 'true' if entity satisfies the condition. In other case returns 'false'.</returns>

        public bool IsSatisfied(T entity)
        {
            Func<T, bool> predicate = ToExpression().Compile();

            return predicate(entity);
        }

        /// <summary>
        /// Method returns corresponding LINQ expression of the specification's predicate.
        /// </summary>
        /// <returns>LINQ expression</returns>

        public abstract Expression<Func<T, bool>> ToExpression();
    }

    public class CAndSpecification<T> : CSpecification<T>
                                      where T : IBaseModel
    {
        protected ISpecification<T> mLeftOperand;

        protected ISpecification<T> mRightOperand;

        public CAndSpecification(ISpecification<T> leftOperand, ISpecification<T> rightOperand)
        {
            mLeftOperand = leftOperand;
            mRightOperand = rightOperand;
        }

        /// <summary>
        /// Method returns corresponding LINQ expression for logic conjunction.
        /// </summary>
        /// <returns>LINQ expression</returns>
        
        public override Expression<Func<T, bool>> ToExpression()
        {
            Expression<Func<T, bool>> leftOpExpr = mLeftOperand.ToExpression();
            Expression<Func<T, bool>> rightOpExpr = mRightOperand.ToExpression();

            BinaryExpression andOpExpr = Expression.AndAlso(leftOpExpr.Body, rightOpExpr.Body);

            return Expression.Lambda<Func<T, bool>>(andOpExpr, leftOpExpr.Parameters);
        }
    }

    public class COrSpecification<T> : CSpecification<T>
                                  where T : IBaseModel
    {
        protected ISpecification<T> mLeftOperand;

        protected ISpecification<T> mRightOperand;

        public COrSpecification(ISpecification<T> leftOperand, ISpecification<T> rightOperand)
        {
            mLeftOperand = leftOperand;

            mRightOperand = rightOperand;
        }

        /// <summary>
        /// Method returns corresponding LINQ expression for logic disjunction.
        /// </summary>
        /// <returns>LINQ expression</returns>

        public override Expression<Func<T, bool>> ToExpression()
        {
            Expression<Func<T, bool>> leftOpExpr = mLeftOperand.ToExpression();
            Expression<Func<T, bool>> rightOpExpr = mRightOperand.ToExpression();

            BinaryExpression orOpExpr = Expression.Or(leftOpExpr.Body, rightOpExpr.Body);

            return Expression.Lambda<Func<T, bool>>(orOpExpr, leftOpExpr.Parameters);
        }
    }

    public class CNotSpecification<T> : CSpecification<T>
                                  where T : IBaseModel
    {
        protected ISpecification<T> mOperand;

        public CNotSpecification(ISpecification<T> operand)
        {
            mOperand = operand;
        }

        /// <summary>
        /// Method returns corresponding LINQ expression for logic negation.
        /// </summary>
        /// <returns>LINQ expression</returns>

        public override Expression<Func<T, bool>> ToExpression()
        {
            Expression<Func<T, bool>> opExpr = mOperand.ToExpression();

            UnaryExpression andOpExpr = Expression.Not(opExpr.Body);

            return Expression.Lambda<Func<T, bool>>(andOpExpr, opExpr.Parameters);
        }
    }
}
