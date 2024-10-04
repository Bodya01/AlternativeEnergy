using AlternativeEnergy.Regions.Application.Dtos;
using MediatR;

namespace AlternativeEnergy.Regions.Application.Queries
{
    public sealed record GetAllRegions : IRequest<IEnumerable<RegionDto>>;
}
