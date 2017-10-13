using System;
namespace Api.Models.System
{
    public class AuthConfiguration
    {
        public string JwtAudience { get; set; }
        public string JwtAuthority { get; set; }
        public string JwtIssuer { get; set; }
        public string JwtSigningKey { get; set; }
        public double JwtValidFor { get; set; }
    }
}
