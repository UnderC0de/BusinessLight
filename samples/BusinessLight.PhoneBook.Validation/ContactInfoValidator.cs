namespace BusinessLight.PhoneBook.Validation
{
    using BusinessLight.PhoneBook.Domain;
    using BusinessLight.Validation.Fluent;

    using FluentValidation;

    public class ContactInfoValidator : FluentValidator<ContactInfo>
    {
        public ContactInfoValidator()
        {
            RuleFor(filter => filter.ContactId).NotEmpty();
            RuleFor(filter => filter.ContactInfoDetail).NotEmpty();
        }
    }
}