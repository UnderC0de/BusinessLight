using System.ComponentModel.DataAnnotations;

namespace BusinessLight.Dto
{
    public abstract class PagedFilter : IPagedFilter
    {
     

        protected PagedFilter()
        {
            PageNumber = Costants.DefaultPageNumber;
            PageSize = Costants.DefaultPageSize;
        }

        [Display(Name = "Page number")]
        public int PageNumber
        {
            get;
            set;
        }

        [Display(Name = "Page size")]
        public int PageSize
        {
            get;
            set;
        }
    }
}