using AlternativeEnergy.CQRS;

namespace AlternativeEnergy.Regions.Application.Commands
{
    public sealed record DeleteRegion(Guid Id) : IRequest;
}
