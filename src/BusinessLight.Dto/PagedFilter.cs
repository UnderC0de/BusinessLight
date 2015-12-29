using System.ComponentModel.DataAnnotations;

namespace BusinessLight.Dto
{
    public interface IPagedFilter
    {
        int PageNumber { get; set; }
        int PageSize { get; set; }
    }

    public abstract class PagedFilter : IPagedFilter
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

    public interface ISortedFilter
    {
        string SortField
        {
            get;
            set;
        }

        bool IsAscending
        {
            get;
            set;
        }
    }

    public abstract class SortedFilter : ISortedFilter
    {
        protected SortedFilter()
        {
            SortField = string.Empty;
            IsAscending = true;
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

    public abstract class SortedPagedFilter : IPagedFilter, ISortedFilter
    {
        protected SortedPagedFilter()
        {
            PageNumber = 0;
            PageSize = 10;
            SortField = string.Empty;
            IsAscending = true;
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