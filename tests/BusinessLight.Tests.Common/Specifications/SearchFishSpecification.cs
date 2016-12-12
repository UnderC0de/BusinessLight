using System;
using System.Linq.Expressions;
using BusinessLight.Data;
using BusinessLight.Data.Extensions;
using BusinessLight.Tests.Common.Entities;

namespace BusinessLight.Tests.Common.Specifications
{
    using BusinessLight.Data.Specifications;

    public class SearchFishSpecification : Specification<Fish>
    {
        public SearchFishSpecification(string name)
        {
            Name = name;
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
    }
}
