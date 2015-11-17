using System;
using System.Linq;

namespace BusinessLight.Domain
{
    public class ValueObject : IEquatable<ValueObject>
    {
        public bool Equals(ValueObject other)
        {
            if (other == null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return GetType() == other.GetType() && GetHashCode().Equals(other.GetHashCode());
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ValueObject);
        }

        /// <summary>
        /// Funge da funzione hash per un determinato tipo.
        /// </summary>
        /// <returns>
        /// Codice hash per la classe <see cref="T:System.Object"/> corrente.
        /// </returns>
        public override int GetHashCode()
        {
            var propertiesInfo = GetType().GetProperties().ToList();
            return (int) propertiesInfo
                .Select(propertyInfo => propertyInfo.GetValue(this, null))
                .Select(value => value.GetHashCode())
                .Average();
        }
    }
}
