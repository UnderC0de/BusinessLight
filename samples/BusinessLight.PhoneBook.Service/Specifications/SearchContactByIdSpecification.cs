using System;
using BusinessLight.Data;
using BusinessLight.PhoneBook.Domain;

namespace BusinessLight.PhoneBook.Service.Specifications
{
    public class SearchContactByIdSpecification : SpecificationById<Contact>
    {
        public SearchContactByIdSpecification(Guid id)
        {
            Id = id;
        }
    }
}