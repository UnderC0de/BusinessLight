using System;
using BusinessLight.Domain.Application;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BusinessLight.Identity.EntityFramework.Domain
{
    public class ApplicationUserLogin : IdentityUserLogin<Guid>, IApplicationUserLogin
    {
    }
}