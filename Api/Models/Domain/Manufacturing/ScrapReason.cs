using System;
using System.ComponentModel.DataAnnotations;
using Api.Models.Domain.Tenant;

namespace Api.Models.Domain.Manufacturing
{
    public class ScrapReason : TenantModel<int>
    {
        [MinLength(1), MaxLength(10), Required]
		public string Code { get; set; }

        [MaxLength(255)]
		public string Description { get; set; }

        [MinLength(1), MaxLength(25), Required]
		public string Name { get; set; }

        public ScrapReason()
        {
        }
    }
}
