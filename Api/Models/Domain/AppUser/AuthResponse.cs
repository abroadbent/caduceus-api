using System;
namespace Api.Models.Domain.AppUser
{
    public struct AuthResponse
    {
        public string Token { get; set; }

        public AuthResponse(string token)
        {
            this.Token = token;    
        }
    }
}
