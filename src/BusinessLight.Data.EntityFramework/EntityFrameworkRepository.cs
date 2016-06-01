using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using BusinessLight.Domain;

namespace BusinessLight.Data.EntityFramework
{
    internal class EntityFrameworkRepository : IRepository
    {
        private bool _disposed;
        private readonly DbContext _dbContext;

        public EntityFrameworkRepository(DbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException("dbContext");
            }

            _dbContext = dbContext;
        }

        public void Add<T>(T entity) where T : Entity
        {
            _dbContext.Set<T>().Add(entity);
        }

        public void Update<T>(T entity) where T : Entity
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Remove<T>(T entity) where T : Entity
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public IQueryable<T> Query<T>() where T : Entity
        {
            return _dbContext.Set<T>();
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
            return _dbContext.Set<T>().Find(id);
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
                _dbContext.Dispose();
            }

            _disposed = true;
        }
    }
}