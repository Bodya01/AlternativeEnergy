using AlternativeEnergy.Events;

namespace AlternativeEnergy.Regions.Application.Events
{
    internal sealed record RegionUpdatedEvent(Guid Id, string Name);// : IEvent;
}
