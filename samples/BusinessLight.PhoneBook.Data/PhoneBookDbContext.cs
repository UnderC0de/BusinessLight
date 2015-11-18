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
    }
}