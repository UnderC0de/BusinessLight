using System;
using BusinessLight.Tests.Common.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpTestsEx;

namespace BusinessLight.Domain.Tests
{
    [TestClass]
    public class ValueObjectTests
    {
        private readonly SimpleValueObject _simpleValueObject1;
        private readonly SimpleValueObject _simpleValueObject2;

        public ValueObjectTests()
        {
            _simpleValueObject1 = new SimpleValueObject
            {
                Name = "Name1",
                BirthDate = new DateTime(2016, 1, 15),
                Children = 3,
                Rate = 7.9
            };
            _simpleValueObject2 = new SimpleValueObject
            {
                Name = "Name2",
                BirthDate = new DateTime(2016, 2, 1),
                Children = 2,
                Rate = 4.9
            };
        }

        [TestMethod]
        public void SameObjectsEqualsReturnsTrue()
        {
            _simpleValueObject1.Should().Be.EqualTo(_simpleValueObject1);
            _simpleValueObject2.Should().Be.EqualTo(_simpleValueObject2);
        }

        [TestMethod]
        public void DifferentObjectsEqualsReturnsFalse()
        {
            _simpleValueObject1.Should().Not.Be.EqualTo(_simpleValueObject2);
            _simpleValueObject2.Should().Not.Be.EqualTo(_simpleValueObject1);
        }

        [TestMethod]
        public void SameObjectsTypeDifferentValuesEqualsReturnsFalse1()
        {
            var simpleValueObject = new SimpleValueObject
            {
                Name = "Name11",
                BirthDate = new DateTime(2016, 1, 15),
                Children = 3,
                Rate = 7.9
            };
            _simpleValueObject1.Should().Not.Be.EqualTo(simpleValueObject);
        }

        [TestMethod]
        public void SameObjectsTypeDifferentValuesEqualsReturnsFalse2()
        {
            var simpleValueObject = new SimpleValueObject
            {
                Name = "Name1",
                BirthDate = new DateTime(2016, 1, 16),
                Children = 3,
                Rate = 7.9
            };
            _simpleValueObject1.Should().Not.Be.EqualTo(simpleValueObject);
        }

        [TestMethod]
        public void SameObjectsTypeDifferentValuesEqualsReturnsFalse3()
        {
            var simpleValueObject = new SimpleValueObject
            {
                Name = "Name1",
                BirthDate = new DateTime(2016, 1, 15),
                Children = 4,
                Rate = 7.9
            };
            _simpleValueObject1.Should().Not.Be.EqualTo(simpleValueObject);
        }

        [TestMethod]
        public void SameObjectsTypeDifferentValuesEqualsReturnsFalse4()
        {
            var simpleValueObject = new SimpleValueObject
            {
                Name = "Name1",
                BirthDate = new DateTime(2016, 1, 15),
                Children = 3,
                Rate = 8.9
            };
            _simpleValueObject1.Should().Not.Be.EqualTo(simpleValueObject);
        }
    }
}
