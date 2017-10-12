using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models.Domain.AppUser;
using Api.Models.System;
using Api.Utilities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Api.Services.AppUserService
{
    public class AppUserService : IAppUserService
    {
		private readonly IMapper _mapper;
		private readonly ApplicationDbContext _db;
        private readonly IJwtService _jwtService;
        private readonly ILogger _logger;

        public AppUserService(IMapper mapper, ApplicationDbContext db, IJwtService jwtService, ILogger<AppUserService> logger)
		{
			this._mapper = mapper;
			this._db = db;
            this._jwtService = jwtService;
            this._logger = logger;
		}

        public async Task<List<AppUser>> Collection(AppUserFilter filter)
        {
            var query = _db.AppUsers.AsQueryable();

            if (filter.Created.HasValue) {
                query = query.Where(a => a.Created >= filter.Created.Start && a.Created <= filter.Created.End);
            }

			if (filter.IsActive.HasValue)
			{
				query = query.Where(a => a.IsActive == filter.IsActive);
			}

			if (filter.Modified.HasValue)
			{
                query = query.Where(a => a.Modified >= filter.Modified.Start && a.Modified <= filter.Modified.End);
			}

            if (!string.IsNullOrWhiteSpace(filter.SearchCriteria))
            {
                query = query.Where(a => a.SearchContent.Contains(filter.SearchCriteria));
            }

            return await Task.FromResult(query.ToList());
        }

        public async Task<AppUser> Create(AppUserRegistration model)
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
			if (user == null)
			{
				_logger.LogWarning("No matching user to disable with the following id: " + id.ToString());
                return false;
			}

            user.IsActive = false;

            return await Task.FromResult(_db.SaveChanges() == 1);
        }

        public async Task<AuthResponse> Login(AppUserLogin model)
        {
            // get user based on username
            var user = await _db.AppUsers.Where(a => a.UserName == model.Username).SingleOrDefaultAsync();

            // check if username is not found
            if(user == null)
            {
                _logger.LogInformation("Username not found for " + model.Username);
                return new AuthResponse() { Error = "Username was not found." };
            }

            // validate password
            if(!Encryption.ValidateHashedPassword(model.Password, user.PasswordHash))
            {
                _logger.LogInformation("Invalid login for " + model.Username);
                throw new UnauthorizedAccessException();
            }

            // get JWT token string
            var token = await _jwtService.GenerateEncodedToken(model.Username, user.Role);

            // return auth response
            return new AuthResponse(token);
        }

        public async Task<AppUser> Single(int id)
        {
            return await Task.FromResult(_db.AppUsers.SingleOrDefault(a => a.Id == id));
        }

        public async Task<AppUser> Update(AppUserUpdate model)
        {
            var user = await Single(model.Id);
            if(user == null)
            {
                _logger.LogWarning("No matching user to update with the following id: " + model.Id.ToString());
                return null;
            }

            user = _mapper.Map<AppUser>(model);

            await _db.SaveChangesAsync();

            return user;
        }
    }
}
