using System;
using System.Data.Entity;
using System.Linq;
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
            throw new NotImplementedException();
        }

        public void Update<T>(T entity) where T : UniqueEntity
        {
            throw new NotImplementedException();
        }

        public void Remove<T>(T entity) where T : UniqueEntity
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Query<T>() where T : UniqueEntity
        {
            return _dbContext.Set<T>();
        }

        public IQueryable<T> ApplyFilter<T>(IFilter<T> filter) where T : UniqueEntity
        {
            return Query<T>().Where(filter.GetFilterExpression());
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