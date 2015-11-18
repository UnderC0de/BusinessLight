using System;

namespace BusinessLight.Paging
{
    public class PagingInfo
    {
        public PagingInfo()
        {
        }

        public PagingInfo(int pageNumber, int pageSize, int totalItemCount)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalItemCount = totalItemCount;
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

        public int TotalItemCount
        {
            get;
            set;
        }

        public int PageCount
        {
            get
            {
                return TotalItemCount > 0
                    ? (int)Math.Ceiling(TotalItemCount / (double)PageSize)
                    : 0;
            }
        }

        public bool HasPreviousPage
        {
            get
            {
                return PageNumber > 0;
            }
        }

        public bool HasNextPage
        {
            get
            {
                return PageNumber < PageCount - 1;
            }
        }

        public bool IsFirstPage
        {
            get
            {
                return PageNumber == 0;
            }
        }

        public bool IsLastPage
        {
            get
            {
                return PageNumber == PageCount - 1;
            }
        }

        public int FirstItemOnPage
        {
            get
            {
                return PageNumber * PageSize;
            }
        }

        public int LastItemOnPage
        {
            get
            {
                var numberOfLastItemOnPage = FirstItemOnPage + PageSize - 1;
                return numberOfLastItemOnPage > TotalItemCount
                    ? TotalItemCount
                    : numberOfLastItemOnPage;
            }
        }
    }
}
