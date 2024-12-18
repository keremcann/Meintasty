﻿using Meintasty.Application.Contract.Login.Queries;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Meintasty.ApiHost.Helpers
{
    public class MeinTastyHelper
    {
        /// <summary>
        /// Non-Used for now
        /// </summary>
        /// <returns></returns>
        private static string CrateToken(GetLoginQueryRequest user, List<string> roles)
        {
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(""));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user?.Email ?? "info@meintasty.com"),
                new Claim(ClaimTypes.Name, "SystemUser")
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var token = new JwtSecurityToken(
                "",
                "",
                claims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="roles"></param>
        /// <returns></returns>
        internal static string GenerateToken(GetLoginQueryRequest user, List<string>? roles)
        {
            var expiration = DateTime.UtcNow.AddDays(15);
            var token = CreateJwtToken(
                CreateClaims(user, roles),
                CreateSigningCredentials(),
                expiration
            );
            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rest"></param>
        /// <param name="roles"></param>
        /// <returns></returns>
        internal static string CreateToken(GetRestLoginQueryRequest rest, List<string>? roles)
        {
            var expiration = DateTime.UtcNow.AddDays(15);
            var token = CreateJwtToken(
                CreateRestClaims(rest, roles),
                CreateSigningCredentials(),
                expiration
            );
            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="claims"></param>
        /// <param name="credentials"></param>
        /// <param name="expiration"></param>
        /// <returns></returns>
        private static JwtSecurityToken CreateJwtToken(List<Claim> claims, SigningCredentials credentials,
        DateTime expiration) =>
        new(
            new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("JwtTokenSettings")["ValidIssuer"],
            new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("JwtTokenSettings")["ValidAudience"],
            claims,
            expires: expiration,
            signingCredentials: credentials
        );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="roles"></param>
        /// <returns></returns>
        private static List<Claim> CreateClaims(GetLoginQueryRequest user, List<string>? roles)
        {
            string? jwtSub = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("JwtTokenSettings")["JwtRegisteredClaimNamesSub"];
            try
            {
                var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, jwtSub ?? "345h098bb8reberbwr4vvb8945"),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString()),
                    new Claim(ClaimTypes.Email, user.Email ?? "info@meintasty.com"),
                    new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                    new Claim(ClaimTypes.Name, user.FullName ?? ""),
                    new Claim(ClaimTypes.SerialNumber, user.UserId.ToString())
                };
                
                if (roles != null && roles.Count > 0 ) 
                {
                    foreach (var role in roles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role));
                    }
                }

                return claims;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rest"></param>
        /// <param name="roles"></param>
        /// <returns></returns>
        private static List<Claim> CreateRestClaims(GetRestLoginQueryRequest rest, List<string>? roles)
        {
            string? jwtSub = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("JwtTokenSettings")["JwtRegisteredClaimNamesSub"];
            try
            {
                var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, jwtSub ?? "345h098bb8reberbwr4vvb8945"),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString()),
                    new Claim(ClaimTypes.Email, rest.Email ?? "info@meintasty.com"),
                    new Claim(ClaimTypes.NameIdentifier, rest.Url ?? "default-url"),
                    new Claim(ClaimTypes.Name, rest.FullName ?? ""),
                    new Claim(ClaimTypes.GivenName, rest.RestaurantId.ToString()),
                    new Claim(ClaimTypes.MobilePhone, rest?.PhoneNumber?.ToString() ?? "no-information")
                };

                if (roles != null && roles.Count > 0)
                {
                    foreach (var role in roles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role));
                    }
                }

                return claims;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static SigningCredentials CreateSigningCredentials()
        {
            var symmetricSecurityKey = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("JwtTokenSettings")["SymmetricSecurityKey"];

            return new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(symmetricSecurityKey ?? "fvh8456477hth44j6wfds98bq9hp8bqh9ubq9gjig3qr0[94vj5")
                ),
                SecurityAlgorithms.HmacSha256
            );
        }
    }
}
