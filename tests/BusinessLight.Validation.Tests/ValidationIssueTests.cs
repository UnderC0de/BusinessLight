using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpTestsEx;

namespace BusinessLight.Validation.Tests
{
    [TestClass]
    public class ValidationIssueTests
    {
        [TestMethod]
        public void CannotCreateWithNullMessageResult()
        {
            new Action(() => new ValidationIssue(null))
                .Should().Throw<ArgumentException>()
                .And
                .ValueOf
                .ParamName
                .Should().Be.EqualTo("message");
        }

        [TestMethod]
        public void CanCreate()
        {
            var myMessage = "MyMessage";
            var myPropertyName = "MyPropertyName";
            var myAttemptedValue = "myAttemptedValue";
            var validationIssue = new ValidationIssue(myMessage);
            validationIssue.Message.Should().Be.EqualTo(myMessage);
            validationIssue.PropertyName.Should().Be.Null();
            validationIssue.AttemptedValue.Should().Be.Null();
            validationIssue = new ValidationIssue(myMessage, myPropertyName, myAttemptedValue);
            validationIssue.Message.Should().Be.EqualTo(myMessage);
            validationIssue.PropertyName.Should().Be.EqualTo(myPropertyName);
            validationIssue.AttemptedValue.Should().Be.EqualTo(myAttemptedValue);
        }
    }
}