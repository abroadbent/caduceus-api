using System;
using System.ComponentModel.DataAnnotations;
using Api.Models.Domain.General;

namespace Api.Models.Domain.Tenant
{
    public class TenantCustomSchema : DomainModel<int>
    {
        [Range(1, int.MaxValue), Required]
        public int TenantId { get; set; }

        [MinLength(1), MaxLength(100), Required]
        public string Model { get; set; }

        [Required]
        public string Schema { get; set; }

        [Range(1, int.MaxValue), Required]
        public int Version { get; set; }

        public TenantCustomSchema()
        {
            this.Version = 1;
        }
    }
}
