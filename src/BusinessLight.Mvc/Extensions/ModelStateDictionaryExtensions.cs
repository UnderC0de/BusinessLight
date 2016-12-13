namespace BusinessLight.PhoneBook.Mvc.Extensions
{
    using System.Web.Mvc;

    using FluentValidation;

    public static class ModelStateDictionaryExtensions
    {
        public static void AddValidationErrors(this ModelStateDictionary modelstate, ValidationException validationException)
        {
            var validationIssues = validationException.Errors;
            foreach (var validationIssue in validationIssues)
            {
                modelstate.AddModelError(validationIssue.PropertyName, validationIssue.ErrorMessage);
            }
        }
    }
}