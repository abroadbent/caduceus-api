using System;
using System.Collections.Generic;

namespace Api.Models.Domain.Inventory
{
    public class InventoryLocationListItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }

        public virtual ICollection<InventoryLocationListItem> SubLocations { get; set; }
    }
}
