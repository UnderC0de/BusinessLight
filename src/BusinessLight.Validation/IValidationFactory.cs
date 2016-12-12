namespace BusinessLight.Validation
{
    public interface IValidationFactory
    {
        IValidator<T> GetValidatorFor<T>();
    }
}
