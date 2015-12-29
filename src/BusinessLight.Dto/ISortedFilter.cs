namespace BusinessLight.Dto
{
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
}