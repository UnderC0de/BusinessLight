using System;
using System.Collections.Generic;

namespace BusinessLight.Validation
{
    public class ValidationFactory : IValidationFactory
    {
        private readonly Dictionary<string, object> _validators = new Dictionary<string, object>();

        public void Register<T>(IValidator<T> validator)
        {
             Register(validator, ValidationContext.Default);
        }

        public void Register<T>(IValidator<T> validator, ValidationContext validationContext)
        {
            UnRegister<T>();
            _validators.Add(GetKey<T>(validationContext), validator);
        }

        public void UnRegister<T>()
        {
            _validators.Remove(GetKey<T>(ValidationContext.Default));
        }

        public void UnRegister<T>(ValidationContext validationContext)
        {
            _validators.Remove(GetKey<T>(validationContext));
        }

        public IValidator<T> GetValidatorFor<T>()
        {
            return GetValidatorFor<T>(ValidationContext.Default);
        }

        public IValidator<T> GetValidatorFor<T>(ValidationContext validationContext)
        {
            var key = GetKey<T>(validationContext);
            if (_validators.ContainsKey(key))
            {
                return (IValidator<T>)_validators[key];
            }
            return null;
        }

        private static string GetKey<T>(ValidationContext validationContext)
        {
            return string.Format("{0}-{1}", typeof(T).FullName, validationContext);
        }
    }
}