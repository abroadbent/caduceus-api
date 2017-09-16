using System;
using Api.Models.Domain.Tenant;

namespace Api.Models.Domain.Inventory
{
    public class InventoryStock : TenantModel<int>
    {
        public int InventoryItemId { get; set; }
        public int InventoryLocationId { get; set; }
        public string Revision { get; set; }
        public int StatusId { get; set; }

        public virtual InventoryItem InventoryItem { get; set; }
        public virtual InventoryLocation Location { get; set; }
        public virtual InventoryStockStatus Status { get; set; }

        public InventoryStock()
        {
        }
    }
}
