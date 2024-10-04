using AlternativeEnergy.DDD;
using AlternativeEnergy.DDD.Interfaces;

namespace AlternativeEnergy.Domain.Entities
{
    public class Co2Emissions : IEntity
    {
        public Guid Id { get; set; }

        public float EmissionsPerUnit { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Guid SourceId { get; set; }
        public Guid RegionId { get; set; }

        public IReadOnlyList<IDomainEvent> Events => throw new NotImplementedException();
    }
}