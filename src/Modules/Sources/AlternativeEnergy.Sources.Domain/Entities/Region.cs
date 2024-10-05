using AlternativeEnergy.DDD;

namespace AlternativeEnergy.Sources.Domain.Entities
{
    public sealed record Region : ValueObject
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public Region(string name)
        {
            Name = name;
        }

        public void Update(string name)
        {
            Name = name;
        }
    }
}
