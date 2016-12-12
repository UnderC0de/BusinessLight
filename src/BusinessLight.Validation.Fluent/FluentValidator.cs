namespace BusinessLight.Validation.Fluent
{
    using System.Linq;
    using FluentValidation;

    public class FluentValidator<T> : AbstractValidator<T>
    {
        public ValidationResult GetValidationResult(T instance)
        {
            var validationIssues = Validate(instance)
                .Errors
                .Select(x => new ValidationIssue(x.ErrorMessage, x.PropertyName, x.AttemptedValue));

            return new ValidationResult(validationIssues);
        }
    }
}
