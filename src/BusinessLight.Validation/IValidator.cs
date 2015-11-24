namespace BusinessLight.Validation
{
    public interface IValidator<in T>
    {
        ValidationResult GetValidationResult(T instance);
    }
}