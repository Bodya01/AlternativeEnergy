using AlternativeEnergy.DDD;

namespace AlternativeEnergy.Sources.Domain.Entities
{
    public sealed record Region : ValueObject
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public Region(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public void Update(string name) => Name = name;
    }
}
