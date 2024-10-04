using MediatR;

namespace AlternativeEnergy.Regions.Application.Commands
{
    public sealed record CreateRegion(string Name) : IRequest<Guid>;
}
