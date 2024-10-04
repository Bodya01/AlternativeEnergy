using AlternativeEnergy.DDD;
using AlternativeEnergy.DDD.Interfaces;

namespace AlternativeEnergy.Domain.Entities
{
    public class Footprints : IEntity
    {
        public Guid Id { get; set; }

        public float TotalEmissions { get; set; } //g or kg
        public float EnergyUsed { get; set; } //kW-h
        public DateTime CalculatedAt { get; set; }

        public Guid UserId { get; set; }
        public Guid RegionId { get; set; }

        public IReadOnlyList<IDomainEvent> Events => throw new NotImplementedException();
    }
}