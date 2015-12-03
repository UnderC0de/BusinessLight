using System.Collections.Generic;
using System.Web.Mvc;
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

        public IEnumerable<SelectListItem> PageSizeItems
        {
            get
            {
                return new[] 
                {
                    new SelectListItem
                    {
                        Value = "10",
                        Text = "10"
                    }, 
                    new SelectListItem
                    {
                        Value = "25",
                        Text = "25"
                    },
                    new SelectListItem
                    {
                        Value = "50",
                        Text = "50"
                    }
                };
            }
        }
    }
}