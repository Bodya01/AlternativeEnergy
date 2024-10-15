using AlternativeEnergy.DDD;

namespace AlternativeEnergy.Pollutants.Domain.Entities
{
    public sealed class Waste : Entity
    {
        /// <summary>
        /// Total wastes produced in kg
        /// </summary>
        public float Produced { get; set; }
        public string WasteType { get; set; } // TODO: replace with enum
        public DateTime CollectionTime { get; set; }

        public Guid UserId { get; set; }
        public Guid RegionId { get; set; }

        public Region Region { get; set; } = null!;
    }
}
