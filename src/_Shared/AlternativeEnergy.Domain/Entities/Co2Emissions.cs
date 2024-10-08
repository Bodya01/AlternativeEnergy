﻿using AlternativeEnergy.DDD;

namespace AlternativeEnergy.Domain.Entities
{
    public class Co2Emissions : Entity
    {
        public float EmissionsPerUnit { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Guid SourceId { get; set; }
        public Guid RegionId { get; set; }
    }
}