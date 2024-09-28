using Microsoft.AspNetCore.Identity;

namespace AlternativeEnergy.Identity.Domain.Entities
{
    public sealed class AppUser : IdentityUser<Guid>
    {
        public Guid RegionId { get; set; }
    }
}
