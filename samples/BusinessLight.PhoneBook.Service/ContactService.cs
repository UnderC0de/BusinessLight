using System;
using System.Collections.Generic;
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
        public ContactCrudService(IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper, IValidationFactory validationFactory)
            : base(unitOfWorkFactory, mapper, validationFactory)
        {
        }

        public IPagedList<ContactDto> Search(SearchContactDto searchContactDto)
        {
            using (var uow = GetUnitOfWork())
            {
                var filter = GetMapper()
                    .Map<SearchContactQuery, SearchContactDto>(searchContactDto);

                var validator = GetValidationFactory().GetValidatorFor<SearchContactQuery>();
                if (validator != null)
                {
                    var validationResult = validator.GetValidationResult(filter);

                    if (validationResult.HasErrors)
                    {
                        throw new ValidationException(validationResult);
                    }
                }

                return uow
                    .Repository
                    .ApplyQuery(filter)
                    .ApplyProjection<ContactDto>()
                    .ApplyPaging(searchContactDto.PageNumber, searchContactDto.PageSize);
            }
        }

        public ContactDetailDto GetDetail(Guid id)
        {
            using (var uow = GetUnitOfWork())
            {
                return uow
                    .Repository
                    .ApplyQuery(new SearchContactByIdQuery(id))
                    .ApplyProjection<ContactDetailDto>()
                    .Single();
            }
        }

        public ContactInfoDetailDto GetContactInfo(Guid id)
        {
            using (var uow = GetUnitOfWork())
            {
                return uow
                    .Repository
                    .ApplyQuery(new SearchContactInfoByIdQuery(id))
                    .ApplyProjection<ContactInfoDetailDto>()
                    .Single();
            }
        }

        public IEnumerable<ContactInfoDto> GetContactInfosForContact(Guid contactId)
        {
            using (var uow = GetUnitOfWork())
            {
                return uow
                    .Repository
                    .ApplyQuery(new SearchContactInfoByContactIdQuery(contactId))
                    .ApplyProjection<ContactInfoDto>()
                    .ToList();
            }
        }

        public void UpdateContact(ContactDetailDto contactDetailDto)
        {
            using (var uow = GetUnitOfWork())
            {
                var contact = GetMapper().Map<Contact, ContactDetailDto>(contactDetailDto);
                var validator = GetValidationFactory().GetValidatorFor<Contact>();
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
                var validator = GetValidationFactory().GetValidatorFor<Contact>();
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

        public void DeleteContactInfo(Guid id)
        {
            using (var uow = GetUnitOfWork())
            {
                var contact = uow.Repository.GetById<ContactInfo>(id);
                uow.Repository.Remove(contact);
                uow.Commit();
            }
        }

        public void CreateContactInfo(ContactInfoDetailDto contactInfoDetailDto)
        {
            using (var uow = GetUnitOfWork())
            {
                var contactInfo = GetMapper().Map<ContactInfo, ContactInfoDetailDto>(contactInfoDetailDto);
                var validator = GetValidationFactory().GetValidatorFor<ContactInfo>();
                if (validator != null)
                {
                    var validationResult = validator.GetValidationResult(contactInfo);

                    if (validationResult.HasErrors)
                    {
                        throw new ValidationException(validationResult);
                    }
                }

                uow.Repository.Add(contactInfo);
                uow.Commit();
            }
        }

        public void UpdateContactInfo(ContactInfoDetailDto contactInfoDetailDto)
        {
            using (var uow = GetUnitOfWork())
            {
                var contactInfo = GetMapper().Map<ContactInfo, ContactInfoDetailDto>(contactInfoDetailDto);
                var validator = GetValidationFactory().GetValidatorFor<ContactInfo>();
                if (validator != null)
                {
                    var validationResult = validator.GetValidationResult(contactInfo);

                    if (validationResult.HasErrors)
                    {
                        throw new ValidationException(validationResult);
                    }
                }

                uow.Repository.Update(contactInfo);
                uow.Commit();
            }
        }
    }

   
}
