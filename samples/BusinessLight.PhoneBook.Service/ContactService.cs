using System;
using System.Linq;
using System.Xml.Schema;
using BusinessLight.Data;
using BusinessLight.Mapping;
using BusinessLight.Mapping.AutoMapper.Extensions;
using BusinessLight.Paging;
using BusinessLight.Paging.Extensions;
using BusinessLight.PhoneBook.Domain;
using BusinessLight.PhoneBook.Dto;
using BusinessLight.PhoneBook.Dto.Filters;
using BusinessLight.PhoneBook.Service.Filters;
using BusinessLight.Service;
using BusinessLight.Validation;

namespace BusinessLight.PhoneBook.Service
{
    public class ContactService : ServiceBase
    {
        public ContactService(IUnitOfWork unitOfWork, IMapper mapper, IValidationFactory validationFactory)
            : base(unitOfWork, mapper, validationFactory)
        {
        }

        public IPagedList<ContactDto> Search(SearchContactDto searchContactDto)
        {
            using (var uow = GetUnitOfWork())
            {
               var filter = GetMapper()
                   .Map<SearchContactFilter, SearchContactDto>(searchContactDto);

                var validator = GetValidationFactory().GetValidatorFor<SearchContactFilter>();

                var validationResult = validator.GetValidationResult(filter);

                if (validationResult.HasErrors)
                {
                    throw new ValidationException(validationResult);
                }

                return uow.Repository
                    .ApplyFilter(filter)
                    .ApplyProjection<ContactDto>()
                    .OrderBy(x => x.BirthDate)
                    .ApplyPaging(searchContactDto.PageNumber, searchContactDto.PageSize);
            }
        }

        public ContactDetailDto GetDetail(Guid id)
        {
            using (var uow = GetUnitOfWork())
            {
                return GetMapper()
                    .Map<ContactDetailDto, Contact>(uow.Repository.GetById<Contact>(id));
            }
        }
    }
}
