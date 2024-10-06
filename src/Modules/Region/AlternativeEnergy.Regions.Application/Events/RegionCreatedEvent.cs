using AlternativeEnergy.Events.DDD;

namespace AlternativeEnergy.Regions.Application.Events
{
    public sealed record RegionCreatedEvent(Guid Id, string Name) : IIntegrationEvent;
}
