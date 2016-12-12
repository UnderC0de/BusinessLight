namespace BusinessLight.Data
{
    using System;
    using System.Linq.Expressions;

    using BusinessLight.Data.Extensions;
    using BusinessLight.Domain;

    public abstract class SpecificationById<TSource> : Specification<TSource> where TSource : Entity
    {
        public Guid Id
        {
            get;
            set;
        }

        public override Expression<Func<TSource, bool>> GetSpecificationExpression()
        {
            var filter = base.GetSpecificationExpression();
            filter = filter.And(x => x.Id == Id);

            return filter;
        }
    }
}