using System;
using Api.Models.Domain.AppUser;
using Api.Models.Domain.General;
using Api.Models.Domain.Inventory;
using Api.Models.Domain.Manufacturing;
using Api.Models.Domain.Tenant;
using Microsoft.EntityFrameworkCore;

namespace Api.Models.System
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<AppUser> AppUsers { get; set; }
        public virtual DbSet<Attachment> Attachments { get; set; }
        public virtual DbSet<BillOfMaterial> BillOfMaterials { get; set; }
        public virtual DbSet<InventoryItem> InventoryItems { get; set; }
        public virtual DbSet<InventoryLocation> InventoryLocations { get; set; }
        public virtual DbSet<InventoryLocationStatus> InventoryLocationStatuses { get; set; }
        public virtual DbSet<InventoryItemStatus> InventoryItemStatuses { get; set; }
        public virtual DbSet<InventoryStock> InventoryStock { get; set; }
        public virtual DbSet<LoggedWork> LoggedWork { get; set; }
        public virtual DbSet<QualityTest> QualityTests { get; set; }
        public virtual DbSet<QualityTestResult> QualityTestResults { get; set; }
        public virtual DbSet<Routing> Routings { get; set; }
        public virtual DbSet<RoutingStep> RoutingSteps { get; set; }
        public virtual DbSet<ScrapReason> ScrapReasons { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<Tenant> Tenants { get; set; }
        public virtual DbSet<UnitOfMeasure> UnitOfMeasures { get; set; }
        public virtual DbSet<WorkOrder> WorkOrders { get; set; }
        public virtual DbSet<WorkOrderStatus> WorkOrderStatuses { get; set; }
        public virtual DbSet<WorkOrderStep> WorkOrderSteps { get; set; }
        public virtual DbSet<WorkOrderStepStatus> WorkOrderStepStatuses { get; set; }

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

            modelBuilder.Entity<Attachment>().HasKey(a => new { a.TenantId, a.Id });

            modelBuilder.Entity<BillOfMaterial>().HasKey(a => new { a.TenantId, a.Id });

            modelBuilder.Entity<InventoryItem>().HasKey(a => new { a.TenantId, a.Id });
            modelBuilder.Entity<InventoryItem>().HasOne(a => a.Status).WithMany().OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<InventoryLocation>().HasKey(a => new { a.TenantId, a.Id });
            modelBuilder.Entity<InventoryLocation>().HasOne(a => a.Status).WithMany().OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<InventoryStock>().HasKey(a => new { a.TenantId, a.Id });
            modelBuilder.Entity<InventoryStock>().HasOne(a => a.Status).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<InventoryStock>().HasOne(a => a.Location).WithMany().OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Routing>().HasKey(a => new { a.TenantId, a.Id });

            modelBuilder.Entity<UnitOfMeasure>().HasKey(a => new { a.TenantId, a.Id });
            modelBuilder.Entity<WorkOrder>().HasKey(a => new { a.TenantId, a.Id });
            modelBuilder.Entity<WorkOrder>().HasOne(a => a.UnitOfMeasure).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<WorkOrder>().HasOne(a => a.Status).WithMany().OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WorkOrderStep>().HasOne(a => a.Status).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<WorkOrderStep>().HasOne(a => a.ScrapReason).WithMany().OnDelete(DeleteBehavior.Restrict);

            // Return to base execution
            base.OnModelCreating(modelBuilder);
        }
    }
}