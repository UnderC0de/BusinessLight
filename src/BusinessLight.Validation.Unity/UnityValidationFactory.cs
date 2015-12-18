using System;
using Microsoft.Practices.Unity;

namespace BusinessLight.Validation.Unity
{
    public class UnityValidationFactory : IValidationFactory
    {
        private readonly IUnityContainer _unityContainer;

        public UnityValidationFactory(IUnityContainer unityContainer)
        {
            if (unityContainer == null)
            {
                throw new ArgumentNullException("unityContainer");
            }

            _unityContainer = unityContainer;
        }

        public IValidator<T> GetValidatorFor<T>()
        {
            return _unityContainer.Resolve<IValidator<T>>();
        }
    }
}
