using System;
using System.Collections.Generic;
using Api.Models.Domain.General;
using Api.Models.Domain.Manufacturing;
using Api.Models.Domain.Tenant;

namespace Api.Models.Domain.Inventory
{
    public class ItemDefinition : TenantModel<int>
	{
        public ICollection<BillOfMaterial> BillOfMaterials { get; set; }
		public string Code { get; set; }
        public string Description { get; set; }
        public decimal Height { get; set; }
        public decimal Length { get; set; }
		public string Name { get; set; }
        public string Revision { get; set; }
        public ItemStatus Status { get; set; }
        public UnitOfMeasure UnitOfMeasure { get; set; }
        public decimal Weight { get; set; }
        public decimal Width { get; set; }

        public ItemDefinition()
        {

        }
    }
}
