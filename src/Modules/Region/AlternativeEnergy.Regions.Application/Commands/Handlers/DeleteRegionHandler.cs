using AlternativeEnergy.Regions.Domain.Repositories;
using MediatR;

namespace AlternativeEnergy.Regions.Application.Commands.Handlers
{
    internal sealed class DeleteRegionHandler : IRequestHandler<DeleteRegion>
    {
        private readonly IRegionRepository _regionRepository;

        public DeleteRegionHandler(IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;
        }

        public async Task Handle(DeleteRegion request, CancellationToken cancellationToken)
        {
            await _regionRepository.DeleteAsync(request.Id, cancellationToken);
        }
    }
}
