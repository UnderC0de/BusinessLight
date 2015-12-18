using System;
using BusinessLight.Dto;
using BusinessLight.PhoneBook.Common;

namespace BusinessLight.PhoneBook.Dto
{
    public class ContactInfoDto : UniqueEntityDto
    {
        public string ContactInfoDetail { get; set; }

        public ContactInfoType ContactInfoType { get; set; }

        public Guid ContactId { get; set; }
    }
}