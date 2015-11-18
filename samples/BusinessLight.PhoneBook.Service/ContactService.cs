using System;
using System.Linq.Expressions;
using BusinessLight.Data;
using BusinessLight.Mapping;
using BusinessLight.Mapping.AutoMapper.Extensions;
using BusinessLight.Paging;
using BusinessLight.Paging.Extensions;
using BusinessLight.PhoneBook.Domain;
using BusinessLight.PhoneBook.Dto;
using BusinessLight.PhoneBook.Dto.Filters;
using BusinessLight.Service;

namespace BusinessLight.PhoneBook.Service
{
    public class ContactService : ServiceBase
    {
        public IMapper Mapper { get; set; }

        public ContactService(IUnitOfWork unitOfWork, IMapper mapper) 
            : base(unitOfWork)
        {
            Mapper = mapper;
        }

        public IPagedList<ContactDto> Search(SearchContactDto searchContactDto)
        {
            using (var uow = GetUnitOfWork())
            {
               var filter = Mapper.Map<SearchContactFilter, SearchContactDto>(searchContactDto);
               return uow.Repository
                    .ApplyFilter(filter)
                    .ApplyProjection<ContactDto>()
                    .ApplyPaging(searchContactDto.PageNumber, searchContactDto.PageSize);
            }
        }
    }

    public class SearchContactFilter : IFilter<Contact>
    {
        public string Name
        {
            get; 
            set;
        }

        public Expression<Func<Contact, bool>> GetFilterExpression()
        {
            return contact => contact.FirstName.Contains(Name) || contact.LastName.Contains(Name);
        }
    }
}
