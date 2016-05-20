namespace BusinessLight.Paging
{
    public interface IPagingInfo
    {
        int PageNumber { get; set; }
        int PageSize { get; set; }
        int TotalItemCount { get; set; }
        int PageCount { get; }
        bool HasPreviousPage { get; }
        bool HasNextPage { get; }
        bool IsFirstPage { get; }
        bool IsLastPage { get; }
        int FirstItemOnPage { get; }
        int LastItemOnPage { get; }
    }
}