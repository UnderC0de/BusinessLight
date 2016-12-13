namespace BusinessLight.Data.EntityFramework
{
    using System;
    using System.Data.Entity;

    public class EntityFrameworkUnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly DbContext dbContext;

        public EntityFrameworkUnitOfWorkFactory(DbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            this.dbContext = dbContext;
        }

        public IUnitOfWork GetUnitOfWork()
        {
            return new EntityFrameworkUnitOfWork(this.dbContext);
        }
    }
}