using System.ComponentModel.DataAnnotations;

namespace BusinessLight.Dto
{
    public abstract class SortedPagedFilter : IPagedFilter, ISortedFilter
    {
        protected SortedPagedFilter()
        {
            PageNumber = Costants.DefaultPageNumber;
            PageSize = Costants.DefaultPageSize;
            SortField = Costants.DefaultSortField;
            IsAscending = Costants.DefaultIsAscending;
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

        [Display(Name = "Sort field")]
        public string SortField
        {
            get;
            set;
        }

        [Display(Name = "Is ascending")]
        public bool IsAscending
        {
            get; 
            set;
        }
    }
}