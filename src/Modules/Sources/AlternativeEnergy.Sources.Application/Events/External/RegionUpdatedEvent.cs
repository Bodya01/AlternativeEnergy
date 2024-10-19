using AlternativeEnergy.Events.DDD;

namespace AlternativeEnergy.Sources.Application.Events.External
{
    internal sealed record RegionUpdatedEvent(Guid Id, string Name) : IIntegrationEvent;
}
