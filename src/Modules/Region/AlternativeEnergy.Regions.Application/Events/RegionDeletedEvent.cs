using AlternativeEnergy.DDD;

namespace AlternativeEnergy.Regions.Application.Events
{
    internal sealed record RegionDeletedEvent(Guid Id) : IIntegrationEvent;
}
