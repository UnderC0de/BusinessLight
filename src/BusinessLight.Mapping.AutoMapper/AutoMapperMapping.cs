namespace BusinessLight.Mapping.AutoMapper
{
    using System.Linq;

    using global::AutoMapper;

    using global::AutoMapper.QueryableExtensions;

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
