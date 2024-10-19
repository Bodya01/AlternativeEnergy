using AlternativeEnergy.Messaging;
using AlternativeEnergy.Regions.Application.Events;
using AlternativeEnergy.Regions.Application.Exceptions;
using AlternativeEnergy.Regions.Domain.Repositories;
using MediatR;
using System.Net;

namespace AlternativeEnergy.Regions.Application.Commands.Handlers
{
    internal sealed class UpdateRegionHandler : IRequestHandler<UpdateRegion>
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IInMemoryMessageBus _messageBus;

        public UpdateRegionHandler(IRegionRepository regionRepository, IInMemoryMessageBus messageBus)
            => (_regionRepository, _messageBus) = (regionRepository, messageBus);

        public async Task Handle(UpdateRegion request, CancellationToken cancellationToken)
        {
            if (!await _regionRepository.ExistsAsync(request.Id, cancellationToken))
                throw new RegionNotFoundException(HttpStatusCode.BadRequest, $"Region with Id: {request.Id} does not exist.");

            await _regionRepository.UpdateAsync(request.Id, request.Name, cancellationToken);
            await _messageBus.PublishAsync(new RegionUpdatedEvent(request.Id, request.Name));
        }
    }
}
