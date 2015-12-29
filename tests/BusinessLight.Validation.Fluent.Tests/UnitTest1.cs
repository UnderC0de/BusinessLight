using System;
using System.Linq;
using BusinessLight.Tests.Common.Entities;
using BusinessLight.Tests.Common.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpTestsEx;

namespace BusinessLight.Validation.Fluent.Tests
{
    [TestClass]
    public class FluentValidatorTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var fluentFishValidator = new FluentFishValidator();
            var fish = new Fish();
            var validationResult = fluentFishValidator.GetValidationResult(fish);
            validationResult.HasErrors.Should().Be.True();
            validationResult.ValidationIssues.Should().Have.Count.EqualTo(1);
            validationResult.ValidationIssues.Single().PropertyName.Should().Be.EqualTo("Name");
        }
    }
}
