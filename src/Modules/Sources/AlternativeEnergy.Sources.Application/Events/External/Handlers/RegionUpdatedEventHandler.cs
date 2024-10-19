using AlternativeEnergy.Events;
using AlternativeEnergy.Sources.Domain.Entities;
using AlternativeEnergy.Sources.Domain.Repositories;

namespace AlternativeEnergy.Sources.Application.Events.External.Handlers
{
    internal sealed class RegionUpdatedEventHandler : IEventHandler<RegionUpdatedEvent>
    {
        private readonly IRegionRepository _regionRepository;

        public RegionUpdatedEventHandler(IRegionRepository regionRepository)
            => _regionRepository = regionRepository;

        public async Task HandleAsync(RegionUpdatedEvent @event, CancellationToken cancellationToken = default)
        {
            if (!await _regionRepository.ExistsAsync(@event.Id, cancellationToken)) throw new Exception($"Region with id {@event.Id} does not exist.");

            var region = new Region(@event.Id, @event.Name);
            await _regionRepository.UpdateAsync(region, cancellationToken);
        }
    }
}
