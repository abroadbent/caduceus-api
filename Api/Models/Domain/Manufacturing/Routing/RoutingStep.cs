using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Api.Models.Domain.General;
using Api.Models.Domain.Tenant;

namespace Api.Models.Domain.Manufacturing
{
    public class RoutingStep : TenantModel<int>
    {
        [MaxLength(255)]
        public string Description { get; set; }

        [MinLength(1), MaxLength(100), Required]
        public string Name { get; set; }

        public int AlternativeStepId { get; set; }

        [Required]
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
