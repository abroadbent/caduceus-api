using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models.Domain.AppUser;

namespace Api.Services
{
    public interface IAppUserService : ICrudService<AppUser, RegistrationViewModel, EditableAppUserViewModel, AppUserFilter>
    {
        Task<AuthResponse> Login(LoginViewModel model);
    }
}
