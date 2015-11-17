using System.Data.Entity;
using BusinessLight.Tests.Common.Entities;
using BusinessLight.Tests.Common.Helpers;

namespace BusinessLight.Data.EntityFramework.IntegrationTests
{
    public class TestDbContextSeedInitializer : DropCreateDatabaseAlways<TestDbContext>
    {
        protected override void Seed(TestDbContext context)
        {
            var fishes = DataHelper.CreateNewList<Fish>(5);
            var cats = DataHelper.CreateNewList<Cat>(10);
            context.Set<Fish>().AddRange(fishes);
            context.Set<Cat>().AddRange(cats);
            context.SaveChanges();
        }
    }
}