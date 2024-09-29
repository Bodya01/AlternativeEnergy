using AlternativeEnergy.Abstractions;
using Microsoft.AspNetCore.Identity;

namespace AlternativeEnergy.Identity.Domain.Entities
{
    public sealed class AppUser : IdentityUser<Guid>, IEntity
    {
        public Guid RegionId { get; set; }
    }
}
