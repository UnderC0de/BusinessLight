using System;
using BusinessLight.Data;
using BusinessLight.PhoneBook.Domain;

namespace BusinessLight.PhoneBook.Service.Specifications
{
    public class SearchContactInfoByIdSpecification : SpecificationById<ContactInfo>
    {
        public SearchContactInfoByIdSpecification(Guid id)
        {
            Id = id;
        }
    }
}