using System.ComponentModel.DataAnnotations;
using BusinessLight.Dto;

namespace BusinessLight.PhoneBook.Dto.Filters
{
    public class SearchContactDto : PagedFilter
    {
        [Display(Name="First name")]
        public string FirstName
        {
            get;
            set;
        }

        [Display(Name = "Last name")]
        public string LastName
        {
            get;
            set;
        }

        [Display(Name = "BirthDate")]
        public string BirthDate
        {
            get; 
            set;
        }
    }
}