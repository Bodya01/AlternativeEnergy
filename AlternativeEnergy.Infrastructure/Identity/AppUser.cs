using Microsoft.AspNetCore.Identity;

namespace AlternativeEnergy.Infrastructure.Identity
{
    //TODO: Move to identity module
    public class AppUser : IdentityUser<Guid>
    {
        public Guid RegionId { get; set; }
    }
}
