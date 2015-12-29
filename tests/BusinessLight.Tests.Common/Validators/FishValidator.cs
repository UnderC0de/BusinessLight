using System.Collections.Generic;
using BusinessLight.Tests.Common.Entities;
using BusinessLight.Validation;


namespace BusinessLight.Tests.Common.Validators
{
    public class FishValidator : Validation.IValidator<Fish>
    {
        public ValidationResult GetValidationResult(Fish instance)
        {
            var validationIssues = new List<ValidationIssue>();

            if (string.IsNullOrWhiteSpace(instance.Name))
            {
                validationIssues.Add(new ValidationIssue("Name Is null Or whiteSpace ", "Name", instance.Name));
            }
            return new ValidationResult(validationIssues);
        }
    }
}
