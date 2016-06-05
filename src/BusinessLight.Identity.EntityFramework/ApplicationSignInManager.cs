using System;
using System.Security.Claims;
using System.Threading.Tasks;
using BusinessLight.Identity.EntityFramework.Domain;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;

namespace BusinessLight.Identity.EntityFramework
{
    public class ApplicationSignInManager : SignInManager<ApplicationUser, Guid>
    {
        public ApplicationSignInManager(UserManager<ApplicationUser, Guid> userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
        {
            return user.GenerateUserIdentityAsync(UserManager);
        }

        public static ApplicationSignInManager Create(UserManager<ApplicationUser, Guid> userManager, IAuthenticationManager authenticationManager)
        {
            return new ApplicationSignInManager(userManager, authenticationManager);
        }
    }
}