using System;
using System.Collections.Generic;
using Api.Models.Domain.Tenant;

namespace Api.Models.Domain.Manufacturing
{
    public class Routing : TenantModel<int>
    {
        public string Code { get; set; }
        public ICollection<RoutingStep> Steps { get; set; }

        public Routing()
        {
        }
    }
}
