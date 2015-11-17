using BusinessLight.Domain;

namespace BusinessLight.Tests.Common.Entities
{
    public abstract class Animal : UniqueEntity
    {
        public abstract string Name { get; set; }

        public abstract string Go();
    }
}
