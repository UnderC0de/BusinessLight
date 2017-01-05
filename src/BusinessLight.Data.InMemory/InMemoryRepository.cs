namespace BusinessLight.Data.InMemory
{
    using System;
    using System.Collections;
    using System.Linq;
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

        public void Add<T>(T entity) where T : Entity
        {
            Remove(entity);
            this.source.Add(entity);
        }

        public void Update<T>(T entity) where T : Entity
        {
            Remove(entity);
            Add(entity);
        }

        public void AddOrUpdate<T>(T entity) where T : Entity
        {
            Update(entity);
        }

        public void Remove<T>(T entity) where T : Entity
        {
             this.source.Remove(entity);
        }

        public IQueryable<T> Query<T>() where T : Entity
        {
            return this.source.OfType<T>().AsQueryable();
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
            return this.source.OfType<T>().Single(x => x.Id == id);
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
