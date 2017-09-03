using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Api.Models.System;

namespace Api.Services
{
    public class JwtService : IJwtService
    {
        public async Task<string> GenerateEncodedToken(string userName)
        {
            var jwtOptions = new JwtIssuerOptions();
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userName),
                new Claim(JwtRegisteredClaimNames.Jti, await jwtOptions.JtiGenerator())

                // todo: this requires outside information not provided in the sample i worked from
                //new Claim(JwtRegisteredClaimNames.Iat, jwtOptions.IssuedAt.ToString(), ClaimValueTypes.Integer64), identity.FindFirst(Helpers.Constants.Strings.JwtClaimIdentifiers.Rol),
                //identity.FindFirst(Helpers.Constants.Strings.JwtClaimIdentifiers.Id)
            };

            // Create the JWT security token and encode it.
            var jwt = new JwtSecurityToken(
                issuer: jwtOptions.Issuer,
                audience: jwtOptions.Audience,
                claims: claims,
                notBefore: jwtOptions.NotBefore,
                expires: jwtOptions.Expiration,
                signingCredentials: jwtOptions.SigningCredentials);

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodedJwt;
        }
    }
}
