namespace BusinessLight.Domain
{
    using System;

    public abstract class Entity : IEquatable<Entity>, IEntity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id
        {
            get;
            set;
        }

        public bool Equals(Entity other)
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
            return Equals(obj as Entity);
        }

        public static bool operator ==(Entity left, Entity right)
        {
            return Equals(left, null) ? Equals(right, null) : left.Equals(right);
        }

        /// <inheritdoc/>
        public static bool operator !=(Entity left, Entity right)
        {
            return !(left == right);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("[{0} {1}]", GetType().Name, Id);
        }
    }
}