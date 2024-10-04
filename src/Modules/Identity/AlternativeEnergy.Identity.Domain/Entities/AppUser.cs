using AlternativeEnergy.DDD;
using AlternativeEnergy.DDD.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AlternativeEnergy.Identity.Domain.Entities
{
    public sealed class AppUser : IdentityUser<Guid>, IEntity
    {
        public Guid RegionId { get; private set; }

        [NotMapped]
        [JsonIgnore]
        public IReadOnlyList<IDomainEvent> Events => throw new NotImplementedException();
    }
}
