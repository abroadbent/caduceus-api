using System;
using System.Threading.Tasks;

namespace Api.Services
{
    public interface IJwtService
    {
        Task<string> GenerateEncodedToken(string userName);
    }
}
