using Agreed.Core.Entities;
using Agreed.DataAccess.Configurations;
using Agreed.DataAccess.Seed;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agreed.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Tables
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuration
            modelBuilder.ApplyConfiguration(new OrderConfiguration());

            // Seeds
            modelBuilder.ApplyConfiguration(new OrderSeed());
        }
    }
}
