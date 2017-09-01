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
        Task<bool> Disable(string id);
        Task<string> Login(LoginViewModel model);
        Task<AppUser> Single(string id);
        Task<AppUser> Update(EditableAppUserViewModel model);
    }
}
