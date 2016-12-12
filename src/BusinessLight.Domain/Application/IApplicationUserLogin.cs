namespace BusinessLight.Domain.Application
{
    using System;

    public interface IApplicationUserLogin
    {
        string LoginProvider { get; set; }

        string ProviderKey { get; set; }

        Guid UserId { get; set; }
    }
}