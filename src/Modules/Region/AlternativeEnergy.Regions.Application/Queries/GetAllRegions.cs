using AlternativeEnergy.CQRS;
using AlternativeEnergy.Regions.Application.Dtos;

namespace AlternativeEnergy.Regions.Application.Queries
{
    public sealed record GetAllRegions : IRequest<IEnumerable<RegionDto>>;
}
