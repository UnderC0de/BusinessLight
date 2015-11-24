using System;
using System.Collections.Generic;

namespace BusinessLight.Validation
{
    public class ValidationFactory : IValidationFactory
    {
        private readonly Dictionary<Type, object> _validators = new Dictionary<Type, object>();

        public IValidator<T> GetValidatorFor<T>()
        {
            return (IValidator<T>) _validators[typeof (T)];
        }

        public void Register<T>(IValidator<T> validator)
        {
            UnRegister<T>();
            _validators.Add(typeof(T), validator);
        }

        public void UnRegister<T>()
        {
            _validators.Remove(typeof (T));
        }
    }
}