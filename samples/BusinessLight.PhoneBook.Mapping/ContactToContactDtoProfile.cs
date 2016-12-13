namespace BusinessLight.PhoneBook.Mapping
{
    using AutoMapper;

    using BusinessLight.PhoneBook.Domain;
    using BusinessLight.PhoneBook.Dto;

    public class ContactToContactDto : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Contact, ContactDto>()
                .ForMember(x => x.ContactInfosCount, opt => opt.MapFrom(y => y.ContactInfos.Count));
        }
    }
}