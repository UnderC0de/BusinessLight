namespace BusinessLight.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using BusinessLight.Data.Specifications;
    using BusinessLight.Domain;

    public interface IRepository : IDisposable
    {
        Task AddAsync<T>(T entity) where T : Entity;

        Task UpdateAsync<T>(T entity) where T : Entity;

        Task AddOrUpdateAsync<T>(T entity) where T : Entity;

        Task RemoveAsync<T>(T entity) where T : Entity;

        Task<IQueryable<T>> QueryAsync<T>() where T : Entity;

        Task<IQueryable<T>> IsSatisfiedByAsync<T>(ISpecification<T> specification) where T : Entity;

        Task<IOrderedQueryable<T>> IsSatisfiedByAsync<T>(ISortedSpecification<T> specification) where T : Entity;

        Task<T> GetByIdAsync<T>(Guid id) where T : Entity;
    }
}
