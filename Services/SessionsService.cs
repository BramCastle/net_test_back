using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using net_test.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace net_test.Services
{
    public class SessionsService
    {
        private readonly int tiempoExpiracion = 1440;

        private readonly AspNetUserService _aspNetUserService;


        public SessionsService(AspNetUserService aspNetUserService) {
            _aspNetUserService = aspNetUserService;
        }

        public AspNetUser CurrentAspNetUser(ClaimsPrincipal User) {
            return _aspNetUserService.FindById(getClaim("Id", User));
        }

        public List<Claim> ListClaims(ClaimsPrincipal User) {
            List<Claim> objReturn = null;
            
            if(User != null) {
                objReturn = User.Claims.ToList();
            }

            return objReturn;
        }

        public string getClaim(string Claim, ClaimsPrincipal User) {
            string objReturn = null;
            if(Claim != null && User != null) {
                var returnClaim = User.Claims.Where(itemClaim => itemClaim.Type == Claim).FirstOrDefault();
                if(returnClaim != null) {
                    objReturn = returnClaim.Value;
                }
            }
            return objReturn;
        }

        public OkObjectResult createToken(dynamic argSession) {

            AspNetUser objAspNetUser = _aspNetUserService.FindByEmail(argSession.email.ToString());

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, argSession.email.ToString()),
                new Claim("KeySystem", "BRAM_DEVELOPMENTS"),
                new Claim("Id", objAspNetUser.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("_BRAM_3RP_"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddMinutes(tiempoExpiracion);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "bram.com.mx",
                audience: "bram.com.mx",
                claims: claims,
                expires: expiration,
                signingCredentials: creds);


            // INICIAR SESIONES
            dynamic result = new OkObjectResult(new
            {
                id              = objAspNetUser.Id,
                user            =   new {
                                        id              = objAspNetUser.Id,
                                        email           = objAspNetUser.Email
                                    },
                token           = new JwtSecurityTokenHandler().WriteToken(token),
                rol             = "",
                idRol           = "",
                expiration      = expiration,
                action          = true
            });


            return result;

        }
        
    }
}