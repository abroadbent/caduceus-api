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
        public int AlternativeStepId { get; set; }
        public int RoutingId { get; set; }

        public virtual RoutingStep AlternativeStep { get; set; }
        public virtual ICollection<Skill> RequiredSkills { get; set; }
        public virtual ICollection<QualityTest> RequiredQualityTests { get; set; }
        public virtual Routing Routing { get; set; }

        public RoutingStep()
        {
        }
    }
}
