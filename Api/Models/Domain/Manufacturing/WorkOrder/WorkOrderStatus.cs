using System;
using Api.Models.Domain.General;
using Api.Models.Domain.Tenant;

namespace Api.Models.Domain.Manufacturing
{
    public class WorkOrderStatus : Status
    {
        // todo: add enum list
        public enum Statuses 
        {
            Unknown = 1
        }

        public WorkOrderStatus()
        {
        }
    }
}
