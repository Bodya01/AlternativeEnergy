using AlternativeEnergy.DDD;

namespace AlternativeEnergy.Domain.Entities
{
    public class Footprints : Entity
    {
        public float TotalEmissions { get; set; } //g or kg
        public float EnergyUsed { get; set; } //kW-h
        public DateTime CalculatedAt { get; set; }

        public Guid UserId { get; set; }
        public Guid RegionId { get; set; }
    }
}