using AlternativeEnergy.Messaging;
using AlternativeEnergy.Regions.Application.Events;
using AlternativeEnergy.Regions.Domain.Repositories;
using MediatR;

namespace AlternativeEnergy.Regions.Application.Commands.Handlers
{
    internal sealed class CreateRegionHandler : IRequestHandler<CreateRegion, Guid>
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IInMemoryMessageBus _messageBus;

        public CreateRegionHandler(IRegionRepository regionRepository, IInMemoryMessageBus eventBus)
        {
            _regionRepository = regionRepository;
            _messageBus = eventBus;
        }

        public async Task<Guid> Handle(CreateRegion request, CancellationToken cancellationToken)
        {
            var regionId = await _regionRepository.CreateAsync(request.Name, cancellationToken);
            await _messageBus.PublishAsync(new RegionCreatedEvent(regionId, request.Name));

            return regionId;
        }
    }
}
