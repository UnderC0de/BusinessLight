using System;
using System.Linq;
using BusinessLight.Domain;

namespace BusinessLight.Data
{
    public abstract class SortedQuery<TSource> : Query<TSource>, ISortedQuery<TSource> where TSource : UniqueEntity
    {
        protected SortedQuery()
        {
            SortField = string.Empty;
            IsAscending = true;
        }

        public string SortField
        {
            get;
            set;
        }

        public bool IsAscending
        {
            get; 
            set;
        }

        public abstract Func<IQueryable<TSource>, IOrderedQueryable<TSource>> GetSortingExpression();
    }
}