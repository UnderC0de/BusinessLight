using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpTestsEx;

namespace BusinessLight.Validation.Tests
{
    [TestClass]
    public class ValidationExceptionTests
    {
        [TestMethod]
        public void CannotCreateWithNullValidationResult()
        {
         new Action(() => new ValidationException(null))
                .Should().Throw<ArgumentNullException>()
                .And
                .ValueOf
                .ParamName
                .Should()
                .Be
                .EqualTo("validationResult");
        }

        [TestMethod]
        public void CanCreate()
        {
            var validationResult = new ValidationResult();
            var validationException = new ValidationException(validationResult);
            validationException
                .ValidationResult.Should()
                .Be
                .EqualTo(validationResult);
        }
    }
}
