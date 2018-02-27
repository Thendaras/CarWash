using System.Data.Entity;

namespace CarWash.Entities
{
    public class CarWashContext : DbContext
    {
        public CarWashContext() : base("test")
        {
        }

        public DbSet<Process> Steps { get; set; }
        public DbSet<WashType> WashTypes { get; set; }
    }
}
