using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Api.Models.Domain.Tenant;

namespace Api.Models.Domain.Manufacturing
{
    public class Routing : TenantModel<int>
    {
        [MinLength(1), MaxLength(25), Required]
        public string Code { get; set; }

        public override string SearchContent
        {
            get
            {
                return string.Join("|", new[] { this.Code });
            }
            set { value = ""; }
        }

        public virtual ICollection<RoutingStep> Steps { get; set; }

        public Routing()
        {
        }
    }
}
