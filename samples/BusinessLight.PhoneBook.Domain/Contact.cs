using System;
using System.Collections.Generic;
using BusinessLight.Domain;

namespace BusinessLight.PhoneBook.Domain
{
    public class Contact : UniqueEntity
    {
        public Contact()
        {
            ContactInfos = new List<ContactInfo>();
        }

        public string FirstName
        {
            get; 
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public DateTime BirthDate
        {
            get;
            set;
        }

        public string Notes
        {
            get; 
            set;
        }

        public ICollection<ContactInfo> ContactInfos
        {
            get; 
            set;
        }
    }
}
