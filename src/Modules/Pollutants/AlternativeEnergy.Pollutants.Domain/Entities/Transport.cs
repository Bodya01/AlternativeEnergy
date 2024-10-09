using AlternativeEnergy.DDD;

namespace AlternativeEnergy.Pollutants.Domain.Entities
{
    public record Transport(Guid Id, string Type, string FuelType, float CarbonPerUnit) : ValueObject;
}
