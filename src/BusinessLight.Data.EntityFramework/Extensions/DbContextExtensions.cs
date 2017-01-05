namespace BusinessLight.Data.EntityFramework.Extensions
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading;
    using BusinessLight.Domain;

    public static class DbContextExtensions
    {
        public static void SetTimeStamp(this DbContext dbContext)
        {
            var userName = "ApplicationUser";
            if (Thread.CurrentPrincipal != null)
            {
                if (Thread.CurrentPrincipal.Identity != null)
                {
                    userName = Thread.CurrentPrincipal.Identity.Name;
                }
            }

            // Get all Added/Modified entities
            var addedEntries = dbContext.ChangeTracker.Entries().Where(x => x.State == EntityState.Added);
            var modifiedEntries = dbContext.ChangeTracker.Entries().Where(x => x.State == EntityState.Modified);

            var dateNow = DateTime.Now.ToUniversalTime();

            // Added entries
            foreach (var addedEntry in addedEntries)
            {
                var addedAuditable = addedEntry.Entity as IAuditable;
                if (addedAuditable == null)
                {
                    continue;
                }

                addedAuditable.CreatedOn = dateNow;
                addedAuditable.CreatedBy = userName;
                addedAuditable.ModifiedOn = dateNow;
                addedAuditable.ModifiedBy = userName;
            }

            // Modified entries
            foreach (var modifiedEntry in modifiedEntries)
            {
                var modifiedAuditable = modifiedEntry.Entity as IAuditable;
                if (modifiedAuditable == null)
                {
                    continue;
                }

                // Do not update CreatedOn property
                dbContext.Entry(modifiedAuditable).Property(x => x.CreatedOn).IsModified = false;
                dbContext.Entry(modifiedAuditable).Property(x => x.CreatedBy).IsModified = false;
                modifiedAuditable.ModifiedOn = dateNow;
                modifiedAuditable.ModifiedBy = userName;
            }
        }
    }
}
