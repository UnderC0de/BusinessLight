namespace BusinessLight.Data.Specifications
{
    using System;
    using System.Linq;

    using BusinessLight.Domain;

    public interface ISortedSpecification<TSource> : ISpecification<TSource> where TSource : Entity
    {
        Func<IQueryable<TSource>, IOrderedQueryable<TSource>> GetSortingExpression();
    }
}