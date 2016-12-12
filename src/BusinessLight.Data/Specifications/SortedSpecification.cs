namespace BusinessLight.Data.Specifications
{
    using System;
    using System.Linq;

    using BusinessLight.Domain;

    public abstract class SortedSpecification<TSource> : Specification<TSource>, ISortedSpecification<TSource> where TSource : Entity
    {
        protected SortedSpecification()
        {
            this.SortField = string.Empty;
            this.IsAscending = true;
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