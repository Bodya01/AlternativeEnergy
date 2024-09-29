using AlternativeEnergy.Abstractions;

namespace AlternativeEnergy.Sources.Domain.Entities
{
    public class UserEnergyChoice : IEntity
    {
        public Guid Id { get; set; }

        public float Consumption { get; set; } //measured in kW-h
        public DateTime ConsumptionDate { get; set; }

        public Guid SourceId { get; set; }
        public Guid UserId { get; set; }
        public Guid RegionId { get; set; }
    }
}
