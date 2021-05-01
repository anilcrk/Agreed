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
        public DbSet<Commission> Commissions{ get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<OperationClaim> OperationClaims{ get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<User> Users{ get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuration
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new CompantConfiguration());
            modelBuilder.ApplyConfiguration(new OperationClaimConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserOperationClaimConfiguration());

            // Seeds
            modelBuilder.ApplyConfiguration(new OrderSeed());
        }
    }
}
