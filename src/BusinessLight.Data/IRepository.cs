using System;
using System.Linq;
using BusinessLight.Domain;

namespace BusinessLight.Data
{
    public interface IRepository : IDisposable
    {
        void Add<T>(T entity) where T : UniqueEntity;

        void Update<T>(T entity) where T : UniqueEntity;

        void Remove<T>(T entity) where T : UniqueEntity;

        IQueryable<T> Query<T>() where T : UniqueEntity;

        IQueryable<T> ApplyFilter<T>(IFilter<T> filter) where T : UniqueEntity;

        T GetById<T>(Guid id) where T : UniqueEntity;

    }
}
