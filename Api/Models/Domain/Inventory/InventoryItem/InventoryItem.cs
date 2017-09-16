using System;
using System.Collections.Generic;
using Api.Models.Domain.General;
using Api.Models.Domain.Manufacturing;
using Api.Models.Domain.Tenant;

namespace Api.Models.Domain.Inventory
{
    public class InventoryItem : TenantModel<int>
	{
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal Height { get; set; }
        public decimal Length { get; set; }
		public string Name { get; set; }
        public string Revision { get; set; }
        public int StatusId { get; set; }
        public int UnitOfMeasureId { get; set; }
        public decimal Weight { get; set; }
        public decimal Width { get; set; }

		public virtual ICollection<BillOfMaterial> BillOfMaterials { get; set; }
		public virtual ICollection<Routing> Routings { get; set; }
        public virtual InventoryItemStatus Status { get; set; }
        public virtual UnitOfMeasure UnitOfMeasure { get; set; }

        public InventoryItem()
        {

        }
    }
}
