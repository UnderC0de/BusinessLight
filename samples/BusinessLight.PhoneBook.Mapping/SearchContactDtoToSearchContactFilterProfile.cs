namespace BusinessLight.PhoneBook.Mapping
{
    using AutoMapper;

    using BusinessLight.PhoneBook.Dto.Filters;
    using BusinessLight.PhoneBook.Service.Specifications;

    public class SearchContactDtoToSearchContactFilterProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<SearchContactDto, SearchContactSpecification>();
        }
    }
}
