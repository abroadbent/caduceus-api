using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Api.Models.Domain.AppUser;
using Api.Models.System;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace Api.Services
{
    public class AppUserService : IAppUserService
    {
		private readonly IMapper _mapper;
		private readonly ApplicationDbContext _db;

		public AppUserService(IMapper mapper, ApplicationDbContext db)
		{
			this._mapper = mapper;
			this._db = db;
		}

        public async Task<IEnumerable<AppUser>> Collection(AppUserFilter filter)
        {
            var query = _db.AppUsers.AsQueryable();

            if (filter.Created.HasValue) {
                query.Where(a => a.Created >= filter.Created.Start && a.Created <= filter.Created.End);
            }

			if (filter.IsActive.HasValue)
			{
				query.Where(a => a.IsActive == filter.IsActive);
			}

			if (filter.Modified.HasValue)
			{
                query.Where(a => a.Modified >= filter.Modified.Start && a.Modified <= filter.Modified.End);
			}

            if (!string.IsNullOrWhiteSpace(filter.SearchCriteria))
            {
                query.Where(a => a.SearchContent.Contains(filter.SearchCriteria));
            }

            // todo: it says async is not supported for this iqueryable provider
            return await query.ToListAsync();
        }

        public async Task<AppUser> Create(RegistrationViewModel model)
        {
            var user = _mapper.Map<AppUser>(model);

            await _db.AppUsers.AddAsync(user);
            await _db.SaveChangesAsync();

            return user;
        }

        public async Task<bool> Disable(string id)
        {
            var user = await Single(id);
            user.IsActive = false;

            return await _db.SaveChangesAsync() == 1;
        }

        public async Task<string> Login(LoginViewModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<AppUser> Single(string id)
        {
            return await _db.AppUsers.SingleAsync(a => a.Id == id);
        }

        public async Task<AppUser> Update(EditableAppUserViewModel model)
        {
            var user = await Single(model.Id);
            user = _mapper.Map<AppUser>(model);

            await _db.SaveChangesAsync();

            return user;
        }
    }
}
