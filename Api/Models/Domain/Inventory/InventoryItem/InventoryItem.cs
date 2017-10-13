using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Api.Models.Domain.General;
using Api.Models.Domain.Manufacturing;
using Api.Models.Domain.Tenant;

namespace Api.Models.Domain.Inventory
{
    public class InventoryItem : TenantModel<int>
	{
        [MinLength(1), MaxLength(25), Required]
        public string Code { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        public decimal? Height { get; set; }
        public decimal? Length { get; set; }

        [MinLength(1), MaxLength(100), Required]
		public string Name { get; set; }

        [MaxLength(10)]
        public string Revision { get; set; }

        public override string SearchContent
        {
            get
            {
                return string.Join("|", new[] { this.Code, this.Name, this.Revision, this.Description });
            }
            set { value = ""; }
        }

        [Required]
        public int StatusId { get; set; }

        public decimal? Weight { get; set; }
        public decimal? Width { get; set; }

        public virtual ICollection<Attachment> Attachments { get; set; }
		public virtual ICollection<BillOfMaterial> BillOfMaterials { get; set; }
		public virtual ICollection<Routing> Routings { get; set; }
        public virtual InventoryItemStatus Status { get; set; }

        public InventoryItem()
        {

        }
    }
}
