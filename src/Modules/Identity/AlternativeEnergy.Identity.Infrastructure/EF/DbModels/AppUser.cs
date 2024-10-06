using Microsoft.AspNetCore.Identity;

namespace AlternativeEnergy.Identity.Infrastructure.EF.DbModels
{
    public sealed class AppUser : IdentityUser<Guid>
    {
        public Guid RegionId { get; set; }
    }
}
