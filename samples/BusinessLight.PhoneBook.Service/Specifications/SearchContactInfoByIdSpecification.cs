namespace BusinessLight.PhoneBook.Service.Specifications
{
    using System;
    using BusinessLight.Data;
    using BusinessLight.Data.Specifications;
    using BusinessLight.PhoneBook.Domain;

    public class SearchContactInfoByIdSpecification : SpecificationById<ContactInfo>
    {
        public SearchContactInfoByIdSpecification(Guid id)
        {
            Id = id;
        }
    }
}