using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Models.Domain.Tenant;
using Api.Models.System;

namespace Api.Services.TenantService
{
    public class TenantService : ITenantService
    {
        private readonly AppUserContext _db;

        public TenantService(AppUserContext db)
        {
            this._db = db;
        }

        public async Task<List<Tenant>> Collection(TenantFilter filter)
        {
            throw new NotImplementedException();
        }

        public async Task<Tenant> Create(Tenant model)
        {
            await _db.Tenants.AddAsync(model);
            await _db.SaveChangesAsync();

            return model;
        }

        public async Task<bool> Disable(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Tenant> Single(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Tenant> Update(Tenant model)
        {
            throw new NotImplementedException();
        }
    }
}
