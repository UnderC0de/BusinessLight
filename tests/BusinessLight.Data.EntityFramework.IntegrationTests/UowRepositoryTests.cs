using System;
using System.Data.Entity;
using System.Linq;
using BusinessLight.Tests.Common.Entities;
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
}
