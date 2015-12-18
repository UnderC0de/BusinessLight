using System;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using BusinessLight.PhoneBook.Common;
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
                    Notes = string.Format("Note1{0}", i),
                };
                
                
                contact.ContactInfos.Add(new ContactInfo
                {
                    ContactId = contact.Id,
                    ContactInfoDetail =  string.Format("http://www.{0}.com", contact.LastName),
                    ContactInfoType = ContactInfoType.WebSite
                });

                contact.ContactInfos.Add(new ContactInfo
                {
                    ContactId = contact.Id,
                    ContactInfoDetail = string.Format("{0}@mail.com", contact.LastName),
                    ContactInfoType = ContactInfoType.Email
                });

                context.Set<Contact>().Add(contact);
            }
            context.SaveChanges();
        }
    }
}
