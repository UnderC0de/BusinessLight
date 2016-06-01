using System;
using System.Linq;
using BusinessLight.Domain;

namespace BusinessLight.Data
{
    public abstract class SortedSpecification<TSource> : Specification<TSource>, ISortedSpecification<TSource> where TSource : Entity
    {
        protected SortedSpecification()
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