namespace BusinessLight.Data
{
    using System;

    public interface IUnitOfWork : IDisposable
    {
        IRepository Repository { get; }
        void Commit();
    }
}