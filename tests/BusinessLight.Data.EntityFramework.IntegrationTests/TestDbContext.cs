using System.Data.Entity;
using BusinessLight.Tests.Common.Entities;

namespace BusinessLight.Data.EntityFramework.IntegrationTests
{
    public class TestDbContext : DbContext
    {
        public TestDbContext()
            : base("name=TestDbContext")
        {
        }

        // Explicit DbSets required only for IDatabaseInitializer
        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<Cat> Cats { get; set; }

        public virtual DbSet<Fish> Fishes { get; set; }
    }
}