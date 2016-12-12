namespace BusinessLight.Validation
{
    using System;

    public class ValidationIssue
    {
        public ValidationIssue(string message) 
            : this(message, null, null)
        {
        }

        public ValidationIssue(string message, string propertyName, object attemptedValue)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentException("Argument is null or whitespace", "message");
            }

            Message = message;
            PropertyName = propertyName;
            AttemptedValue = attemptedValue;
        }

        public string Message
        {
            get;
            set;
        }

        public string PropertyName
        {
            get;
            set;
        }

        public object AttemptedValue
        {
            get;
            set;
        }
    }
}