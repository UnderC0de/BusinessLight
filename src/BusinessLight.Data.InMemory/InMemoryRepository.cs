namespace BusinessLight.Data.InMemory
{
    using System;
    using System.Collections;
    using System.Linq;
    using System.Threading.Tasks;

    using BusinessLight.Data.Specifications;
    using BusinessLight.Domain;

    internal class InMemoryRepository : IRepository
    {
        private bool disposed;
        private IList source;

        public InMemoryRepository(IList source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            this.source = source;
        }

        public async Task AddAsync<T>(T entity) where T : Entity
        {
            await RemoveAsync(entity);
            this.source.Add(entity);
            
        }

        public async Task UpdateAsync<T>(T entity) where T : Entity
        {
            await RemoveAsync(entity);
            await AddAsync(entity);
        }

        public async Task AddOrUpdateAsync<T>(T entity) where T : Entity
        {
            await UpdateAsync(entity);
        }

        public Task RemoveAsync<T>(T entity) where T : Entity
        {
             this.source.Remove(entity);
            return Task.FromResult(0);
        }

        public Task<IQueryable<T>> QueryAsync<T>() where T : Entity
        {
            IQueryable<T> result = this.source.OfType<T>().AsQueryable();
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
            var result = this.source.OfType<T>().Single(x => x.Id == id);
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
                 this.source = null;
            }

            this.disposed = true;
        }
    }
}
