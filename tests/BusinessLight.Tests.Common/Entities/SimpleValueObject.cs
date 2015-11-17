using System;
using BusinessLight.Domain;

namespace BusinessLight.Tests.Common.Entities
{
    public class SimpleValueObject : ValueObject
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public int Children { get; set; }
        public double Rate { get; set; }
    }
}
