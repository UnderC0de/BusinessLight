using System;
using System.Collections.Generic;
using BusinessLight.Domain;

namespace BusinessLight.PhoneBook.Domain
{
    public class Contact : UniqueEntity
    {
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

        public string Note
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
