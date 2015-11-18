using BusinessLight.Dto;

namespace BusinessLight.PhoneBook.Dto
{
    public class ContactInfoDto : UniqueEntityDto
    {
        public string ContactInfoDetail { get; set; }

        // public ContactInfoType ContactInfoType { get; set; }
    }
}