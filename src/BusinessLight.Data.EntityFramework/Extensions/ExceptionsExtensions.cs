namespace BusinessLight.Data.EntityFramework.Extensions
{
    using System;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Validation;
    using System.Text;

    public static class ExceptionsExtensions
    {
        public static string GetFullExceptionMessage(this DbEntityValidationException dbEntityValidationException)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(dbEntityValidationException.ToString());
            foreach (var validationError in dbEntityValidationException.EntityValidationErrors)
            {
                stringBuilder.Append("Entry:");
                stringBuilder.Append(validationError.Entry);
                stringBuilder.AppendLine(Environment.NewLine);
                foreach (var error in validationError.ValidationErrors)
                {
                    stringBuilder.Append("PropertyName:");
                    stringBuilder.Append(error.PropertyName);
                    stringBuilder.AppendLine(Environment.NewLine);
                    stringBuilder.Append("ErrorMessage:");
                    stringBuilder.Append(error.ErrorMessage);
                    stringBuilder.AppendLine(Environment.NewLine);
                }
            }
            throw new Exception(stringBuilder.ToString());
        }

        public static string GetFullExceptionMessage(this DbUpdateException dbUpdateException)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(dbUpdateException.ToString());
            foreach (var entry in dbUpdateException.Entries)
            {
                stringBuilder.Append("NewLine:");
                stringBuilder.Append(entry.Entity.GetType().FullName);
                stringBuilder.AppendLine(Environment.NewLine);
            }
            throw new Exception(stringBuilder.ToString());
        }
    }
}
