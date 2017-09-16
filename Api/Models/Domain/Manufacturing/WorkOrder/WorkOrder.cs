using System;
using Api.Models.Domain.Inventory;
using Api.Models.Domain.General;
using System.Collections.Generic;

namespace Api.Models.Domain.Manufacturing
{
    public class WorkOrder
    {
        public int BillOfMaterialId { get; set; }
        public BillOfMaterial BillOfMaterial { get; set; }
        public InventoryItem InventoryItem { get; set; }
        public decimal Quantity { get; set; }
        public Routing Routing { get; set; }
        public UnitOfMeasure UnitOfMeasure { get; set; }
        public ICollection<WorkOrderStep> Steps { get; set; }
        public DateTimeOffset DueDate { get; set; }
        public WorkOrderStatus Status { get; set; }

        public WorkOrder()
        {
        }
    }
}
