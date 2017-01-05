namespace BusinessLight.Dto
{
    using System;

    public class Dto : IEquatable<Dto>
    {
        protected Dto()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id
        {
            get;
            set;
        }

        public bool Equals(Dto other)
        {
            if (other == null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return this.GetType() == other.GetType() && this.Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Dto);
        }

        public static bool operator ==(Dto left, Dto right)
        {
            return Equals(left, null) ? Equals(right, null) : left.Equals(right);
        }

        /// <inheritdoc/>
        public static bool operator !=(Dto left, Dto right)
        {
            return !(left == right);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"[{this.GetType().Name} {this.Id}]";
        }
    }
}