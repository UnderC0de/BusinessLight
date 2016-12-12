namespace BusinessLight.Data
{
    using System;
    using System.Linq.Expressions;

    using BusinessLight.Domain;

    public abstract class Specification<TSource> : ISpecification<TSource> where TSource : Entity
    {
        public virtual Expression<Func<TSource, bool>> GetSpecificationExpression()
        {
            Expression<Func<TSource, bool>> filter = uniqueEntity => true;
            return filter;
        }
    }
}