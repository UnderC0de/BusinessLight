using System;
using System.Linq.Expressions;
using BusinessLight.Domain;

namespace BusinessLight.Data
{
    public interface IFilter<TSource> where TSource : UniqueEntity
    {
        Expression<Func<TSource, bool>> GetFilterExpression();
    }
}