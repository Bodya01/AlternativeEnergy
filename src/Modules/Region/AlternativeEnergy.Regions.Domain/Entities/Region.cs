using AlternativeEnergy.DDD;
using AlternativeEnergy.Regions.Domain.Events;
using AlternativeEnergy.Regions.Domain.Exceptions;

namespace AlternativeEnergy.Regions.Domain.Entities
{
    public sealed class Region : Entity, IAggregateRoot
    {
        public string Name { get; private set; } = null!;

        private Region(Guid id, string name) : base(id)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new RegionNameIsEmptyException("Region name cannot be empty.");

            Name = name;
        }

        public static Region Create(Guid id, string name)
        {
            var region = new Region(id, name);
            region.AddEvent(new RegionCreatedEvent());

            return region;
        }

        public void Update(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new RegionNameIsEmptyException("Region name cannot be empty.");

            AddEvent(new RegionUpdatedEvent());

            Name = name;
        }
    }
}
