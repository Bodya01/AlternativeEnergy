using Microsoft.AspNetCore.Identity;

namespace AlternativeEnergy.Infrastructure.Identity
{
    public class AppUser : IdentityUser<Guid>
    {
        public Guid RegionId { get; set; }
    }
}
