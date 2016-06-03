using System;
using System.Security.Claims;
using System.Threading.Tasks;
using BusinessLight.Domain.Application;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BusinessLight.Identity.EntityFramework.Domain
{
    public class ApplicationUser : IdentityUser<Guid, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>, IApplicationUser<ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        public virtual async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser, Guid> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            
            // Add custom user claims here
            return userIdentity;
        }

        public string Language
        {
            get;
            set;
        }
    }
}
