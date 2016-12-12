using System.Collections.Generic;

namespace BusinessLight.Validation
{
    public class ValidationFactory : IValidationFactory
    {
        private readonly Dictionary<string, object> validators = new Dictionary<string, object>();

        public void Register<T>(IValidator<T> validator)
        {
            UnRegister<T>();
            this.validators.Add(GetKey<T>(), validator);
        }

        public void UnRegister<T>()
        {
            this.validators.Remove(GetKey<T>());
        }
       
        public IValidator<T> GetValidatorFor<T>()
        {
            var key = GetKey<T>();
            if (this.validators.ContainsKey(key))
            {
                return (IValidator<T>)this.validators[key];
            }
            return null;
        }

        private static string GetKey<T>()
        {
            return $"{typeof(T).FullName}";
        }
    }
}