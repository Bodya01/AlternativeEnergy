using AlternativeEnergy.Abstractions;

namespace AlternativeEnergy.Identity.Domain.Entities
{
    public sealed class RefreshToken : IEntity
    {
        public string Token { get; set; }
        public string JwtId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsUsed { get; set; }
        public bool Invalidated { get; set; }
        public Guid UserId { get; set; }
    }
}