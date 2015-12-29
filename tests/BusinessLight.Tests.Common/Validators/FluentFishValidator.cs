using BusinessLight.Tests.Common.Entities;
using BusinessLight.Validation.Fluent;
using FluentValidation;

namespace BusinessLight.Tests.Common.Validators
{
    public class FluentFishValidator : FluentValidator<Fish>
    {
        public FluentFishValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}