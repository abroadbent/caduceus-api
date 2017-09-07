using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models.Domain.AppUser;

namespace Api.Services
{
    public interface IAppUserService
    {
        Task<IEnumerable<AppUser>> Collection(AppUserFilter filter);
        Task<AppUser> Create(RegistrationViewModel model);
        Task<bool> Disable(int id);
        Task<AuthResponse> Login(LoginViewModel model);
        Task<AppUser> Single(int id);
        Task<AppUser> Update(EditableAppUserViewModel model);
    }
}
