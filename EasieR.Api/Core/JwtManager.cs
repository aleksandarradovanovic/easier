using EasieR.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EasieR.Api.Core
{
    public class JwtManager
    {
        private readonly EasieRContext _context;

        public JwtManager(EasieRContext context)
        {
            _context = context;
        }

        public string MakeToken(string username, string password)
        {
            try
            {
                var user = _context.Users.Include(u => u.Actor).ThenInclude(x => x.ActorRoles).ThenInclude(x => x.Roles)
                    .FirstOrDefault(x => x.UserName == username && x.Password == password);

                if (user == null)
                {
                    return null;
                }

                var actor = new JwtActor
                {
                    Id = user.Id,
                    AllowedUsecases = user.Actor.ActorRoles.Select(x => x.Roles.Name),
                    Identity = user.UserName
                };

                var issuer = "asp_api";
                var secretKey = "ThisIsMyVerySecretKey";
                var claims = new List<Claim> // Jti : "", 
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString(), ClaimValueTypes.String, issuer),
                new Claim(JwtRegisteredClaimNames.Iss, "asp_api", ClaimValueTypes.String, issuer),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64, issuer),
                new Claim("UserId", actor.Id.ToString(), ClaimValueTypes.String, issuer),
                new Claim("ActorData", JsonConvert.SerializeObject(actor), ClaimValueTypes.String, issuer)
            };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var now = DateTime.UtcNow;
                var token = new JwtSecurityToken(
                    issuer: issuer,
                    audience: "Any",
                    claims: claims,
                    notBefore: now,
                    expires: now.AddDays(30),
                    signingCredentials: credentials);

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
