﻿using AlternativeEnergy.Events;
using AlternativeEnergy.Pollutants.Application.Exception.Region;
using AlternativeEnergy.Pollutants.Domain.Entities;
using AlternativeEnergy.Pollutants.Domain.Repositories;
using System.Net;

namespace AlternativeEnergy.Pollutants.Application.Events.External.Handlers
{
    internal sealed class RegionCreatedEventHandler : IEventHandler<RegionCreatedEvent>
    {
        private readonly IRegionRepository _regionRepository;

        public RegionCreatedEventHandler(IRegionRepository regionRepository)
            => _regionRepository = regionRepository;

        public async Task HandleAsync(RegionCreatedEvent @event, CancellationToken cancellationToken = default)
        {
            if (await _regionRepository.ExistsAsync(@event.Id, cancellationToken))
                throw new RegionAlreadyExistsException(HttpStatusCode.BadRequest, $"Region with Id: {@event.Id} already exists");

            var region = new Region(@event.Id, @event.Name);
            await _regionRepository.CreateAsync(region, cancellationToken);
        }
    }
}
