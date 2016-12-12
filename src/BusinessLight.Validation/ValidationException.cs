using System;

namespace BusinessLight.Validation
{
    public class ValidationException : Exception
    {
        public ValidationException(ValidationResult validationResult) 
            : base(GetMessage(validationResult))
        {
            if (validationResult == null)
            {
                throw new ArgumentNullException(nameof(validationResult));
            }

            ValidationResult = validationResult;
        }

        private static string GetMessage(ValidationResult validationResult)
        {
            return validationResult?.ToString() ?? string.Empty;
        }

        public ValidationResult ValidationResult
        {
            get; 
            set;
        }
    }
}