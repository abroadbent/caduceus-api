using System;
namespace Api.Models.Domain.Inventory
{
    public class InventoryItemStatus
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }

        public InventoryItemStatus()
        {
        }
    }
}
