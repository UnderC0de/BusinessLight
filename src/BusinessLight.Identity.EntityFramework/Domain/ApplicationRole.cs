using System;
using BusinessLight.Domain.Application;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BusinessLight.Identity.EntityFramework.Domain
{
    public class ApplicationRole : IdentityRole<Guid, ApplicationUserRole>, IApplicationRole
    {
        public ApplicationRole() { }
        public ApplicationRole(string name) { Name = name; }
    }
}