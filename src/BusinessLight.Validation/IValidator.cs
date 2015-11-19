namespace BusinessLight.Validation
{
    public interface IValidator<in T>
    {
        ValidationResult Validate(T filter);
    }
}