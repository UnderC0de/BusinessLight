using System.Collections.Generic;

namespace BusinessLight.Paging
{
    public class StaticPagedList<T> : IPagedList<T>
    {
        public StaticPagedList(List<T> subset, PagingInfo pagingInfo)
        {
            PagingInfo = pagingInfo;
            Result = subset;
        }
        public PagingInfo PagingInfo { get; private set; }
        public List<T> Result { get; private set; }
    }
}