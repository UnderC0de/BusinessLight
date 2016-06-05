using System;
using System.Data.Entity;
using BusinessLight.Identity.EntityFramework.Domain;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BusinessLight.Identity.EntityFramework
{
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

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    //modelBuilder.Entity<ApplicationUser>().ToTable("Users");
        //    //modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles");
        //    //modelBuilder.Entity<IdentityUserLogin>().ToTable("Logins");
        //    //modelBuilder.Entity<IdentityUserClaim>().ToTable("Claims");
        //    //modelBuilder.Entity<IdentityRole>().ToTable("Roles");
        //}
    }
}
