using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpTestsEx;

namespace BusinessLight.Validation.Tests
{
    [TestClass]
    public class ValidationResultTests
    {
        [TestMethod]
        public void CannotCreateWithNullValidationIssuesResult()
        {
            new Action(() => new ValidationResult(null))
                .Should().Throw<ArgumentNullException>()
                .And
                .ValueOf
                .ParamName
                .Should().Be.EqualTo("validationIssues");
        }

        [TestMethod]
        public void CanCreate()
        {
            var validationIssues = new List<ValidationIssue>();
            var validationResult = new ValidationResult(validationIssues);
            validationResult.ValidationIssues.Should().Be.Equals(validationIssues);
            validationResult.HasErrors.Should().Be.False();
            validationResult.ToString().Should().Be.EqualTo(string.Empty);
            validationIssues.Add(new ValidationIssue("Invalid property", "MyProperty", "NotAValidValue"));
            validationResult.HasErrors.Should().Be.True();
            validationResult.ToString().Should().Contain("Invalid property");
            validationResult.ToString().Should().Contain("MyProperty");
            validationResult.ToString().Should().Contain("NotAValidValue");
        }
    }
}