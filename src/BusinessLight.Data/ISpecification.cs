namespace BusinessLight.Data
{
    using System;
    using System.Linq.Expressions;

    using BusinessLight.Domain;

    public interface ISpecification<TSource> where TSource : Entity
    {
        Expression<Func<TSource, bool>> GetSpecificationExpression();
    }
}