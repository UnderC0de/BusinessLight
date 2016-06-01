using System.Web.Mvc;
using BusinessLight.Validation;

namespace BusinessLight.PhoneBook.Mvc.Extensions
{
    public static class ModelStateDictionaryExtensions
    {
        public static void AddValidationErrors(this ModelStateDictionary modelstate, ValidationException validationException)
        {
            var validationIssues = validationException.ValidationResult.ValidationIssues;
            foreach (var validationIssue in validationIssues)
            {
                modelstate.AddModelError(validationIssue.PropertyName, validationIssue.Message);
            }
        }
    }
}