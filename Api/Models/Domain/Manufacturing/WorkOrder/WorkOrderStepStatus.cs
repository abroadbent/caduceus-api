using System;
using Api.Models.Domain.General;

namespace Api.Models.Domain.Manufacturing
{
    public class WorkOrderStepStatus : Status
    {
        //todo: add real statuses
        public enum Statuses
        { 
            Unknown = 1
        }

        public WorkOrderStepStatus()
        {
        }
    }
}
