namespace BusinessLight.Identity.EntityFramework
{
    using System;
    using BusinessLight.Identity.EntityFramework.Domain;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class ApplicationUserStore : UserStore<ApplicationUser, ApplicationRole, Guid,
        ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        public ApplicationUserStore(IdentityDbContext<ApplicationUser, ApplicationRole, Guid, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim> context)
            : base(context)
        {
        }
    }
}