using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessLight.PhoneBook.Dto
{
    public class ContactDetailDto : ContactDto
    {
        [Display(Name = "Additional info")]
        public string Notes { get; set; }
        public ICollection<ContactInfoDto> ContactInfos { get; set; }
    }
}