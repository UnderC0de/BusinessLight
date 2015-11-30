using System;
using System.Linq;
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
    public class ContactCrudService : CrudServiceBase
    {
        public ContactCrudService(IUnitOfWork unitOfWork, IMapper mapper, IValidationFactory validationFactory)
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
                if (validator != null)
                {
                    var validationResult = validator.GetValidationResult(filter);

                    if (validationResult.HasErrors)
                    {
                        throw new ValidationException(validationResult);
                    }
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

        public void UpdateContact(ContactDetailDto contactDetailDto)
        {
            using (var uow = GetUnitOfWork())
            {
                var contact = GetMapper().Map<Contact, ContactDetailDto>(contactDetailDto);
                var validator = GetValidationFactory().GetValidatorFor<Contact>(ValidationContext.Edit);
                if (validator != null)
                {
                    var validationResult = validator.GetValidationResult(contact);

                    if (validationResult.HasErrors)
                    {
                        throw new ValidationException(validationResult);
                    }
                }

                uow.Repository.Update(contact);
                uow.Commit();
            }
        }

        public void CreateContact(ContactDetailDto contactDetailDto)
        {
            using (var uow = GetUnitOfWork())
            {
                var contact = GetMapper().Map<Contact, ContactDetailDto>(contactDetailDto);
                var validator = GetValidationFactory().GetValidatorFor<Contact>(ValidationContext.Create);
                if (validator != null)
                {
                    var validationResult = validator.GetValidationResult(contact);

                    if (validationResult.HasErrors)
                    {
                        throw new ValidationException(validationResult);
                    }
                }

                uow.Repository.Add(contact);
                uow.Commit();
            }
        }

        public void DeleteContact(Guid id)
        {
            using (var uow = GetUnitOfWork())
            {
                var contact = uow.Repository.GetById<Contact>(id);
                uow.Repository.Remove(contact);
                uow.Commit();
            }
        }
    }
}
