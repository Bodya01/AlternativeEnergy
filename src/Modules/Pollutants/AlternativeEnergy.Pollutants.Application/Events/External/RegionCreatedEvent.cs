using AlternativeEnergy.Events.DDD;

namespace AlternativeEnergy.Pollutants.Application.Events.External
{
    public sealed record RegionCreatedEvent(Guid Id, string Name) : IIntegrationEvent;
}