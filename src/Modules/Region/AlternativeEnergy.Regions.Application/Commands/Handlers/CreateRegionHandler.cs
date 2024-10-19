using AlternativeEnergy.Messaging;
using AlternativeEnergy.Regions.Application.Events;
using AlternativeEnergy.Regions.Application.Exceptions;
using AlternativeEnergy.Regions.Domain.Repositories;
using MediatR;
using System.Net;

namespace AlternativeEnergy.Regions.Application.Commands.Handlers
{
    internal sealed class CreateRegionHandler : IRequestHandler<CreateRegion, Guid>
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IInMemoryMessageBus _messageBus;

        public CreateRegionHandler(IRegionRepository regionRepository, IInMemoryMessageBus eventBus)
            => (_regionRepository, _messageBus) = (regionRepository, eventBus);

        public async Task<Guid> Handle(CreateRegion request, CancellationToken cancellationToken)
        {
            if (await _regionRepository.ExistsAsync(request.Name, cancellationToken))
                throw new RegionAlreadyExistsException(HttpStatusCode.BadRequest, $"Region with name: {request.Name} already exists.");

            var regionId = await _regionRepository.CreateAsync(request.Name, cancellationToken);
            await _messageBus.PublishAsync(new RegionCreatedEvent(regionId, request.Name));

            return regionId;
        }
    }
}