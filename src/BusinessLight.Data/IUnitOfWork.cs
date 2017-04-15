namespace BusinessLight.Data
{
    using System;
    using System.Threading.Tasks;

    public interface IUnitOfWork : IDisposable
    {
        IRepository Repository { get; }
        Task CommitAsync();
    }
}