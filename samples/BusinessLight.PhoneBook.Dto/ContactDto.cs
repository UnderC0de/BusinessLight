namespace BusinessLight.PhoneBook.Dto
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using BusinessLight.Dto;

    public class ContactDto : Dto
    {
        [Display(Name = "First name")]
        public string FirstName { get; set; }
        [Display(Name = "Last name")]
        public string LastName { get; set; }
        [Display(Name = "BirthDate")]
        public DateTime BirthDate { get; set; }
        [Display(Name = "Number of contacts")]
        public int ContactInfosCount { get; set; }
    }
}
