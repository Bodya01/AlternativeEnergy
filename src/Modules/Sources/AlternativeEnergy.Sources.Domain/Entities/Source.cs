using AlternativeEnergy.DDD;
using AlternativeEnergy.Sources.Domain.Enums;
using AlternativeEnergy.Sources.Domain.Events.Source;

namespace AlternativeEnergy.Sources.Domain.Entities
{
    public sealed class Source : Entity
    {
        public string Name { get; private set; } = null!;
        public string Description { get; private set; } = null!;
        public EnergyTypes EnergyType { get; private set; }
        public float CO2Emissions { get; private set; } //general co2 emissions per energy unit (gramm/kW-h) does not depend on regional data for energy source

        public ICollection<UserEnergyChoice> EnergyChoices { get; set; }

        private Source(Guid id, string name, string description, EnergyTypes energyType, float cO2Emissions) : base(id)
        {
            Name = name;
            Description = description;
            EnergyType = energyType;
            CO2Emissions = cO2Emissions;
        }

        public static Source Create(Guid id, string name, string description, EnergyTypes energyType, float cO2Emissions)
        {
            var source = new Source(id, name, description, energyType, cO2Emissions);

            source.AddEvent(new SourceCreatedEvent());

            return source;
        }
    }
}
