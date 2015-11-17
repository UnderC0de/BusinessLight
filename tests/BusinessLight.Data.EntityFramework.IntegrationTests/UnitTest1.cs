using System;
using System.Data.Entity;
using System.Linq;
using BusinessLight.Tests.Common.Entities;
using BusinessLight.Tests.Common.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpTestsEx;

namespace BusinessLight.Data.EntityFramework.IntegrationTests
{
    [TestClass]
    public class UowRepositoryTests
    {
        public UowRepositoryTests()
        {
            Database.SetInitializer(new TestDbContextSeedInitializer());
        }

        [TestMethod]
        public void CanQuery()
        {
            using (var unitOfWork = new EntityFrameworkUnitOfWork(new TestDbContext()))
            {
                var countFish = unitOfWork.Repository.Query<Fish>().Count();
                var countCat = unitOfWork.Repository.Query<Cat>().Count();
                countFish.Should().Be.EqualTo(5);
                countCat.Should().Be.EqualTo(10);
            }
        }
    }

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

    public class TestDbContext : DbContext
    {
        public TestDbContext()
            : base("name=TestDbContext")
        {
        }

        // Explicit DbSets required only for IDatabaseInitializer
        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<Cat> Cats { get; set; }

        public virtual DbSet<Fish> Fishes { get; set; }
    }
}
