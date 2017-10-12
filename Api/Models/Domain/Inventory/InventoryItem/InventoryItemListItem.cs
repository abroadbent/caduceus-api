using System;
namespace Api.Models.Domain.Inventory
{
    public class InventoryItemListItem
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
    }
}
