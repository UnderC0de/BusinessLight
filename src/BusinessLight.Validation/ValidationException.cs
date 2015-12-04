using System;
using System.Text;

namespace BusinessLight.Validation
{
    public class ValidationException : Exception
    {
        public ValidationException(ValidationResult validationResult) 
            : base(validationResult.ToString())
        {
            if (validationResult == null)
            {
                throw new ArgumentNullException("validationResult");
            }

            ValidationResult = validationResult;
        }

        public ValidationResult ValidationResult
        {
            get; 
            set;
        }
    }
}