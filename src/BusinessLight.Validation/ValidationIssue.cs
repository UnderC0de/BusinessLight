using System;

namespace BusinessLight.Validation
{
    public class ValidationIssue
    {
        public ValidationIssue(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentException("Argument is null or whitespace", "message");
            }

            Message = message;
        }

        public string Message
        {
            get;
            set;
        }
    }
}