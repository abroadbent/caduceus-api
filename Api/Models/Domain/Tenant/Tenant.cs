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

        public virtual ICollection<AppUser.AppUser> AppUsers { get; set; }
        public virtual ICollection<InventoryItem> InventoryItems { get; set; }
        public virtual ICollection<InventoryLocation> InventoryLocations { get; set; }
        public virtual ICollection<InventoryStock> InventoryStock { get; set; }
        public virtual ICollection<Routing> Routings { get; set; }
        public virtual ICollection<WorkOrder> WorkOrders { get; set; }

        public Tenant()
        {
        }
    }
}
