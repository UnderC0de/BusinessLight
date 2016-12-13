namespace BusinessLight.Data
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using BusinessLight.Data.Specifications;
    using BusinessLight.Domain;

    public interface IRepository : IDisposable
    {
        void Add<T>(T entity) where T : Entity;

        void Update<T>(T entity) where T : Entity;

        void AddOrUpdate<T>(T entity) where T : Entity;

        void Remove<T>(T entity) where T : Entity;

        IQueryable<T> Query<T>() where T : Entity;

        IQueryable<T> IsSatisfiedBy<T>(ISpecification<T> specification) where T : Entity;

        IOrderedQueryable<T> IsSatisfiedBy<T>(ISortedSpecification<T> specification) where T : Entity;

        T GetById<T>(Guid id) where T : Entity;

    }
}
