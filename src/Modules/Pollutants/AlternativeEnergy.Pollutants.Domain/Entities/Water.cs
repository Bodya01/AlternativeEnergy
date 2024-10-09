using AlternativeEnergy.DDD;

namespace AlternativeEnergy.Pollutants.Domain.Entities
{
    public sealed class Water : Entity
    {
        /// <summary>
        /// Total liters of water used
        /// </summary>
        public float Used { get; set; }
        public DateTime ConsumptionDate { get; set; }

        public Guid UserId { get; set; }
        public Guid RegionId { get; set; }
    }
}
