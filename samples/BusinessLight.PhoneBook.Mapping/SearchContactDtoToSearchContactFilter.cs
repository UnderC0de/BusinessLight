﻿using AutoMapper;
using BusinessLight.PhoneBook.Dto.Filters;
using BusinessLight.PhoneBook.Service.Specifications;

namespace BusinessLight.PhoneBook.Mapping
{
    public class SearchContactDtoToSearchContactFilterProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<SearchContactDto, SearchContactSpecification>();
        }
    }
}
