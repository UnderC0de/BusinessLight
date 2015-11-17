using BusinessLight.Domain;

namespace BusinessLight.PhoneBook.Domain
{
    public class ContactInfo : UniqueEntity
    {
        public string ContactInfoDetail { get; set; }

        public ContactInfoType ContactInfoType { get; set; }
    }
}