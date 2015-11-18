using BusinessLight.Dto;

namespace BusinessLight.PhoneBook.Dto.Filters
{
    public class SearchContactDto : PagedFilter
    {
        public string Name { get; set; }
    }
}