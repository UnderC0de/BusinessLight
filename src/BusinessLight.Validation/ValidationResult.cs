namespace BusinessLight.Validation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ValidationResult
    {
        public ValidationResult()
            : this(new List<ValidationIssue>())
        {
        }

        public ValidationResult(IEnumerable<ValidationIssue> validationIssues)
        {
            if (validationIssues == null)
            {
                throw new ArgumentNullException("validationIssues");
            }

            ValidationIssues = validationIssues;
        }

        public bool HasErrors
        {
            get
            {
                return ValidationIssues.Any();
            }
        }


        public IEnumerable<ValidationIssue> ValidationIssues
        {
            get;
        }

        public override string ToString()
        {
            {
                var stringBuilder = new StringBuilder();
                if (!this.HasErrors)
                {
                    return stringBuilder.ToString();
                }

                foreach (var error in this.ValidationIssues)
                {
                    stringBuilder.AppendLine(error.Message);
                    if (!string.IsNullOrWhiteSpace(error.PropertyName))
                    {
                        stringBuilder.AppendLine("Property:");
                        stringBuilder.Append(error.PropertyName);     
                    }
                    if (error.AttemptedValue != null)
                    {
                        stringBuilder.AppendLine("Value:");
                        stringBuilder.Append(error.AttemptedValue);
                    }
                }
                return stringBuilder.ToString();
            }
        }
    }
}