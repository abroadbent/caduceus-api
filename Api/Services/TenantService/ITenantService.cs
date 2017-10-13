using System;
using Api.Models.Domain.Tenant;

namespace Api.Services.TenantService
{
    public interface ITenantService : ICrudService<Tenant, Tenant, Tenant, TenantFilter>
    {
    }
}
