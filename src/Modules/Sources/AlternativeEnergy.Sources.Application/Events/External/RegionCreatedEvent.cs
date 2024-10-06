using AlternativeEnergy.Events;

namespace AlternativeEnergy.Sources.Application.Events.External
{
    public sealed record RegionCreatedEvent(Guid Id, string Name) : IEvent;
}
