using System;
using System.Collections.Generic;
using Api.Models.Domain.Tenant;

namespace Api.Models.Domain.Inventory
{
    public class InventoryLocation : TenantModel<int>
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public InventoryLocation Parent { get; set; }
        public ICollection<InventoryLocation> SubLocations { get; set; }
        public InventoryLocationStatus Status { get; set; }

        public InventoryLocation()
        {
        }
    }
}
