using System;
using System.Collections.Generic;
using Api.Models.Domain.General;
using Api.Models.Domain.Tenant;

namespace Api.Models.Domain.Manufacturing
{
    public class RoutingStep : TenantModel<int>
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public RoutingStep AlternativeStep { get; set; }
        public ICollection<Skill> RequiredSkills { get; set; }
        public ICollection<QualityTest> RequiredQualityTests { get; set; }

        public Routing Routing { get; set; }

        public RoutingStep()
        {
        }
    }
}
