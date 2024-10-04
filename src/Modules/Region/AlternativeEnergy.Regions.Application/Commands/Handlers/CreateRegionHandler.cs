using AlternativeEnergy.Regions.Domain.Repositories;
using MediatR;

namespace AlternativeEnergy.Regions.Application.Commands.Handlers
{
    internal sealed class CreateRegionHandler : IRequestHandler<CreateRegion, Guid>
    {
        private readonly IRegionRepository _regionRepository;

        public CreateRegionHandler(IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;
        }

        public async Task<Guid> Handle(CreateRegion request, CancellationToken cancellationToken)
        {
            return await _regionRepository.CreateAsync(request.Name, cancellationToken);
        }
    }
}
