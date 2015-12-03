using System.ComponentModel.DataAnnotations;

namespace BusinessLight.Dto
{
    public abstract class PagedFilter
    {
        protected PagedFilter()
        {
            PageNumber = 0;
            PageSize = 10;
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