#nullable disable

using AlternativeEnergy.Identity.Domain.Entities;

namespace AlternativeEnergy.Identity.Infrastructure.Models
{
    public sealed class AuthenticationResult
    {
        public string JwtId { get; set; }
        public string JwtToken { get; set; }
        public DateTime? JwtExpireTime { get; set; }
        public string RefreshToken { get; set; }
        public AppUser User { get; set; }

        public AuthenticationResult(string jwtId, string jwtToken, DateTime? jwtExpireTime, string refreshToken, AppUser user)
        {
            JwtId = jwtId;
            JwtToken = jwtToken;
            JwtExpireTime = jwtExpireTime;
            RefreshToken = refreshToken;
            User = user;
        }
    }
}
