using BusinessLight.Tests.Common.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpTestsEx;

namespace BusinessLight.Domain.Tests
{
    [TestClass]
    public class EntityTests
    {
        private readonly Cat _felix;
        private readonly Fish _nemo;

        public EntityTests()
        {
            _felix = new Cat { Name = "Felix"};
            _nemo = new Fish { Name = "Nemo" };
        }

        [TestMethod]
        public void SameObjectsEqualsReturnsTrue()
        {
            _felix.Should().Be.EqualTo(_felix);
            _nemo.Should().Be.EqualTo(_nemo);
        }

        [TestMethod]
        public void DifferentObjectsEqualsReturnsFalse()
        {
            _felix.Should().Not.Be.EqualTo(_nemo);
            _nemo.Should().Not.Be.EqualTo(_felix);
        }

        [TestMethod]
        public void SameObjectsTypeDifferentIdsEqualsReturnsFalse()
        {
            var tom = new Cat { Name = "Tom" };
            _felix.Should().Not.Be.EqualTo(tom);
        }

        [TestMethod]
        public void SameObjectsTypeSameIdsEqualsReturnsFalse()
        {
            var tom = new Cat { Name = "Tom", Id = _felix .Id};
            _felix.Should().Be.EqualTo(tom);
        }
    }
}
