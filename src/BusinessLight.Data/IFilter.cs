using System;
using System.Linq.Expressions;
using BusinessLight.Domain;

namespace BusinessLight.Data
{
    public interface IFilter<TSource> where TSource : UniqueEntity
    {
        Expression<Func<TSource, bool>> GetFilterExpression();
    }

    public abstract class Filter<TSource> : IFilter<TSource> where TSource : UniqueEntity
    {
        public virtual Expression<Func<TSource, bool>> GetFilterExpression()
        {
            Expression<Func<TSource, bool>> filter = uniqueEntity => true;
            return filter;
        }
    }
}