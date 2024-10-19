using AlternativeEnergy.Events;
using AlternativeEnergy.Sources.Domain.Repositories;

namespace AlternativeEnergy.Sources.Application.Events.External.Handlers
{
    internal sealed class RegionDeletedEventHandler : IEventHandler<RegionDeletedEvent>
    {
        private readonly IRegionRepository _regionRepository;

        public RegionDeletedEventHandler(IRegionRepository regionRepository)
            => _regionRepository = regionRepository;

        public async Task HandleAsync(RegionDeletedEvent @event, CancellationToken cancellationToken = default)
        {
            if (!await _regionRepository.ExistsAsync(@event.Id, cancellationToken))
                throw new Exception($"Region with Id: {@event.Id} does not exist.");

            await _regionRepository.DeleteAsync(@event.Id, cancellationToken);
        }
    }
}