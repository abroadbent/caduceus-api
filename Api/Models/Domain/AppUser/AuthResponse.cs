using System;
namespace Api.Models.Domain.AppUser
{
    public class AuthToken
    {
        public string Token { get; set; }

        public AuthToken(string token)
        {
            this.Token = token;    
        }
    }
}
