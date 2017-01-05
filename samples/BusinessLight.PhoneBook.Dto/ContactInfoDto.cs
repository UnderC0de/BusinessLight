namespace BusinessLight.PhoneBook.Dto
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using BusinessLight.Dto;
    using BusinessLight.PhoneBook.Common;

    public class ContactInfoDto : Dto
    {
        [Display(Name = "Detail")]
        public string ContactInfoDetail { get; set; }
        [Display(Name = "Type")]
        public ContactInfoType ContactInfoType { get; set; }
        public Guid ContactId { get; set; }
    }
}