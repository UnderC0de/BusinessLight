namespace BusinessLight.PhoneBook.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

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

        public async Task<IPagedList<ContactDto>> SearchAsync(SearchContactDto searchContactDto)
        {
            using (var uow = this.unitOfWorkFactory.GetUnitOfWork())
            {
                var filter = Mapper.Map<SearchContactSpecification>(searchContactDto);
                //ValidateAndThrow(filter);

                return (await uow
                    .Repository
                    .IsSatisfiedByAsync(filter))
                    .ProjectTo<ContactDto>()
                    .ApplyPaging(searchContactDto.PageNumber, searchContactDto.PageSize);
            }
        }

        public async Task<ContactDetailDto> GetDetailAsync(Guid id)
        {
            using (var uow = this.unitOfWorkFactory.GetUnitOfWork())
            {
                return (await uow
                    .Repository
                    .IsSatisfiedByAsync(new SearchContactByIdSpecification(id)))
                    .ProjectTo<ContactDetailDto>()
                    .Single();
            }
        }

        public async Task<ContactInfoDetailDto> GetContactInfoAsync(Guid id)
        {
            using (var uow = this.unitOfWorkFactory.GetUnitOfWork())
            {
                return (await uow
                    .Repository
                    .IsSatisfiedByAsync(new SearchContactInfoByIdSpecification(id)))
                    .ProjectTo<ContactInfoDetailDto>()
                    .Single();
            }
        }

        public async Task<IEnumerable<ContactInfoDto>> GetContactInfosForContactAsync(Guid contactId)
        {
            using (var uow = this.unitOfWorkFactory.GetUnitOfWork())
            {
                return (await uow
                    .Repository
                    .IsSatisfiedByAsync(new SearchContactInfoByContactIdSpecification(contactId)))
                    .ProjectTo<ContactInfoDto>()
                    .ToList();
            }
        }

        public async Task UpdateContactAsync(ContactDetailDto contactDetailDto)
        {
            using (var uow = unitOfWorkFactory.GetUnitOfWork())
            {
                var contact = Mapper.Map<Contact>(contactDetailDto);

                await uow.Repository.UpdateAsync(contact);
                await uow.CommitAsync();
            }
        }

        public async Task CreateContactAsync(ContactDetailDto contactDetailDto)
        {
            using (var uow = unitOfWorkFactory.GetUnitOfWork())
            {
                var contact = Mapper.Map<Contact>(contactDetailDto);
               // ValidateAndThrow(contact);

                await uow.Repository.AddAsync(contact);
                await uow.CommitAsync();
            }
        }

        public async Task DeleteContactAsync(Guid id)
        {
            using (var uow = unitOfWorkFactory.GetUnitOfWork())
            {
                var contact = await uow.Repository.GetByIdAsync<Contact>(id);
                await uow.Repository.RemoveAsync(contact);
                await uow.CommitAsync();
            }
        }

        public async Task DeleteContactInfoAsync(Guid id)
        {
            using (var uow = unitOfWorkFactory.GetUnitOfWork())
            {
                var contact = await uow.Repository.GetByIdAsync<ContactInfo>(id);
                await uow.Repository.RemoveAsync(contact);
                await uow.CommitAsync();
            }
        }

        public async Task CreateContactInfoAsync(ContactInfoDetailDto contactInfoDetailDto)
        {
            using (var uow = unitOfWorkFactory.GetUnitOfWork())
            {
                var contactInfo = Mapper.Map<ContactInfo>(contactInfoDetailDto);
             //   ValidateAndThrow(contactInfo);

                await uow.Repository.AddAsync(contactInfo);
                await uow.CommitAsync();
            }
        }

        public async Task UpdateContactInfoAsync(ContactInfoDetailDto contactInfoDetailDto)
        {
            using (var uow = unitOfWorkFactory.GetUnitOfWork())
            {
                var contactInfo = Mapper.Map<ContactInfo>(contactInfoDetailDto);
                //ValidateAndThrow(contactInfo);
                await uow.Repository.UpdateAsync(contactInfo);
                await uow.CommitAsync();
            }
        }
    }
}
