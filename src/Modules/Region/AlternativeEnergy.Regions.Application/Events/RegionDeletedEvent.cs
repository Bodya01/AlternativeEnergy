using AlternativeEnergy.Events.DDD;

namespace AlternativeEnergy.Regions.Application.Events
{
    internal sealed record RegionDeletedEvent(Guid Id) : IIntegrationEvent;
}
