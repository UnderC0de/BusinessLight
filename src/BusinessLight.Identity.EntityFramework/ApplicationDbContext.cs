namespace BusinessLight.Identity.EntityFramework
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using BusinessLight.Data.EntityFramework.Extensions;
    using BusinessLight.Identity.EntityFramework.Domain;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        public ApplicationDbContext()
            : this("DefaultConnection")
        {
        }

        public ApplicationDbContext(string nameOrConnectionString) 
            : base(nameOrConnectionString)
        {
            
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public override int SaveChanges()
        {
            return this.ExtendedSaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return this.ExtendedSaveChangesAsync(cancellationToken);
        }
    }
}
