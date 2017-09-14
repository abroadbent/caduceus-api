using System;
using Api.Models.Domain.Inventory;
using Api.Models.Domain.Tenant;

namespace Api.Models.Domain.Manufacturing
{
    public class BillOfMaterial : TenantModel<int>
    {
        public string Code { get; set; }
        public InventoryItem Component { get; set; }
        public InventoryItem Parent { get; set; }
        public decimal Quantity { get; set; }

        public BillOfMaterial()
        {
        }
    }
}
