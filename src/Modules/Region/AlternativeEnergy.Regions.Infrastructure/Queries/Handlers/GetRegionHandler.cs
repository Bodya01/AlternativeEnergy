using AlternativeEnergy.Regions.Application.Dtos;
using AlternativeEnergy.Regions.Application.Queries;
using AlternativeEnergy.Regions.Domain.Repositories;
using AlternativeEnergy.Regions.Domain.Exceptions;
using MediatR;
using Mapster;

namespace AlternativeEnergy.Regions.Infrastructure.Queries.Handlers
{
    internal sealed class GetRegionHandler : IRequestHandler<GetRegion, RegionDto>
    {
        private readonly IRegionRepository _regionRepository;

        public GetRegionHandler(IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;
        }

        public async Task<RegionDto> Handle(GetRegion request, CancellationToken cancellationToken)
        {
            var entity = await _regionRepository.GetByIdAsync(request.Id, cancellationToken);

            if (entity is null) throw new RegionNotFoundException();

            return entity.Adapt<RegionDto>();
        }
    }
}
