using System.Collections;
using System.Linq;
using BusinessLight.Tests.Common.Entities;
using BusinessLight.Tests.Common.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpTestsEx;

namespace BusinessLight.Data.InMemory.Tests
{
    [TestClass]
    public class UowRepositoryTests
    {
        private readonly ArrayList _arrayList = new ArrayList();

        public UowRepositoryTests()
        {
            var fishes = DataHelper.CreateNewList<Fish>(5);
            var cats = DataHelper.CreateNewList<Cat>(10);
            _arrayList.AddRange(fishes);
            _arrayList.AddRange(cats);
        }

        [TestMethod]
        public void CanQuery()
        {
            using (var unitOfWork = new InMemoryUnitOfWork(_arrayList))
            {
                var countFish = unitOfWork.Repository.Query<Fish>().Count();
                var countCat = unitOfWork.Repository.Query<Cat>().Count();
                countFish.Should().Be.EqualTo(5);
                countCat.Should().Be.EqualTo(10);
            }
        }

        [TestMethod]
        public void CanAdd()
        {
            using (var unitOfWork = new InMemoryUnitOfWork(_arrayList))
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
            using (var unitOfWork = new InMemoryUnitOfWork(_arrayList))
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
            using (var unitOfWork = new InMemoryUnitOfWork(_arrayList))
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
