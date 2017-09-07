using System;
using Api.Models.Domain.Tenant;

namespace Api.Models.Domain.Inventory
{
    public class InventoryStock : TenantModel<int>
    {
        public ItemDefinition ItemDefinition { get; set; }
        public InventoryLocation Location { get; set; }
        public string Revision { get; set; }
        public InventoryStockStatus Status { get; set; }

        public InventoryStock()
        {
        }
    }
}
