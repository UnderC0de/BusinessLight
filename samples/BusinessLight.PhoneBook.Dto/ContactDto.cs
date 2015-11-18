using System;
using BusinessLight.Dto;

namespace BusinessLight.PhoneBook.Dto
{
    public class ContactDto : UniqueEntityDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string Note { get; set; }

        public int ContactInfoCount { get; set; }
    }
}
