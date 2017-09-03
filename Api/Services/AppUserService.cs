using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models.Domain.AppUser;
using Api.Models.System;
using Api.Utilities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Api.Services
{
    public class AppUserService : IAppUserService
    {
		private readonly IMapper _mapper;
		private readonly ApplicationDbContext _db;
        private readonly IJwtService _jwtService;

        public AppUserService(IMapper mapper, ApplicationDbContext db, IJwtService jwtService)
		{
			this._mapper = mapper;
			this._db = db;
            this._jwtService = jwtService;
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

            // hash password
            user.PasswordHash = Encryption.HashPassword(model.Password);

            await _db.AppUsers.AddAsync(user);
            await _db.SaveChangesAsync();

            return user;
        }

        public async Task<bool> Disable(int id)
        {
            var user = await Single(id);
            user.IsActive = false;

            return await _db.SaveChangesAsync() == 1;
        }

        public async Task<string> Login(LoginViewModel model)
        {
            // todo: need to check for bad username too
            // get user based on username
            var user = await _db.AppUsers.Where(a => a.UserName == model.Username).SingleAsync();

            // validate password
            if(!Encryption.ValidateHashedPassword(model.Password, user.PasswordHash))
            {
                throw new UnauthorizedAccessException();
            }

            // return the JWT token string
            return await _jwtService.GenerateEncodedToken(model.Username);
        }

        public async Task<AppUser> Single(int id)
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
