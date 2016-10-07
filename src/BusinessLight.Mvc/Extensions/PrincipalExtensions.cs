namespace BusinessLight.Mvc.Extensions
{
    using System.Linq;
    using System.Security.Principal;

    public static class PrincipalExtensions
    {
        public static bool IsInRole(this IPrincipal principal, params string[] roles)
        {
            return roles.Any(principal.IsInRole);
        }
    }
}