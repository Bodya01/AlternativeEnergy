using AlternativeEnergy.DDD;

namespace AlternativeEnergy.Regions.Application.Events
{
    internal sealed record RegionCreatedEvent(Guid Id, string Name) : IIntegrationEvent;
}
