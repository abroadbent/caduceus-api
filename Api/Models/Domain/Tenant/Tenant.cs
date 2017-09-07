using System;
using System.ComponentModel.DataAnnotations;
using Api.Models.Domain.General;

namespace Api.Models.Domain.Tenant
{
    public class Tenant : DomainModel<int>
    {
        [MaxLength(50), MinLength(1), Required]
        public string Name { get; set; }

        public Tenant()
        {
        }
    }
}
