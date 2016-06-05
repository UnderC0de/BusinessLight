using System;

namespace BusinessLight.Domain.Application
{
    public interface IApplicationUserLogin
    {
        string LoginProvider { get; set; }

        string ProviderKey { get; set; }

        Guid UserId { get; set; }
    }
}