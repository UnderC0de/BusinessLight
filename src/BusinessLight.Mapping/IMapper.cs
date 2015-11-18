using System.Linq;

namespace BusinessLight.Mapping
{
    public interface IMapper
    {
        IQueryable<TDestination> ProjectTo<TDestination, TSource>(IQueryable<TSource> source);

        TDestination Map<TDestination, TSource>(TSource source);
    }
}
