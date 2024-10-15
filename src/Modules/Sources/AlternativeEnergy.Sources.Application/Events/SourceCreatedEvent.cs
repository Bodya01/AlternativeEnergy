using AlternativeEnergy.Events;

namespace AlternativeEnergy.Sources.Application.Events
{
    internal sealed record SourceCreatedEvent(Guid Id, string Name, string EnergyType, float CO2Emissions) : IEvent;
}
