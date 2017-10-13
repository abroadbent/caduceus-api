using System;
using Api.Models.Domain.AppUser;
using Api.Models.Domain.General;
using Api.Models.Domain.Inventory;
using Api.Models.Domain.Manufacturing;
using Api.Models.Domain.Tenant;
using Microsoft.EntityFrameworkCore;

namespace Api.Models.System
{
    public class AppUserContext : DbContext
    {
        public virtual DbSet<AppUser> AppUsers { get; set; }
        public virtual DbSet<Tenant> Tenants { get; set; }

        public AppUserContext()
        {
        }

        public AppUserContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Add keys and model meta information here
            modelBuilder.Entity<AppUser>().HasKey(a => new { a.TenantId, a.Id });

            // Return to base execution
            base.OnModelCreating(modelBuilder);
        }
    }
}