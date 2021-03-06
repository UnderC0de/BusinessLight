namespace BusinessLight.PhoneBook.Service.Specifications
{
    using System;
    using System.Linq.Expressions;
    using BusinessLight.Data;
    using BusinessLight.Data.Extensions;
    using BusinessLight.Data.Specifications;
    using BusinessLight.PhoneBook.Domain;

    public class SearchContactInfoByContactIdSpecification : Specification<ContactInfo>
    {
        public SearchContactInfoByContactIdSpecification(Guid contactId)
        {
            ContactId = contactId;
        }

        public Guid ContactId
        {
            get;
            private set;
        }

        public override Expression<Func<ContactInfo, bool>> GetSpecificationExpression()
        {
            var filter = base.GetSpecificationExpression();
            filter = filter.And(contactInfo => contactInfo.ContactId == ContactId);

            return filter;
        }
    }
}