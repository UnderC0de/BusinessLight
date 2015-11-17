using System;

namespace BusinessLight.Domain
{
    public abstract class UniqueEntity : IEquatable<UniqueEntity>
    {
        protected UniqueEntity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id
        {
            get;
            set;
        }

        public bool Equals(UniqueEntity other)
        {
            if (other == null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return GetType() == other.GetType() && Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as UniqueEntity);
        }
    }
}