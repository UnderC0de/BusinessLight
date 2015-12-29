using System;
using System.Linq.Expressions;
using BusinessLight.Data.Extensions;
using BusinessLight.Domain;

namespace BusinessLight.Data
{
    public abstract class Query<TSource> : IQuery<TSource> where TSource : UniqueEntity
    {
        public virtual Expression<Func<TSource, bool>> GetFilterExpression()
        {
            Expression<Func<TSource, bool>> filter = uniqueEntity => true;
            return filter;
        }
    }

    public abstract class QueryById<TSource> : Query<TSource> where TSource : UniqueEntity
    {
        public Guid Id
        {
            get;
            set;
        }

        public override Expression<Func<TSource, bool>> GetFilterExpression()
        {
            var filter = base.GetFilterExpression();
            filter = filter.And(x => x.Id == Id);

            return filter;
        }
    }
}