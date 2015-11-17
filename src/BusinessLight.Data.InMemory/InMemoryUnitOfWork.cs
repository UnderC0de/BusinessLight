using System;
using System.Collections;

namespace BusinessLight.Data.InMemory
{
    public class InMemoryUnitOfWork : IUnitOfWork
    {
        private bool _disposed;
        private readonly InMemoryRepository _repository;

        public InMemoryUnitOfWork(IList source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            _repository = new InMemoryRepository(source);
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