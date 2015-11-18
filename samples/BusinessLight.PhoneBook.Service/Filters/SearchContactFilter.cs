using System;
using System.Linq.Expressions;
using BusinessLight.Data;
using BusinessLight.PhoneBook.Domain;

namespace BusinessLight.PhoneBook.Service.Filters
{
    public class SearchContactFilter : IFilter<Contact>
    {
        public string Name
        {
            get; 
            set;
        }

        public Expression<Func<Contact, bool>> GetFilterExpression()
        {
            return contact => contact.FirstName.Contains(Name) || contact.LastName.Contains(Name);
        }
    }
}