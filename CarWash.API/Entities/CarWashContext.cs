using System.Data.Entity;

namespace CarWash.Entities
{
    public class CarWashContext : DbContext
    {
        public CarWashContext() : base("test")
        {
        }

        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Process> Processes { get; set; }
        public DbSet<WashType> WashTypes { get; set; }
    }
}
