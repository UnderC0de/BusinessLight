using BusinessLight.PhoneBook.Domain;

namespace BusinessLight.PhoneBook.Data
{
    using System.Data.Entity;

    public class PhoneBookDbContext : DbContext
    {
        public PhoneBookDbContext()
            : base("name=PhoneBookDbContext")
        {
        }

        public virtual DbSet<Contact> Contacts
        {
            get; 
            set;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
              .Entity<ContactInfo>()
              .HasRequired(x => x.Contact)
              .WithMany(x => x.ContactInfos)
              .HasForeignKey(x => x.ContactId);

            base.OnModelCreating(modelBuilder);
        }
    }
}