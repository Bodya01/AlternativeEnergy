using AlternativeEnergy.Sources.Domain.Enums;

namespace AlternativeEnergy.Sources.Application.Dtos
{
    public sealed record SourceDto(Guid Id, string Name, string Decription, EnergyTypes EnergyType, float CO2Emissions);
}
