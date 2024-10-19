using AlternativeEnergy.Events.DDD;

namespace AlternativeEnergy.Sources.Application.Events.External
{
    internal sealed record RegionDeletedEvent(Guid Id) : IIntegrationEvent;
}
