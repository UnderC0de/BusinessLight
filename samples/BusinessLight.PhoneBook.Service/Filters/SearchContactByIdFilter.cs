using System;
using System.Linq.Expressions;
using BusinessLight.Data;
using BusinessLight.Data.Extensions;
using BusinessLight.PhoneBook.Domain;

namespace BusinessLight.PhoneBook.Service.Filters
{
    public class SearchContactByIdFilter : Filter<Contact>
    {
        public SearchContactByIdFilter(Guid id)
        {
            Id = id;
        }

        public Guid Id
        {
            get;
            set;
        }

        public override Expression<Func<Contact, bool>> GetFilterExpression()
        {
            var filter = base.GetFilterExpression();
            filter = filter.And(contact => contact.Id == Id);

            return filter;
        }
    }
}