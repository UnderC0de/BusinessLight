using System;
using System.Linq;
using BusinessLight.Domain;

namespace BusinessLight.Data
{
    public interface ISortedSpecification<TSource> : ISpecification<TSource> where TSource : Entity
    {
        Func<IQueryable<TSource>, IOrderedQueryable<TSource>> GetSortingExpression();
    }
}