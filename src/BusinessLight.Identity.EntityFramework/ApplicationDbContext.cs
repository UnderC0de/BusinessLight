namespace BusinessLight.Identity.EntityFramework
{
    using System;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Validation;
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

        //public static ApplicationDbContext Create()
        //{
        //    return new ApplicationDbContext();
        //}

        public override int SaveChanges()
        {
            try
            {
                this.SetTimeStamp();
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                throw new Exception(ex.GetFullExceptionMessage());
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.GetFullExceptionMessage());
            }
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            try
            {
                this.SetTimeStamp();
                return base.SaveChangesAsync(cancellationToken);
            }
            catch (DbEntityValidationException ex)
            {
                throw new Exception(ex.GetFullExceptionMessage());
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.GetFullExceptionMessage());
            }
        }
    }
}
