using AlternativeEnergy.DDD;

namespace AlternativeEnergy.Sources.Domain.Entities
{
    public class UserEnergyChoice : Entity, IAggregateRoot
    {
        public UserEnergyChoice(Guid id, float consumption, DateTime consumptionDate, Guid userId, Guid regionId, Guid sourceId) : base(id)
        {
            Id = id;
            Consumption = consumption;
            ConsumptionDate = consumptionDate;
            SourceId = sourceId;
            UserId = userId;
            RegionId = regionId;
        }

        public float Consumption { get; private set; } //measured in kW-h
        public DateTime ConsumptionDate { get; private set; }

        public Guid SourceId { get; private set; }
        public Guid UserId { get; private set; }
        public Guid RegionId { get; private set; }

        public Source Source { get; private set; }
        public Region Region { get; private set; }

    }
}
