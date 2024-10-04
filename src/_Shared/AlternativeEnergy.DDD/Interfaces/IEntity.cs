namespace AlternativeEnergy.DDD.Interfaces
{
    public interface IEntity : IEntity<Guid>, IHasDomainEvents { }

    public interface IEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}
