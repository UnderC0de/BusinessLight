namespace BusinessLight.PhoneBook.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using BusinessLight.Data;
    using BusinessLight.Paging;
    using BusinessLight.Paging.Extensions;
    using BusinessLight.PhoneBook.Domain;
    using BusinessLight.PhoneBook.Dto;
    using BusinessLight.PhoneBook.Dto.Filters;
    using BusinessLight.PhoneBook.Service.Specifications;

    public class ContactApplicationService
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        public ContactApplicationService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
        }

        public IPagedList<ContactDto> Search(SearchContactDto searchContactDto)
        {
            using (var uow = unitOfWorkFactory.GetUnitOfWork())
            {
                var filter = Mapper.Map<SearchContactSpecification>(searchContactDto);
                //ValidateAndThrow(filter);

                return uow
                    .Repository
                    .IsSatisfiedBy(filter)
                    .ProjectTo<ContactDto>()
                    .ApplyPaging(searchContactDto.PageNumber, searchContactDto.PageSize);
            }
        }

        public ContactDetailDto GetDetail(Guid id)
        {
            using (var uow = unitOfWorkFactory.GetUnitOfWork())
            {
                return uow
                    .Repository
                    .IsSatisfiedBy(new SearchContactByIdSpecification(id))
                    .ProjectTo<ContactDetailDto>()
                    .Single();
            }
        }

        public ContactInfoDetailDto GetContactInfo(Guid id)
        {
            using (var uow = unitOfWorkFactory.GetUnitOfWork())
            {
                return uow
                    .Repository
                    .IsSatisfiedBy(new SearchContactInfoByIdSpecification(id))
                    .ProjectTo<ContactInfoDetailDto>()
                    .Single();
            }
        }

        public IEnumerable<ContactInfoDto> GetContactInfosForContact(Guid contactId)
        {
            using (var uow = unitOfWorkFactory.GetUnitOfWork())
            {
                return uow
                    .Repository
                    .IsSatisfiedBy(new SearchContactInfoByContactIdSpecification(contactId))
                    .ProjectTo<ContactInfoDto>()
                    .ToList();
            }
        }

        public void UpdateContact(ContactDetailDto contactDetailDto)
        {
            using (var uow = unitOfWorkFactory.GetUnitOfWork())
            {
                var contact = Mapper.Map<Contact>(contactDetailDto);
                // ValidateAndThrow(contact);

                uow.Repository.Update(contact);
                uow.Commit();
            }
        }

        public void CreateContact(ContactDetailDto contactDetailDto)
        {
            using (var uow = unitOfWorkFactory.GetUnitOfWork())
            {
                var contact = Mapper.Map<Contact>(contactDetailDto);
               // ValidateAndThrow(contact);

                uow.Repository.Add(contact);
                uow.Commit();
            }
        }

        public void DeleteContact(Guid id)
        {
            using (var uow = unitOfWorkFactory.GetUnitOfWork())
            {
                var contact = uow.Repository.GetById<Contact>(id);
                uow.Repository.Remove(contact);
                uow.Commit();
            }
        }

        public void DeleteContactInfo(Guid id)
        {
            using (var uow = unitOfWorkFactory.GetUnitOfWork())
            {
                var contact = uow.Repository.GetById<ContactInfo>(id);
                uow.Repository.Remove(contact);
                uow.Commit();
            }
        }

        public void CreateContactInfo(ContactInfoDetailDto contactInfoDetailDto)
        {
            using (var uow = unitOfWorkFactory.GetUnitOfWork())
            {
                var contactInfo = Mapper.Map<ContactInfo>(contactInfoDetailDto);
             //   ValidateAndThrow(contactInfo);

                uow.Repository.Add(contactInfo);
                uow.Commit();
            }
        }

        public void UpdateContactInfo(ContactInfoDetailDto contactInfoDetailDto)
        {
            using (var uow = unitOfWorkFactory.GetUnitOfWork())
            {
                var contactInfo = Mapper.Map<ContactInfo>(contactInfoDetailDto);
                //ValidateAndThrow(contactInfo);
                uow.Repository.Update(contactInfo);
                uow.Commit();
            }
        }
    }
}
