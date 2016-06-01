using System;
using BusinessLight.Domain;

namespace BusinessLight.Tests.Common.Entities
{
    public class Customer : Entity
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
    }
}