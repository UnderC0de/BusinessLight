using System.Linq;
using FluentValidation;

namespace BusinessLight.Validation.Fluent
{
    public class FluentValidator<T> : AbstractValidator<T>, IValidator<T>
    {
        public ValidationResult GetValidationResult(T instance)
        {
            var validationIssues = Validate(instance)
                .Errors
                .Select(x => new ValidationIssue(x.ErrorMessage));

            return new ValidationResult(validationIssues);
        }
    }
}
