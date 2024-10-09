using AlternativeEnergy.DDD;

namespace AlternativeEnergy.Footprints.Domain.Entities
{
    public sealed class Footprints : Entity
    {
        public float TotalEmissions { get; set; } // Total CO2 emissions (g/kg)
        public float EnergyUsed { get; set; } //kwt ph
        public float WaterUsed { get; set; } //liters
        public float WastesProduced { get; set; } //kgs
        public float FootprintArea { get; set; } //area

        public DateTime CalculatedAt { get; set; }

        public Guid UserId { get; set; }
        public Guid RegionId { get; set; }
    }
}
