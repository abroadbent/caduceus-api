using System;
namespace Api.Models.Domain.Inventory
{
    public class InventoryStockListItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Status { get; set; }
    }
}
