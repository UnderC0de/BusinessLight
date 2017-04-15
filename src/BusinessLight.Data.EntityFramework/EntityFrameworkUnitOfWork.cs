namespace BusinessLight.Data.EntityFramework
{
    using System;
    using System.Data.Entity;
    using System.Threading.Tasks;

    public class EntityFrameworkUnitOfWork : IUnitOfWork
    {
        private bool disposed;
        private readonly DbContext dbContext;
        private readonly EntityFrameworkRepository repository;

        public EntityFrameworkUnitOfWork(DbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            this.dbContext = dbContext;
            this.repository = new EntityFrameworkRepository(dbContext);
        }

        public IRepository Repository => this.repository;

        public async Task CommitAsync()
        {
            await this.dbContext.SaveChangesAsync();
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
