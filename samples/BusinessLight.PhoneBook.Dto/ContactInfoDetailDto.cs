using System.ComponentModel.DataAnnotations;

namespace BusinessLight.PhoneBook.Dto
{
    public class ContactInfoDetailDto : ContactInfoDto
    {
        [Display(Name = "Additional info")]
        public string Notes { get; set; }
    }
}