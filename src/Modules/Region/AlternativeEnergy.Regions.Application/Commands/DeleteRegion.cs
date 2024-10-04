using MediatR;

namespace AlternativeEnergy.Regions.Application.Commands
{
    public sealed record DeleteRegion(Guid Id) : IRequest;
}
