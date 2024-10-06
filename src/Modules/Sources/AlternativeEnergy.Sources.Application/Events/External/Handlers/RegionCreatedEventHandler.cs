using AlternativeEnergy.Events;
using AlternativeEnergy.Sources.Domain.Entities;
using AlternativeEnergy.Sources.Domain.Repositories;

namespace AlternativeEnergy.Sources.Application.Events.External.Handlers
{
    internal sealed class RegionCreatedEventHandler : IEventHandler<RegionCreatedEvent>
    {
        private readonly IRegionRepository _regionRepository;

        public RegionCreatedEventHandler(IRegionRepository regionRepository)
            => _regionRepository = regionRepository;

        public async Task HandleAsync(RegionCreatedEvent @event, CancellationToken cancellationToken = default)
        {
            if (await _regionRepository.ExistsAsync(@event.Id, cancellationToken)) throw new Exception("region exists"); //TODO: add an exception type

            var region = new Region(@event.Id, @event.Name);
            await _regionRepository.CreateAsync(region, cancellationToken);
        }
    }
}
