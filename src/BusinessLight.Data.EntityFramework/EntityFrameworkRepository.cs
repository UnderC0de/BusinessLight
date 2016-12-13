namespace BusinessLight.Data.EntityFramework
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Linq.Expressions;

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

        public void Add<T>(T entity) where T : Entity
        {
            this.dbContext.Set<T>().Add(entity);
        }

        public void Update<T>(T entity) where T : Entity
        {
            this.dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void AddOrUpdate<T>(T entity) where T : Entity
        {
            this.dbContext.Set<T>().AddOrUpdate(entity);
        }

        public void Remove<T>(T entity) where T : Entity
        {
            this.dbContext.Set<T>().Remove(entity);
        }

        public IQueryable<T> Query<T>() where T : Entity
        {
            return this.dbContext.Set<T>();
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
            return this.dbContext.Set<T>().Find(id);
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