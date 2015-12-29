using System;
using BusinessLight.Data;
using BusinessLight.PhoneBook.Domain;

namespace BusinessLight.PhoneBook.Service.Queries
{
    public class SearchContactByIdQuery : QueryById<Contact>
    {
        public SearchContactByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}