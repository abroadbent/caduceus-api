using System;
namespace Api.Models.Domain.AppUser
{
    public struct AuthResponse
    {
        public string Error { get; set; }
        public string Token { get; set; }

        public AuthResponse(string token, string error = "")
        {
            this.Error = error;
            this.Token = token;
        }
    }
}
