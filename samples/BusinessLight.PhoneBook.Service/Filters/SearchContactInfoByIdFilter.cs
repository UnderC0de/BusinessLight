using System;
using System.Linq.Expressions;
using BusinessLight.Data;
using BusinessLight.Data.Extensions;
using BusinessLight.PhoneBook.Domain;

namespace BusinessLight.PhoneBook.Service.Filters
{
    public class SearchContactInfoByIdFilter : Filter<ContactInfo>
    {
        public SearchContactInfoByIdFilter(Guid id)
        {
            Id = id;
        }

        public Guid Id
        {
            get;
            private set;
        }

        public override Expression<Func<ContactInfo, bool>> GetFilterExpression()
        {
            var filter = base.GetFilterExpression();
            filter = filter.And(contactInfo => contactInfo.Id == Id);

            return filter;
        }
    }
}