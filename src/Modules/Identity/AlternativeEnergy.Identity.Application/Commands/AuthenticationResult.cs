using AlternativeEnergy.Identity.Domain.Entities;

namespace AlternativeEnergy.Identity.Application.Commands
{
    public sealed record AuthenticationResult(string JwtId, string JwtToken, DateTime? JwtExpireTime, string RefreshToken, User User);
}
