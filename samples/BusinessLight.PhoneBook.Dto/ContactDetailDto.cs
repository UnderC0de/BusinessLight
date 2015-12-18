using System.Collections.Generic;

namespace BusinessLight.PhoneBook.Dto
{
    public class ContactDetailDto : ContactDto
    {
        public string Notes
        {
            get;
            set;
        }

        public ICollection<ContactInfoDto> ContactInfos { get; set; }
    }
}