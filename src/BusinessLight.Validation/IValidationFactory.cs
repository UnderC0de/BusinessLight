namespace BusinessLight.Validation
{
    public interface IValidationFactory
    {
        IValidator<T> GetValidatorFor<T>();

        //IValidator<T> GetValidatorFor<T>(ValidationContext validationContext);
    }

    //public enum ValidationContext
    //{
    //    Default = 0,
    //    Create = 1,
    //    Edit = 2
    //}
}
