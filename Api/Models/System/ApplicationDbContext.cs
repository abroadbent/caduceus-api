using System;
using Api.Models.Domain.AppUser;
using Api.Models.Domain.Inventory;
using Api.Models.Domain.Tenant;
using Microsoft.EntityFrameworkCore;

namespace Api.Models.System
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<AppUser> AppUsers { get; set; }
        public virtual DbSet<InventoryItem> InventoryItems { get; set; }
        public virtual DbSet<Tenant> Tenants { get; set; }

        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Add keys and model meta information here
            modelBuilder.Entity<AppUser>().HasKey(a => new { a.TenantId, a.Id });
            modelBuilder.Entity<InventoryItem>().HasKey(a => new { a.TenantId, a.Id });

            // Return to base execution
            base.OnModelCreating(modelBuilder);
        }
    }
}