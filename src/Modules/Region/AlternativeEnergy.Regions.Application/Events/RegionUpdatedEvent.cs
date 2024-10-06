﻿using AlternativeEnergy.DDD;

namespace AlternativeEnergy.Regions.Application.Events
{
    internal sealed record RegionUpdatedEvent(Guid Id, string Name) : IIntegrationEvent;
}
