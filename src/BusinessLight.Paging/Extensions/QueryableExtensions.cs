using System.Linq;

namespace BusinessLight.Paging.Extensions
{
    public static class QueryableExtensions
    {
        public static PagedList<T> ToPagedList<T>(this IQueryable<T> items, int pageNumber, int pageSize)
        {
            return new PagedList<T>(items, pageNumber, pageSize);
        }
    }
}
