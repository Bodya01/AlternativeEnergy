using AlternativeEnergy.Domain.Entities.Interfaces;

namespace AlternativeEnergy.Domain.Entities
{
    public class Source : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string EnergyType { get; set; } = null!; //should be using EnergyTypes enum
        public float CO2Emissions { get; set; } //general co2 emissions per energy unit (gramm/kW-h) does not depend on regional data for energy source
    }
}
