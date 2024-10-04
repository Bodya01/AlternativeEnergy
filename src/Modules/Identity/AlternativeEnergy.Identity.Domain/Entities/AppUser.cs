using AlternativeEnergy.DDD;
using AlternativeEnergy.DDD.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace AlternativeEnergy.Identity.Domain.Entities
{
    public sealed class AppUser : IdentityUser<Guid>, IEntity
    {
        public Guid RegionId { get; set; }

        public IReadOnlyList<IDomainEvent> Events => throw new NotImplementedException();
    }
}
