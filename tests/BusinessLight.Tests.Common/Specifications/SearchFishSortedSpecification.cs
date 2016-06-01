using System;
using System.Linq;
using System.Linq.Expressions;
using BusinessLight.Data;
using BusinessLight.Data.Extensions;
using BusinessLight.Tests.Common.Entities;

namespace BusinessLight.Tests.Common.Specifications
{
    public class SearchFishSortedSpecification : SortedSpecification<Fish>
    {
        public SearchFishSortedSpecification(string name, string sortField, bool isAscending)
        {
            Name = name;
            SortField = sortField;
            IsAscending = isAscending;
        }

        public string Name
        {
            get;
            set;
        }

        public override Expression<Func<Fish, bool>> GetSpecificationExpression()
        {
            var query = base.GetSpecificationExpression();
            if (!string.IsNullOrWhiteSpace(Name))
            {
                if (!string.IsNullOrWhiteSpace(Name))
                {
                    query = query.And(item => item.Name.Contains(Name));
                }
            }
            return query;
        }

        public override Func<IQueryable<Fish>, IOrderedQueryable<Fish>> GetSortingExpression()
        {
            switch (SortField)
            {
                case "Name":
                    if (IsAscending)
                    {
                        return items => items.OrderBy(x => x.Name);
                    }
                    return items => items.OrderByDescending(x => x.Name);

                case "Color":
                    if (IsAscending)
                    {
                        return items => items.OrderBy(x => x.Color);
                    }
                    return items => items.OrderByDescending(x => x.Color);
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