using System;
using BusinessLight.Identity.EntityFramework.Domain;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BusinessLight.Identity.EntityFramework
{
    public class UserStore : UserStore<ApplicationUser, ApplicationRole, Guid,
        ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        public UserStore(IdentityDbContext<ApplicationUser, ApplicationRole, Guid,
            ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim> context)
            : base(context)
        {
        }
    }
}