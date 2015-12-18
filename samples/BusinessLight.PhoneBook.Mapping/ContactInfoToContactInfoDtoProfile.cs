using AutoMapper;
using BusinessLight.PhoneBook.Domain;
using BusinessLight.PhoneBook.Dto;

namespace BusinessLight.PhoneBook.Mapping
{
    public class ContactInfoToContactInfoDto : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<ContactInfo, ContactInfoDto >();
        }
    }

    public class ContactInfoToContactInfoDetailDto : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<ContactInfo, ContactInfoDetailDto>();
        }
    }
}