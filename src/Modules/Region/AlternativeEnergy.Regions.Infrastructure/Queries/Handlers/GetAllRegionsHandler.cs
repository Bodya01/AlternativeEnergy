using AlternativeEnergy.Regions.Application.Dtos;
using AlternativeEnergy.Regions.Application.Queries;
using AlternativeEnergy.Regions.Domain.Repositories;
using Mapster;
using MediatR;

namespace AlternativeEnergy.Regions.Infrastructure.Queries.Handlers
{
    internal sealed class GetAllRegionsHandler : IRequestHandler<GetAllRegions, IEnumerable<RegionDto>>
    {
        private readonly IRegionRepository _regionRepository;

        public GetAllRegionsHandler(IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;
        }

        public async Task<IEnumerable<RegionDto>> Handle(GetAllRegions request, CancellationToken cancellationToken)
        {
            var entities = await _regionRepository.GetAllAsync(cancellationToken);

            return entities.Adapt<IEnumerable<RegionDto>>();
        }
    }
}
