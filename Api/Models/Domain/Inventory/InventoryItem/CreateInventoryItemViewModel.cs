using System;
using System.Collections.Generic;
using Api.Models.Domain.General;
using Api.Models.Domain.Manufacturing;

namespace Api.Models.Domain.Inventory
{
    public class CreateInventoryItemViewModel
    {
		public string Code { get; set; }
		public string Description { get; set; }
		public decimal Height { get; set; }
		public decimal Length { get; set; }
		public string Revision { get; set; }
        public int UnitOfMeasureId { get; set; }
		public decimal Weight { get; set; }
		public decimal Width { get; set; }

		public virtual ICollection<BillOfMaterial> BillOfMaterials { get; set; }
		public virtual ICollection<Routing> Routings { get; set; }
        public virtual UnitOfMeasure UnitOfMeasure { get; set; }
	}
}
