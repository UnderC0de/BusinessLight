namespace BusinessLight.Validation.Unity
{
    using System;

    using Microsoft.Practices.Unity;

    public class UnityValidationFactory : IValidationFactory
    {
        private readonly IUnityContainer unityContainer;

        public UnityValidationFactory(IUnityContainer unityContainer)
        {
            if (unityContainer == null)
            {
                throw new ArgumentNullException(nameof(unityContainer));
            }

            this.unityContainer = unityContainer;
        }

        public IValidator<T> GetValidatorFor<T>()
        {
            return this.unityContainer.Resolve<IValidator<T>>();
        }
    }
}
