using System;
using System.Linq.Expressions;
using BusinessLight.Data;
using BusinessLight.Data.Extensions;
using BusinessLight.PhoneBook.Domain;

namespace BusinessLight.PhoneBook.Service.Queries
{
    public class SearchContactInfoByContactIdQuery : Query<ContactInfo>
    {
        public SearchContactInfoByContactIdQuery(Guid contactId)
        {
            ContactId = contactId;
        }

        public Guid ContactId
        {
            get;
            private set;
        }

        public override Expression<Func<ContactInfo, bool>> GetFilterExpression()
        {
            var filter = base.GetFilterExpression();
            filter = filter.And(contactInfo => contactInfo.ContactId == ContactId);

            return filter;
        }
    }
}