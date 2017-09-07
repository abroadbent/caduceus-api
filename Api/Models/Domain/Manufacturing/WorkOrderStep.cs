using System;
using System.Collections.Generic;
using Api.Models.Domain.Tenant;
using Api.Models.Domain.AppUser;
using Api.Models.Domain.Inventory;

namespace Api.Models.Domain.Manufacturing
{
    public class WorkOrderStep : TenantModel<int>
    {
        public WorkOrder WorkOrder { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public WorkOrderStepStatus Status { get; set; }
        public RoutingStep RoutingStep { get; set; }
        public ICollection<AppUser.AppUser> AssignedUsers { get; set; }
        public decimal EstimatedCost { get; set; }
        public decimal EstimatedLaborHours { get; set; }
        public decimal ActualCost { get; set; }
        public decimal ActualLaborHours { get; set; }
        public ICollection<LoggedWork> LoggedWork { get; set; }
        public ICollection<QualityTestResult> QualityTestResults { get; set; }

        public WorkOrderStep()
        {
        }
    }
}
