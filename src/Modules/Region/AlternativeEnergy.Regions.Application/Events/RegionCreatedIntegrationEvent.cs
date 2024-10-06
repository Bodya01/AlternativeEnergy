using AlternativeEnergy.DDD;

namespace AlternativeEnergy.Regions.Application.Events
{
    public sealed record RegionCreatedIntegrationEvent(Guid Id, string Name) : IIntegrationEvent;
}
