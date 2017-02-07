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

        public int PageNumber
        {
            get;
            set;
        }

        public int PageSize
        {
            get;
            set;
        }

        public string SortField
        {
            get;
            set;
        }

        public bool IsAscending
        {
            get; 
            set;
        }
    }
}