using System;
using System.Collections;
using System.Linq;
using BusinessLight.Domain;

namespace BusinessLight.Data.InMemory
{
    using System.Linq.Expressions;

    using BusinessLight.Data.Specifications;

    internal class InMemoryRepository : IRepository
    {
        private bool _disposed;
        private IList _source;

        public InMemoryRepository(IList source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            _source = source;
        }

        public void Add<T>(T entity) where T : Entity
        {
            Remove(entity);
            _source.Add(entity);
        }

        public void Update<T>(T entity) where T : Entity
        {
            Remove(entity);
            Add(entity);
        }

        public void AddOrUpdate<T>(T entity) where T : Entity
        {
            Update(entity);
        }

        public void Remove<T>(T entity) where T : Entity
        {
             _source.Remove(entity);
        }

        public IQueryable<T> Query<T>() where T : Entity
        {
            return _source.OfType<T>().AsQueryable();
        }

        public IQueryable<T> Include<T, TProperty>(IQueryable<T> source, Expression<Func<T, TProperty>> path)
        {
            return source;
        }

        public IQueryable<T> IsSatisfiedBy<T>(ISpecification<T> specification) where T : Entity
        {
            return Query<T>().Where(specification.GetSpecificationExpression());
        }

        public IOrderedQueryable<T> IsSatisfiedBy<T>(ISortedSpecification<T> specification) where T : Entity
        {
            return specification.GetSortingExpression()(Query<T>().Where(specification.GetSpecificationExpression()));
        }

        public T GetById<T>(Guid id) where T : Entity
        {
            return _source.OfType<T>().Single(x => x.Id == id);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                 _source = null;
            }

            _disposed = true;
        }
    }
}
