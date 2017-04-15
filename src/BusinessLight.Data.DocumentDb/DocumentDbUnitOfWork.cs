namespace BusinessLight.Data.DocumentDb
{
    using System;
    using System.Threading.Tasks;

    public class DocumentDbUnitOfWork : IUnitOfWork
    {
        private bool disposed;
        private readonly DocumentDbRepository repository;

        public DocumentDbUnitOfWork()
        {
            this.repository = new DocumentDbRepository();
        }

        public IRepository Repository => this.repository;

        public async Task CommitAsync()
        {
        }

        public void Dispose()
        {
            this.Dispose(true);
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