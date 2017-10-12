using System;
using System.Collections.Generic;
using Api.Models.Domain.Tenant;
using Api.Models.Domain.AppUser;
using Api.Models.Domain.Inventory;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Api.Models.Domain.General;

namespace Api.Models.Domain.Manufacturing
{
    public class WorkOrderStep : DomainModel<int>
    {
        public decimal ActualCost { get; set; }
		public double ActualLaborHours { get; set; }
        public double CompletedQuantity { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

		public decimal EstimatedCost { get; set; }
		public double EstimatedLaborHours { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [Range(1, int.MaxValue), Required]
        public int RoutingStepId { get; set; }

        public double ScrapQuantity { get; set; }
        public int? ScrapReasonId { get; set; }

        [Range(1, int.MaxValue), Required]
        public int StatusId { get; set; }

        [Range(1, int.MaxValue), Required]
        public int WorkOrderId { get; set; }

        public virtual ICollection<LoggedWork> LoggedWork { get; set; }
        public virtual ICollection<QualityTestResult> QualityTestResults { get; set; }
        public virtual RoutingStep RoutingStep { get; set; }
        public virtual ScrapReason ScrapReason { get; set; }
        public virtual WorkOrderStepStatus Status { get; set; }
        public virtual WorkOrder WorkOrder { get; set; }

        public WorkOrderStep()
        {
        }
    }
}
