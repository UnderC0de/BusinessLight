using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BusinessLight.Tests.Common.Entities;
using FizzWare.NBuilder;

namespace BusinessLight.Data.EntityFramework.IntegrationTests
{
    public class TestDbContextSeedInitializer : DropCreateDatabaseAlways<TestDbContext>
    {
        protected override void Seed(TestDbContext context)
        {
            var fishes = Builder<Fish>.CreateListOfSize(5).Build().ToList();
            var cats = Builder<Cat>.CreateListOfSize(10).Build().ToList();
            context.Set<Fish>().AddRange(fishes);
            context.Set<Cat>().AddRange(cats);
            context.SaveChanges();
        }
    }
}