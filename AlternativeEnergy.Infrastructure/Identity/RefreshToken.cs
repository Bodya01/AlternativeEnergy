namespace AlternativeEnergy.Infrastructure.Identity
{
    //TODO: move to identity module
    public sealed class RefreshToken
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