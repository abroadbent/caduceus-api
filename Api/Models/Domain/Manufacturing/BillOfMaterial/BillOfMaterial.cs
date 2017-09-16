using System;
using Api.Models.Domain.Inventory;
using Api.Models.Domain.Tenant;

namespace Api.Models.Domain.Manufacturing
{
    public class BillOfMaterial : TenantModel<int>
    {
        public string Code { get; set; }
        public int ComponentId { get; set; }
        public int ParentId { get; set; }
        public decimal Quantity { get; set; }

		public virtual InventoryItem Component { get; set; }
		public virtual InventoryItem Parent { get; set; }

        public BillOfMaterial()
        {
        }
    }
}
