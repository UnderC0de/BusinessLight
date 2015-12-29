using System;
using System.Linq;
using BusinessLight.Domain;

namespace BusinessLight.Data
{
    public interface ISortedQuery<TSource> : IQuery<TSource> where TSource : UniqueEntity
    {
        Func<IQueryable<TSource>, IOrderedQueryable<TSource>> GetSortingExpression();
    }
}