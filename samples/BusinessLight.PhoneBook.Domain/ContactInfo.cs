using System;
using BusinessLight.Domain;
using BusinessLight.PhoneBook.Common;

namespace BusinessLight.PhoneBook.Domain
{
    public class ContactInfo : UniqueEntity
    {
        public string ContactInfoDetail
        {
            get;
            set;
        }

        public ContactInfoType ContactInfoType
        {
            get; 
            set;
        }

        public string Notes
        {
            get; 
            set;
        }

        public Contact Contact
        {
            get;
            set;
        }

        public Guid ContactId
        {
            get;
            set;
        }
    }
}