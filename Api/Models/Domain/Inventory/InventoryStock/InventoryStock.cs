using System;
using System.ComponentModel.DataAnnotations;
using Api.Models.Domain.Tenant;

namespace Api.Models.Domain.Inventory
{
    public class InventoryStock : TenantModel<int>
    {
        [Required]
        public int InventoryItemId { get; set; }

        [Required]
        public int InventoryLocationId { get; set; }

        [Required]
        public double Quantity { get; set; }

        [MaxLength(10)]
        public string Revision { get; set; }

        [Required]
        public int StatusId { get; set; }

        public virtual InventoryItem InventoryItem { get; set; }
        public virtual InventoryLocation Location { get; set; }
        public virtual InventoryStockStatus Status { get; set; }

        public InventoryStock()
        {
        }
    }
}
