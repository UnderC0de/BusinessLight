namespace BusinessLight.PhoneBook.Service.Specifications
{
    using System;
    using BusinessLight.Data;
    using BusinessLight.PhoneBook.Domain;

    public class SearchContactByIdSpecification : SpecificationById<Contact>
    {
        public SearchContactByIdSpecification(Guid id)
        {
            Id = id;
        }
    }
}