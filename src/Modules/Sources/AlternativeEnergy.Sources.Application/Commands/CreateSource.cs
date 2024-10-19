using AlternativeEnergy.CQRS;
using AlternativeEnergy.Sources.Domain.Enums;

namespace AlternativeEnergy.Sources.Application.Commands
{
    public sealed record CreateSource(Guid Id, string Name, string Decription, EnergyTypes EnergyType, float CO2Emissions) : IRequest<Guid>;
}
