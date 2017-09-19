using System;
using System.ComponentModel.DataAnnotations;
using Api.Models.Domain.Inventory;
using Api.Models.Domain.Tenant;

namespace Api.Models.Domain.Manufacturing
{
    public class BillOfMaterial : TenantModel<int>
    {
        [MinLength(1), MaxLength(25), Required]
        public string Code { get; set; }

        [Required]
        public int ComponentId { get; set; }

        [Required]
        public int ParentId { get; set; }

        [Range(1, double.MaxValue), Required]
        public double Quantity { get; set; }

		public virtual InventoryItem Component { get; set; }
		public virtual InventoryItem Parent { get; set; }

        public BillOfMaterial()
        {
        }
    }
}
