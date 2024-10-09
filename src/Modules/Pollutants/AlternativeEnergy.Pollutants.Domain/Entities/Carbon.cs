using AlternativeEnergy.DDD;

namespace AlternativeEnergy.Pollutants.Domain.Entities
{
    public sealed class Carbon : Entity
    {
        public float EmissionsPerUnit { get; set; }

        public Guid SourceId { get; set; }
        public Guid RegionId { get; set; }
    }
}
