using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Api.Models.Domain.Tenant;

namespace Api.Models.Domain.Inventory
{
    public class InventoryLocation : TenantModel<int>
    {
        [MaxLength(255)]
        public string Description { get; set; }

        [MinLength(1), MaxLength(25), Required]
        public string Name { get; set; }

        public int? ParentId { get; set; }

        [Required]
        public int StatusId { get; set; }

        public override string SearchContent
        {
            get
            {
                return string.Join("|", new[] { this.Name, this.Description });
            }
            set { value = ""; }
        }

        public virtual InventoryLocation Parent { get; set; }
        public virtual ICollection<InventoryLocation> SubLocations { get; set; }
        public virtual InventoryLocationStatus Status { get; set; }

        public InventoryLocation()
        {
        }
    }
}
