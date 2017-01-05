namespace BusinessLight.Data.InMemory
{
    using System;
    using System.Collections;

    public class InMemoryUnitOfWork : IUnitOfWork
    {
        private bool disposed;
        private readonly InMemoryRepository repository;

        public InMemoryUnitOfWork(IList source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            this.repository = new InMemoryRepository(source);
        }

        public IRepository Repository
        {
            get
            {
                return this.repository;
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
            if (this.disposed)
            {
                return;
            }

            if (disposing)
            {
                this.repository.Dispose();
            }

            this.disposed = true;
        }
    }
}