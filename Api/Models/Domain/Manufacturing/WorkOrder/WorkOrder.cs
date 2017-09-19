using System;
using Api.Models.Domain.Inventory;
using Api.Models.Domain.General;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Models.Domain.Manufacturing
{
    public class WorkOrder
    {
        [Required]
        public int BillOfMaterialId { get; set; }

        public DateTimeOffset DueDate { get; set; }

        [Required]
        public int InventoryItemId { get; set; }

        [Range(1, double.MaxValue), Required]
        public double Quantity { get; set; }

        [Required]
        public int RoutingId { get; set; }

        [Required]
        public int StatusId { get; set; }

        [Required]
        public int UnitOfMeasureId { get; set; }

        public virtual BillOfMaterial BillOfMaterial { get; set; }
        public virtual InventoryItem InventoryItem { get; set; }
        public virtual Routing Routing { get; set; }
        public virtual WorkOrderStatus Status { get; set; }
        public virtual ICollection<WorkOrderStep> Steps { get; set; }
        public virtual UnitOfMeasure UnitOfMeasure { get; set; }

        public WorkOrder()
        {
        }
    }
}
