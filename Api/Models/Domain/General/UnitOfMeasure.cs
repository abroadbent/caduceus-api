using System;
using Api.Models.Domain.Tenant;

namespace Api.Models.Domain.General
{
    public class UnitOfMeasure : TenantModel<int>
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }

        public UnitOfMeasure()
        {
        }
    }
}
