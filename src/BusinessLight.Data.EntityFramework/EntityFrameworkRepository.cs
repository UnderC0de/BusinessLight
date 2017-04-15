namespace BusinessLight.Data.EntityFramework
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Threading.Tasks;

    using BusinessLight.Data.Specifications;
    using BusinessLight.Domain;

    internal class EntityFrameworkRepository : IRepository
    {
        private bool disposed;
        private readonly DbContext dbContext;

        public EntityFrameworkRepository(DbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            this.dbContext = dbContext;
        }

        public Task AddAsync<T>(T entity) where T : Entity
        {
            this.dbContext.Set<T>().Add(entity);
            return Task.FromResult(0);
        }

        public Task UpdateAsync<T>(T entity) where T : Entity
        {
            this.dbContext.Entry(entity).State = EntityState.Modified;
            return Task.FromResult(0);
        }

        public Task AddOrUpdateAsync<T>(T entity) where T : Entity
        {
            this.dbContext.Set<T>().AddOrUpdate(entity);
            return Task.FromResult(0);
        }

        public Task RemoveAsync<T>(T entity) where T : Entity
        {
            this.dbContext.Set<T>().Remove(entity);
            return Task.FromResult(0);
        }

        public Task<IQueryable<T>> QueryAsync<T>() where T : Entity
        {
            IQueryable<T> result = this.dbContext.Set<T>();
            return Task.FromResult(result);
        }

        public async Task<IQueryable<T>> IsSatisfiedByAsync<T>(ISpecification<T> specification) where T : Entity
        {
            return (await QueryAsync<T>()).Where(specification.GetSpecificationExpression());
        }

        public async Task<IOrderedQueryable<T>> IsSatisfiedByAsync<T>(ISortedSpecification<T> specification) where T : Entity
        {
            return specification.GetSortingExpression()((await QueryAsync<T>()).Where(specification.GetSpecificationExpression()));
        }

        public Task<T> GetByIdAsync<T>(Guid id) where T : Entity
        {
            var result = this.dbContext.Set<T>().Find(id);
            return Task.FromResult(result);
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
                this.dbContext.Dispose();
            }

            this.disposed = true;
        }
    }
}