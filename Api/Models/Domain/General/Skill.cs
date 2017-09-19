using System;
using System.ComponentModel.DataAnnotations;
using Api.Models.Domain.Tenant;

namespace Api.Models.Domain.General
{
    public class Skill : TenantModel<int>
    {
        [MaxLength(255)]
        public string Description { get; set; }

        [MinLength(1), MaxLength(100), Required]
        public string Name { get; set; }

        public Skill()
        {
        }
    }
}
