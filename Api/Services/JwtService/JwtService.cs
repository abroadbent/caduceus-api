using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Api.Models.Domain.AppUser;
using Api.Models.System;
using Microsoft.IdentityModel.Tokens;

namespace Api.Services
{
    public class JwtService : IJwtService
    {
        private AuthConfiguration _configuration;

        public JwtService(AuthConfiguration configuration) {
            this._configuration = configuration;        
        }

        public string GenerateEncodedToken(AppUser user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.UserName),
                new Claim(ClaimTypes.PrimarySid, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role)
            };

            // Create the JWT security token and encode it.
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration.JwtSigningKey));
            var jwt = new JwtSecurityToken(
                issuer: _configuration.JwtIssuer,
                audience: _configuration.JwtAudience,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(_configuration.JwtValidFor)),
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256));

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodedJwt;
        }
    }
}
