using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Trackify.Application.Interfaces;

namespace Trackify.Web.Filters
{
    public class JwtRefreshMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IDictionary<string, string> _refreshTokens;
        private static IConfiguration _config;
        public static void Initialize(IConfiguration config)
        {
            _config = config;
        }
        public JwtRefreshMiddleware(RequestDelegate next, IServiceScopeFactory scopeFactory, IDictionary<string, string> refreshTokens)
        {
            _next = next;
            _scopeFactory = scopeFactory;
            _refreshTokens = refreshTokens;
        }
        public async Task Invoke(HttpContext context)
        {
            using var scope = _scopeFactory.CreateScope();
            var tokenService = scope.ServiceProvider.GetRequiredService<ITokenService>();

            var jwtCookie = context.Request.Cookies["jwt"];
            if (!string.IsNullOrEmpty(jwtCookie))
            {
                var handler = new JwtSecurityTokenHandler();
                JwtSecurityToken? token = null;

                try
                {
                    token = handler.ReadToken(jwtCookie) as JwtSecurityToken;
                }
                catch { }

                if (token != null)
                {
                    var timeLeft = token.ValidTo - DateTime.UtcNow;

                    // ✅ Refresh if less than 2 minutes left
                    if (timeLeft.TotalMinutes <= Convert.ToInt16(_config["Jwt:RefreshBeforeMinutes"]))
                    {
                        var principal = tokenService.GetPrincipalFromExpiredToken(jwtCookie);
                        var email = principal?.FindFirst(ClaimTypes.Email)?.Value;

                        if (!string.IsNullOrEmpty(email))
                        {
                            if (!_refreshTokens.ContainsKey(email))
                                _refreshTokens[email] = string.Empty;

                            var newTokens = tokenService.GenerateTokens(email);
                            _refreshTokens[email] = newTokens.RefreshToken;

                            // update cookie
                            context.Response.Cookies.Append("jwt", newTokens.AccessToken, new CookieOptions
                            {
                                HttpOnly = true,
                                Secure = true,
                                SameSite = SameSiteMode.Strict,
                                Expires = DateTimeOffset.UtcNow.AddMinutes(Convert.ToInt16(_config["Jwt:ExpireMinutes"]))
                            });

                            // update session
                            var newJwt = handler.ReadToken(newTokens.AccessToken) as JwtSecurityToken;
                            if (newJwt != null)
                            {
                                context.Session.SetString("jwtExpiry", newJwt.ValidTo.ToString("yyyy-MM-ddTHH:mm:ssZ"));
                            }
                        }
                    }
                }
            }

            await _next(context);
        }
        public static Task RefreshForUserAsync(HttpContext context, ITokenService tokenService, IDictionary<string, string> refreshTokens, string email)
        {
            if (context == null || tokenService == null || refreshTokens == null || string.IsNullOrEmpty(email) || _config == null)
                return Task.CompletedTask;

            var handler = new JwtSecurityTokenHandler();
            var newTokens = tokenService.GenerateTokens(email);
            if (newTokens == null) return Task.CompletedTask;

            refreshTokens[email] = newTokens.RefreshToken;

            context.Response.Cookies.Append("jwt", newTokens.AccessToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTimeOffset.UtcNow.AddMinutes(Convert.ToInt16(_config["Jwt:ExpireMinutes"]))
            });

            var newJwt = handler.ReadToken(newTokens.AccessToken) as JwtSecurityToken;
            if (newJwt != null)
            {
                context.Session.SetString("jwtExpiry", newJwt.ValidTo.ToString("yyyy-MM-ddTHH:mm:ssZ"));
            }

            return Task.CompletedTask;
        }
        public static string ValidateToken(string token)
        {
            if (_config == null)
                throw new InvalidOperationException("Authentication not initialized. Call Authentication.Initialize(config).");

            if (string.IsNullOrEmpty(token))
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = _config["Jwt:Issuer"],
                    ValidAudience = _config["Jwt:Audience"],
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userName = jwtToken.Claims.First(claim => claim.Type == ClaimTypes.Email).Value;

                return userName;
            }
            catch
            {
                return null;
            }
        }
    }
}
