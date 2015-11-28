using BusinessLight.Paging;
using BusinessLight.PhoneBook.Dto;
using BusinessLight.PhoneBook.Dto.Filters;

namespace BusinessLight.PhoneBook.Mvc.ViewModels
{
    public class SearchContactViewModel
    {
        public SearchContactDto SearchContactDto
        {
            get;
            set;
        }

        public IPagedList<ContactDto> PagedResult
        {
            get;
            set;
        }
    }
}
