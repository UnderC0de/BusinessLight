namespace BusinessLight.PhoneBook.Validation
{
    using BusinessLight.PhoneBook.Domain;
    using BusinessLight.Validation.Fluent;

    using FluentValidation;

    public class ContactValidator : FluentValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(filter => filter.FirstName).NotEmpty();
            RuleFor(filter => filter.LastName).NotEmpty();
        }
    }
}