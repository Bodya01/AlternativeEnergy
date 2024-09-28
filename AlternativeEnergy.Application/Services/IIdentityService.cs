using System.Security.Claims;

namespace AlternativeEnergy.Application.Services
{
    public interface IIdentityService
    {
        string GenerateToken(Guid userId, string email);
        ClaimsPrincipal ValidateToken(string token);
        Task<(bool isSuccessful, AuthenticationResultDto authResult)> LoginAsync(LoginDto loginDto)
    }
}
