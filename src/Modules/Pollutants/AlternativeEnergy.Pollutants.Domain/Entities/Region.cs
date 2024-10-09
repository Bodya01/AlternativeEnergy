using AlternativeEnergy.DDD;

namespace AlternativeEnergy.Pollutants.Domain.Entities
{
    public sealed record Region(Guid Id, string Name) : ValueObject;
}
