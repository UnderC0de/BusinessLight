using BusinessLight.PhoneBook.Domain;
using BusinessLight.Validation.Fluent;
using FluentValidation;

namespace BusinessLight.PhoneBook.Validation
{
    public class ContactValidator : FluentValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(filter => filter.FirstName).NotEmpty();
            RuleFor(filter => filter.LastName).NotEmpty();
        }
    }
}