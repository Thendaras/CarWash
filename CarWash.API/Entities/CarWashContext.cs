using System.Data.Entity;

namespace CarWash.Entities
{
    public class CarWashContext : DbContext
    {
        public CarWashContext() : base("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=WingtipToys;Integrated Security=True;Pooling=False")
        {
        }

        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Process> Processes { get; set; }
        public DbSet<WashType> WashTypes { get; set; }
    }
}
