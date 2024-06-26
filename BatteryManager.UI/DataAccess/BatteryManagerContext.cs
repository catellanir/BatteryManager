﻿using Microsoft.EntityFrameworkCore;

namespace BatteryManager.UI.DataAccess
{
    public class BatteryManagerContext : DbContext
    {
        public BatteryManagerContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Battery> Batteries { get; set; }
        public DbSet<BatteryClass> BatteryClasses { get; set; }
        public DbSet<BatteryType> BatteryTypes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Plant> Plants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("BatteryManager");
            base.OnModelCreating(modelBuilder);
        }
    }
}