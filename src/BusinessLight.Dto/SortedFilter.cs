
namespace BusinessLight.Dto
{
    public abstract class SortedFilter : ISortedFilter
    {
        protected SortedFilter()
        {
            SortField = Costants.DefaultSortField;
            IsAscending = Costants.DefaultIsAscending;
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