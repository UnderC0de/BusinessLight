namespace BusinessLight.PhoneBook.Mvc.ViewModels
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    using BusinessLight.Dto;
    using BusinessLight.Paging;

    public abstract class PagedViewModel<TFilter, TResult>
        where TFilter : IPagedFilter
        where TResult : Dto
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

        public IEnumerable<SelectListItem> PageSizeItems => new[] 
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