using System;
using System.ComponentModel.DataAnnotations;
using BusinessLight.Dto;
using BusinessLight.PhoneBook.Common;

namespace BusinessLight.PhoneBook.Dto
{
    public class ContactInfoDto : UniqueEntityDto
    {
        [Display(Name = "Detail")]
        public string ContactInfoDetail { get; set; }
        [Display(Name = "Type")]
        public ContactInfoType ContactInfoType { get; set; }
        public Guid ContactId { get; set; }
    }
}