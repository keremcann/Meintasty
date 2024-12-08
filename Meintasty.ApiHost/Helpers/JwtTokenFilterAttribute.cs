using Meintasty.Domain.Shared.Globals;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Meintasty.ApiHost.Helpers
{
    public class JwtTokenFilterAttribute : ActionFilterAttribute
    {
        private readonly string _secretKey;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="secretKey"></param>
        public JwtTokenFilterAttribute(string secretKey)
        {
            _secretKey = secretKey;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var token = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token == null)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            if (!ValidateToken(token, out ClaimsPrincipal principal))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var userId = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.SerialNumber)?.Value;
            var restId = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value;
            UserSettings.UserId = Convert.ToInt32(userId);
            UserSettings.RestId = Convert.ToInt32(restId);

            // Kullanıcı bilgilerini başka bir yere taşıyabilir veya loglama yapabilirsiniz
            context.HttpContext.Items["UserId"] = userId;

            // Kullanıcıyı HttpContext'e atama
            context.HttpContext.User = principal;

            base.OnActionExecuting(context);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <param name="principal"></param>
        /// <returns></returns>
        private bool ValidateToken(string token, out ClaimsPrincipal principal)
        {
            principal = null;

            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_secretKey);

                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };

                principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
                return validatedToken != null;
            }
            catch
            {
                return false;
            }
        }
    }
}
