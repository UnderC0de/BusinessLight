using System;
using System.Linq.Expressions;
using BusinessLight.Domain;

namespace BusinessLight.Data
{
    public interface ISpecification<TSource> where TSource : Entity
    {
        Expression<Func<TSource, bool>> GetSpecificationExpression();
    }
}