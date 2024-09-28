#nullable disable

namespace AlternativeEnergy.Infrastructure.Identity.Models
{
    public sealed class AuthenticationResult
    {
        public string JwtId { get; set; }
        public string JwtToken { get; set; }
        public DateTime? JwtExpireTime { get; set; }
        public string RefreshToken { get; set; }
        public AppUser User { get; set; }
    }
}
