using AlternativeEnergy.CQRS;
using AlternativeEnergy.Messaging;
using AlternativeEnergy.Regions.Application.Events;
using AlternativeEnergy.Regions.Application.Exceptions;
using AlternativeEnergy.Regions.Domain.Repositories;
using System.Net;

namespace AlternativeEnergy.Regions.Application.Commands.Handlers
{
    internal sealed class DeleteRegionHandler : IRequestHandler<DeleteRegion>
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IInMemoryMessageBus _messageBus;

        public DeleteRegionHandler(IRegionRepository regionRepository, IInMemoryMessageBus messageBus)
            => (_regionRepository, _messageBus) = (regionRepository, messageBus);

        public async Task Handle(DeleteRegion request, CancellationToken cancellationToken)
        {
            if (!await _regionRepository.ExistsAsync(request.Id, cancellationToken))
                throw new RegionNotFoundException(HttpStatusCode.BadRequest, $"Region with Id: {request.Id} does not exist.");

            await _regionRepository.DeleteAsync(request.Id, cancellationToken);
            await _messageBus.PublishAsync(new RegionDeletedEvent(request.Id));
        }
    }
}
