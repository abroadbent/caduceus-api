using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Api.Models.Domain.General;
using Api.Models.Domain.AppUser;
using Api.Models.Domain.Inventory;
using Api.Models.Domain.Manufacturing;

namespace Api.Models.Domain.Tenant
{
    public class Tenant : DomainModel<int>
    {
        [MaxLength(50), MinLength(1), Required]
        public string Name { get; set; }

        [MaxLength(255), Required]
        public override string SearchContent
        {
            get
            {
                return string.Join("|", new[] { this.Name });
            }
            set { value = ""; }
        }

        public Tenant() : base()
        {
        }

        public Tenant(string name) : this()
        {
            this.Name = name;
        }
    }
}
