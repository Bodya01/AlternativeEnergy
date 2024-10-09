using AlternativeEnergy.DDD;

namespace AlternativeEnergy.Pollutants.Domain.Entities
{
    public sealed class TransportUsage : Entity
    {
        public float ConsumedFuel { get; set; }
        public float Distance { get; set; }

        public DateTime UsageDate { get; set; }

        public Guid UserId { get; set; }
        public Guid TransportId { get; set; }
    }
}
