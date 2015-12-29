using System;
using System.Linq;
using System.Linq.Expressions;
using BusinessLight.Data;
using BusinessLight.Data.Extensions;
using BusinessLight.PhoneBook.Domain;

namespace BusinessLight.PhoneBook.Service.Filters
{
    public class SearchContactQuery : SortedQuery<Contact>
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

        public override Func<IQueryable<Contact>, IOrderedQueryable<Contact>> GetSortingExpression()
        {
            switch (SortField)
            {
                case "FirstName":
                    if (IsAscending)
                    {
                        return items => items.OrderBy(x => x.FirstName);
                    }
                    return items => items.OrderByDescending(x => x.FirstName);

                case "LastName":
                    if (IsAscending)
                    {
                        return items => items.OrderBy(x => x.LastName);
                    }
                    return items => items.OrderByDescending(x => x.LastName);
                case "BirthDate":
                    if (IsAscending)
                    {
                        return items => items.OrderBy(x => x.BirthDate);
                    }
                    return items => items.OrderByDescending(x => x.BirthDate);
                default:
                    if (IsAscending)
                    {
                        return items => items.OrderBy(x => x.Id);
                    }
                    return items => items.OrderByDescending(x => x.Id);
            }
        }
    }
}