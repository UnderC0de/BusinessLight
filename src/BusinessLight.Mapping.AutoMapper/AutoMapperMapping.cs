using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace BusinessLight.Mapping.AutoMapper
{
    public class AutoMapperMapping : IMapper
    {
        public IQueryable<TDestination> ProjectTo<TDestination, TSource>(IQueryable<TSource> source)
        {
            return source.ProjectTo<TDestination>();
        }

        public TDestination Map<TDestination, TSource>(TSource source)
        {
            return Mapper.Map<TDestination>(source); 
        }
    }
}
