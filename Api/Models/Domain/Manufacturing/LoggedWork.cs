using System;
using Api.Models.Domain.Tenant;

namespace Api.Models.Domain.Manufacturing
{
    public class LoggedWork : TenantModel<int>
    {
        public AppUser.AppUser User { get; set; }
        public string Description { get; set; }

        // todo: does this need to go against a work order?
        public WorkOrder WorkOrder { get; set; }

        public LoggedWork()
        {
        }
    }
}
