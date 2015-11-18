using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLight.Paging
{
    public class PagedList<T> : IPagedList<T>
    {
        public PagedList()
        {
        }

        public PagedList(IQueryable<T> items, int pageNumber, int pageSize)
        {
            if (pageNumber < 0)
            {
                throw new ArgumentOutOfRangeException("pageNumber");
            }

            if (pageSize <= 0)
            {
                throw new ArgumentOutOfRangeException("pageSize");
            }

            var totalItemCount = items == null ? 0 : items.Count();
            PagingInfo = new PagingInfo(pageNumber, pageSize, totalItemCount);

            Result = items == null ? new List<T>() : items.Skip(pageNumber * pageSize).Take(pageSize).ToList();
        }

        public PagingInfo PagingInfo { get; private set; }
        public List<T> Result { get; private set; }
    }
}