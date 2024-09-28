using AlternativeEnergy.Domain.Entities.Interfaces;

namespace AlternativeEnergy.Domain.Entities
{
    public class Region : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;

        //public float Latitude { get; set; }
        //public float Longtitude { get; set; }
    }
}
