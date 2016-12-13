namespace BusinessLight.Identity.EntityFramework.Domain
{
    using System;

    using BusinessLight.Domain.Application;

    using Microsoft.AspNet.Identity.EntityFramework;

    public class ApplicationUserRole : IdentityUserRole<Guid>, IApplicationUserRole
    {
    }
}