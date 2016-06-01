using System;
using System.Data.Entity;
using System.Linq;
using BusinessLight.Tests.Common.Entities;
using BusinessLight.Tests.Common.Specifications;
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

        [TestMethod]
        public void CanApplyQuery()
        {
            using (var unitOfWork = new EntityFrameworkUnitOfWork(new TestDbContext()))
            {
                var countFish = unitOfWork.Repository.Query<Fish>().Count();
                var queryFish = unitOfWork.Repository.IsSatisfiedBy(new SearchFishSpecification("Na")).ToList();
                queryFish.Count.Should().Be.EqualTo(countFish);
                queryFish = unitOfWork.Repository.IsSatisfiedBy(new SearchFishSpecification("")).ToList();
                queryFish.Count.Should().Be.EqualTo(countFish);
                queryFish = unitOfWork.Repository.IsSatisfiedBy(new SearchFishSpecification("notexistingname")).ToList();
                queryFish.Count.Should().Be.EqualTo(0);
            }
        }

        [TestMethod]
        public void CanApplySortedQuery()
        {
            using (var unitOfWork = new EntityFrameworkUnitOfWork(new TestDbContext()))
            {
                var allFishes = unitOfWork.Repository.Query<Fish>().OrderBy(x => x.Color).ToList();
                var queryFishes = unitOfWork.Repository.IsSatisfiedBy(new SearchFishSortedSpecification("Na", "Color", true)).ToList();
                queryFishes.Count.Should().Be.EqualTo(allFishes.Count);
                for (var i = 0; i < queryFishes.Count; i++)
                {
                    var fish = allFishes.ElementAt(i);
                    var queryFish = queryFishes.ElementAt(i);
                    fish.Name.Should().Be.EqualTo(queryFish.Name);
                    fish.Color.Should().Be.EqualTo(queryFish.Color);
                    fish.Should().Be.EqualTo(queryFish);
                }


                allFishes = unitOfWork.Repository.Query<Fish>().OrderByDescending(x => x.Color).ToList();
                queryFishes = unitOfWork.Repository.IsSatisfiedBy(new SearchFishSortedSpecification("Na", "Color", false)).ToList();
                queryFishes.Count.Should().Be.EqualTo(allFishes.Count);
                for (var i = 0; i < queryFishes.Count; i++)
                {
                    var fish = allFishes.ElementAt(i);
                    var queryFish = queryFishes.ElementAt(i);
                    fish.Name.Should().Be.EqualTo(queryFish.Name);
                    fish.Color.Should().Be.EqualTo(queryFish.Color);
                    fish.Should().Be.EqualTo(queryFish);
                }
            }
        }

        [TestMethod]
        public void CanAdd()
        {
            using (var unitOfWork = new EntityFrameworkUnitOfWork(new TestDbContext()))
            {
                var countFish = unitOfWork.Repository.Query<Fish>().Count();
                unitOfWork.Repository.Add(new Fish());
                unitOfWork.Commit();
                var newCountFish = unitOfWork.Repository.Query<Fish>().Count();
                newCountFish.Should().Be.EqualTo(countFish + 1);
            }
        }

        [TestMethod]
        public void CanRemove()
        {
            using (var unitOfWork = new EntityFrameworkUnitOfWork(new TestDbContext()))
            {
                var countFish = unitOfWork.Repository.Query<Fish>().Count();
                unitOfWork.Repository.Remove(unitOfWork.Repository.Query<Fish>().First());
                unitOfWork.Commit();
                var newCountFish = unitOfWork.Repository.Query<Fish>().Count();
                newCountFish.Should().Be.EqualTo(countFish - 1);
            }
        }

        [TestMethod]
        public void CanUpdate()
        {
            using (var unitOfWork = new EntityFrameworkUnitOfWork(new TestDbContext()))
            {
                var fish = unitOfWork.Repository.Query<Fish>().First();
                fish.Name.Should().Not.Be.EqualTo("NewName");
                fish.Name = "NewName";
                unitOfWork.Repository.Update(fish);
                unitOfWork.Commit();
                var updatedFish = unitOfWork.Repository.Query<Fish>().First(x => x.Id == fish.Id);
                updatedFish.Name.Should().Be.EqualTo("NewName");
            }
        }
    }
}
