using System;
using System.Data.Entity;

namespace BusinessLight.Data.EntityFramework
{
    public class EntityFrameworkUnitOfWork : IUnitOfWork
    {
        private bool _disposed;
        private readonly DbContext _dbContext;
        private readonly EntityFrameworkRepository _repository;

        public EntityFrameworkUnitOfWork(DbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException("dbContext");
            }

            _dbContext = dbContext;
            _repository = new EntityFrameworkRepository(dbContext);
        }

        public IRepository Repository
        {
            get
            {
                return _repository;
            }
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
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
                _repository.Dispose();
            }

            _disposed = true;
        }
    }
}
