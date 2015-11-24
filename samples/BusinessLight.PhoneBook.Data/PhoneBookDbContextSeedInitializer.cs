using System;
using System.Data.Entity;
using BusinessLight.PhoneBook.Domain;

namespace BusinessLight.PhoneBook.Data
{
    public class PhoneBookDbContextSeedInitializer : DropCreateDatabaseIfModelChanges<PhoneBookDbContext>
    {
        protected override void Seed(PhoneBookDbContext context)
        {
            for (var i = 0; i < 150; i++)
            {
                var contact = new Contact
                {
                    FirstName = string.Format("FirstName{0}", i),
                    LastName = string.Format("LastName{0}", i),
                    BirthDate = DateTime.Now.AddDays(i),
                    Note = string.Format("Note1{0}", i),
                };
                context.Set<Contact>().Add(contact);
            }
            context.SaveChanges();
        }
    }
}
