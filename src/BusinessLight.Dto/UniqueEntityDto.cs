namespace BusinessLight.Dto
{
    using System;

    public abstract class UniqueEntityDto : IEquatable<UniqueEntityDto>
    {
        protected UniqueEntityDto()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id
        {
            get;
            set;
        }

        public bool Equals(UniqueEntityDto other)
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
            return Equals(obj as UniqueEntityDto);
        }
    }
}
