using System.Collections.Generic;

namespace BusinessLight.Validation
{
    public class ValidationFactory : IValidationFactory
    {
        private readonly Dictionary<string, object> _validators = new Dictionary<string, object>();

        public void Register<T>(IValidator<T> validator)
        {
            UnRegister<T>();
            _validators.Add(GetKey<T>(), validator);
        }

        public void UnRegister<T>()
        {
            _validators.Remove(GetKey<T>());
        }
       
        public IValidator<T> GetValidatorFor<T>()
        {
            var key = GetKey<T>();
            if (_validators.ContainsKey(key))
            {
                return (IValidator<T>)_validators[key];
            }
            return null;
        }

        private static string GetKey<T>()
        {
            return string.Format("{0}", typeof(T).FullName);
        }
    }
}