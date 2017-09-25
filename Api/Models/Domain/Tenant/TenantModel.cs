using System;
using Api.Models.Domain.General;

namespace Api.Models.Domain.Tenant
{
    public abstract class TenantModel<T> : DomainModel<T>
    {
        public string CustomJsonData { get; set; }
        public T TenantId { get; set; }

        public virtual Tenant Tenant { get; set; }

        public TenantModel()
        {
        }
    }
}
