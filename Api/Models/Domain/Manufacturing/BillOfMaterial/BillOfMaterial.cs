using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [ForeignKey("InventoryItem")]
		public virtual InventoryItem Component { get; set; }

        [ForeignKey("InventoryItem")]
		public virtual InventoryItem Parent { get; set; }

        public override string SearchContent
        {
            get
            {
                return string.Join("|", new[] { this.Code, this.Parent.Name, this.Parent.Code });
            }
            set { value = ""; }
        }

        public BillOfMaterial()
        {
        }
    }
}
