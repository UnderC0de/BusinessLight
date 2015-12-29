using BusinessLight.Tests.Common.Entities;
using BusinessLight.Tests.Common.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpTestsEx;

namespace BusinessLight.Validation.Tests
{
    [TestClass]
    public class ValidationFactoryTests
    {
        [TestMethod]
        public void CanGetValidator()
        {
            var validationFactory = new ValidationFactory();
            validationFactory.GetValidatorFor<Fish>().Should().Be.Null();

            var validator = new FishValidator();
            validationFactory.Register(validator);
            validationFactory.GetValidatorFor<Fish>().Should().Be.EqualTo(validator);
        }

        [TestMethod]
        public void CanRegister()
        {
            var validationFactory = new ValidationFactory();
            var validator = new FishValidator();
            validationFactory.Register(validator);
            validationFactory.GetValidatorFor<Fish>().Should().Be.EqualTo(validator);
        }

        [TestMethod]
        public void CanDoMultipleRegister()
        {
            var validationFactory = new ValidationFactory();
            var validator = new FishValidator();
            validationFactory.Register(validator);
            validationFactory.GetValidatorFor<Fish>().Should().Be.EqualTo(validator);
        }

        [TestMethod]
        public void CanUnRegister()
        {
            var validationFactory = new ValidationFactory();
            var validator = new FishValidator();
            validationFactory.Register(validator);
            validationFactory.GetValidatorFor<Fish>().Should().Be.EqualTo(validator);
            validationFactory.UnRegister<Fish>();
            validationFactory.GetValidatorFor<Fish>().Should().Be.Null();
            validationFactory.UnRegister<Fish>();
            validationFactory.GetValidatorFor<Fish>().Should().Be.Null();
        }
    }
}
