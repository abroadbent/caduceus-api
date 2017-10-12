using System;
namespace Api.Models.Domain.Manufacturing
{
    public class WorkOrderListItem
    {
        public int Id { get; set; }
        public string InventoryItem { get; set; }
        public double Quantity { get; set; }
        public string UnitOfMeasure { get; set; }
        public string Status { get; set; }
        public DateTimeOffset DueDate { get; set; }
    }
}
