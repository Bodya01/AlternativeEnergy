using AlternativeEnergy.Regions.Application.Dtos;
using MediatR;

namespace AlternativeEnergy.Regions.Application.Queries
{
    public sealed record GetRegion(Guid Id) : IRequest<RegionDto>;
}
