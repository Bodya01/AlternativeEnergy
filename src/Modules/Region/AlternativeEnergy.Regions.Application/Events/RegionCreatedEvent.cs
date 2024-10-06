﻿using AlternativeEnergy.Events;

namespace AlternativeEnergy.Regions.Application.Events
{
    public sealed record RegionCreatedEvent(Guid Id, string Name) : IEvent;
}
