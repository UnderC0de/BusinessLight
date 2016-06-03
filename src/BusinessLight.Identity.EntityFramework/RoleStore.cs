using System;
using BusinessLight.Identity.EntityFramework.Domain;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BusinessLight.Identity.EntityFramework
{
    public class RoleStore : RoleStore<ApplicationRole, Guid, ApplicationUserRole>
    {
        public RoleStore(IdentityDbContext<ApplicationUser, ApplicationRole, Guid, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim> context)
            : base(context)
        {
        }
    }
}