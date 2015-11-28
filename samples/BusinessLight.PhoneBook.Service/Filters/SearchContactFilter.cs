using System;
using System.Linq.Expressions;
using BusinessLight.Data;
using BusinessLight.Data.Extensions;
using BusinessLight.PhoneBook.Domain;

namespace BusinessLight.PhoneBook.Service.Filters
{
    public class SearchContactFilter : Filter<Contact>
    {
        public string FirstName
        {
            get; 
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public override Expression<Func<Contact, bool>> GetFilterExpression()
        {
            var filter = base.GetFilterExpression();

            if (!string.IsNullOrWhiteSpace(FirstName))
            {
                filter = filter.And(contact => contact.FirstName.Contains(FirstName));
            }

            if (!string.IsNullOrWhiteSpace(LastName))
            {
                filter = filter.And(contact => contact.LastName.Contains(LastName));
            }
            
            return filter;
        }
    }
}