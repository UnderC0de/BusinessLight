using System;
using BusinessLight.Data;
using BusinessLight.PhoneBook.Domain;

namespace BusinessLight.PhoneBook.Service.Queries
{
    public class SearchContactInfoByIdQuery : QueryById<ContactInfo>
    {
        public SearchContactInfoByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}