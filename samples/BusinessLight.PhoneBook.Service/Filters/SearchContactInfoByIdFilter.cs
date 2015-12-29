using System;
using BusinessLight.Data;
using BusinessLight.PhoneBook.Domain;

namespace BusinessLight.PhoneBook.Service.Filters
{
    public class SearchContactInfoByIdQuery : QueryById<ContactInfo>
    {
        public SearchContactInfoByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}