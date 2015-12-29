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

        public void Add<T>(T entity) where T : UniqueEntity
        {
            _dbContext.Set<T>().Add(entity);
        }

        public void Update<T>(T entity) where T : UniqueEntity
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Remove<T>(T entity) where T : UniqueEntity
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public IQueryable<T> Query<T>() where T : UniqueEntity
        {
            return _dbContext.Set<T>();
        }

        public IQueryable<T> ApplyQuery<T>(IQuery<T> query) where T : UniqueEntity
        {
            return Query<T>().Where(query.GetFilterExpression());
        }

        public IOrderedQueryable<T> ApplyQuery<T>(ISortedQuery<T> query) where T : UniqueEntity
        {
            return query.GetSortingExpression()(Query<T>().Where(query.GetFilterExpression()));
        }

        public T GetById<T>(Guid id) where T : UniqueEntity
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