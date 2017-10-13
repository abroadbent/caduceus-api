using System;
using System.Threading.Tasks;
using Api.Models.Domain.AppUser;

namespace Api.Services
{
    public interface IJwtService
    {
        string GenerateEncodedToken(AppUser user);
    }
}
