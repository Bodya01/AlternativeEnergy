using AlternativeEnergy.DDD;

namespace AlternativeEnergy.Pollutants.Domain.Entities
{
    public sealed record Source(Guid Id, string Name, string EnergyType, float CO2Emissions) : ValueObject;
}