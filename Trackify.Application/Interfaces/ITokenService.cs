using System.Security.Claims;
using Trackify.Application.DTOs;

namespace Trackify.Application.Interfaces
{
    public interface ITokenService
    {
        TokenResponse GenerateTokens(string Email);
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
