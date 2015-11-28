using BusinessLight.PhoneBook.Service.Filters;
using BusinessLight.Validation.Fluent;
using FluentValidation;

namespace BusinessLight.PhoneBook.Validation
{
    public class SearchContactFilterValidator : FluentValidator<SearchContactFilter>
    {
        public SearchContactFilterValidator()
        {
            RuleFor(filter => filter.FirstName).NotEmpty();
        }
    }
}
