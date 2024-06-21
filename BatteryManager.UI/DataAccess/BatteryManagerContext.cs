using Microsoft.EntityFrameworkCore;

namespace BatteryManager.UI.DataAccess
{
    public class BatteryManagerContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Plant> Plants{ get; set; }
        public DbSet<Battery> Batteries{ get; set; }

        public BatteryManagerContext(DbContextOptions options) : base(options)
        {
           
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("BatteryManager");
            base.OnModelCreating(modelBuilder);
        }
    }
}
