using AutoMapper;
using BusinessLight.PhoneBook.Domain;
using BusinessLight.PhoneBook.Dto;

namespace BusinessLight.PhoneBook.Mapping
{
    public class ContactDtoToContactProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<ContactDto, Contact>();
        }
    }
}