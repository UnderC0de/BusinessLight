namespace BusinessLight.Validation
{
    public interface IValidationFactory
    {
        IValidator GetValidatorFor<T>();
    }
}
