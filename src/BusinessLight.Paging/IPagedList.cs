using System.Collections.Generic;

namespace BusinessLight.Paging
{
    public interface IPagedList<T>
    {
        PagingInfo PagingInfo { get; }

        List<T> Result { get; }
    }
}