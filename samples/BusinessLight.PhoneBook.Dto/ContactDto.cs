using System;
using System.ComponentModel.DataAnnotations;
using BusinessLight.Dto;

namespace BusinessLight.PhoneBook.Dto
{
    public class ContactDto : UniqueEntityDto
    {
        [Display(Name = "First name")]
        public string FirstName { get; set; }
        [Display(Name = "Last name")]
        public string LastName { get; set; }
        [Display(Name = "BirthDate")]
        public DateTime BirthDate { get; set; }
        [Display(Name = "Note")]
        public string Note { get; set; }
        [Display(Name = "Number of contacts")]
        public int ContactInfosCount { get; set; }
    }
}
