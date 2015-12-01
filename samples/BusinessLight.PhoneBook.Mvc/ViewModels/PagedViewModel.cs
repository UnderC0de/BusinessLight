using BusinessLight.Dto;
using BusinessLight.Paging;

namespace BusinessLight.PhoneBook.Mvc.ViewModels
{
    public abstract class PagedViewModel<TFilter, TResult> 
        where TFilter : PagedFilter
        where TResult : UniqueEntityDto
    {
        public TFilter PagedFilter
        {
            get;
            set;
        }

        public IPagedList<TResult> PagedResult
        {
            get;
            set;
        }
    }
}