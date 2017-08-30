using System;
using Api.Models.Domain.AppUser;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Api.Models.System
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<AppUser> AppUsers { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Add keys and model meta information here

            // Return to base execution
            base.OnModelCreating(modelBuilder);
        }
    }
}
