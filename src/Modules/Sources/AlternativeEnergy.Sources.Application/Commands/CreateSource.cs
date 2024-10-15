using AlternativeEnergy.Sources.Domain.Enums;
using MediatR;

namespace AlternativeEnergy.Sources.Application.Commands
{
    public sealed record CreateSource(Guid Id, string Name, string Decription, EnergyTypes EnergyType, float CO2Emissions) : IRequest<Guid>;
}
