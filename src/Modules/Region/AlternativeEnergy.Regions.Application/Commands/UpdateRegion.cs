using AlternativeEnergy.CQRS;

namespace AlternativeEnergy.Regions.Application.Commands
{
    public sealed record UpdateRegion(Guid Id, string Name) : IRequest;
}
