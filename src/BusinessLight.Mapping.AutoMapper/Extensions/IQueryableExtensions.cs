using System.Linq;
using AutoMapper.QueryableExtensions;

namespace BusinessLight.Mapping.AutoMapper.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<TDestination> ApplyProjection<TDestination>(this IQueryable source)
        {
            return source.ProjectTo<TDestination>();
        }
    }
}
