using AlternativeEnergy.Regions.Domain.Repositories;
using MediatR;

namespace AlternativeEnergy.Regions.Application.Commands.Handlers
{
    internal sealed class UpdateRegionHandler : IRequestHandler<UpdateRegion>
    {
        private readonly IRegionRepository _regionRepository;

        public UpdateRegionHandler(IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;
        }

        public async Task Handle(UpdateRegion request, CancellationToken cancellationToken)
        {
            await _regionRepository.UpdateAsync(request.Id, request.Name, cancellationToken);
        }
    }
}
