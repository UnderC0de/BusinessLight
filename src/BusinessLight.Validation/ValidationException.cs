using System;
using System.Text;

namespace BusinessLight.Validation
{
    public class ValidationException : Exception
    {
        public ValidationException(ValidationResult validationResult) 
            : base(GetMessage(validationResult))
        {
            if (validationResult == null)
            {
                throw new ArgumentNullException("validationResult");
            }

            ValidationResult = validationResult;
        }

        private static string GetMessage(ValidationResult validationResult)
        {
            return validationResult == null ? string.Empty : validationResult.ToString();
        }

        public ValidationResult ValidationResult
        {
            get; 
            set;
        }
    }
}