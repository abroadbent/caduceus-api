using System;
using Api.Models.Domain.General;

namespace Api.Models.Domain.Tenant
{
    public abstract class TenantModel<T> : DomainModel<T>
    {
        public Tenant Tenant { get; set; }

        public TenantModel()
        {
        }
    }
}
