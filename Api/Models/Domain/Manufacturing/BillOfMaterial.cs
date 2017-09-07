using System;
using Api.Models.Domain.Inventory;
using Api.Models.Domain.Tenant;

namespace Api.Models.Domain.Manufacturing
{
    public class BillOfMaterial : TenantModel<int>
    {
        public string Code { get; set; }
        public ItemDefinition Component { get; set; }
        public ItemDefinition Parent { get; set; }
        public decimal Quantity { get; set; }

        public BillOfMaterial()
        {
        }
    }
}
