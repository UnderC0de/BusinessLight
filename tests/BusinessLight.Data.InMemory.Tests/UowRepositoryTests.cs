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
    }
}
