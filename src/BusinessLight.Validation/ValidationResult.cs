using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLight.Validation
{
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
                throw new ArgumentNullException(nameof(validationIssues));
            }

            ValidationIssues = validationIssues;
        }

        public bool HasErrors
        {
            get
            {
                return Errors.Any();
            }
        }

        public bool HasWarnings
        {
            get
            {
                return Warnings.Any();
            }
        }

        public IEnumerable<ValidationIssue> ValidationIssues
        {
            get;
        }

        public IEnumerable<ValidationIssue> Errors
        {
            get
            {
                return ValidationIssues.Where(x => x.Level == IssueLevel.Error);
            }
        }

        public IEnumerable<ValidationIssue> Warnings
        {
            get
            {
                return ValidationIssues.Where(x => x.Level == IssueLevel.Warning);
            }
        }

        public override string ToString()
        {
            {
                var stringBuilder = new StringBuilder();
                if (HasErrors)
                {
                    stringBuilder.AppendLine("Validation errors:");
                    foreach (var error in Errors)
                    {
                        stringBuilder.AppendLine(error.Message);
                    }
                }

                if (HasWarnings)
                {
                    stringBuilder.AppendLine("Validation warnings:");
                    foreach (var error in Warnings)
                    {
                        stringBuilder.AppendLine(error.Message);
                    }
                }

                return stringBuilder.ToString();
            }
        }
    }
}