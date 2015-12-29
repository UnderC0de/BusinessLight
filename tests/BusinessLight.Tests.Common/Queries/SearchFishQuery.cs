using System;
using System.Linq.Expressions;
using BusinessLight.Data;
using BusinessLight.Data.Extensions;
using BusinessLight.Tests.Common.Entities;

namespace BusinessLight.Tests.Common.Queries
{
    public class SearchFishQuery : Query<Fish>
    {
        public SearchFishQuery(string name)
        {
            Name = name;
        }

        public string Name
        {
            get;
            set;
        }

        public override Expression<Func<Fish, bool>> GetFilterExpression()
        {
            var query = base.GetFilterExpression();
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
