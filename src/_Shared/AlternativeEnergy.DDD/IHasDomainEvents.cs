namespace AlternativeEnergy.DDD
{
    public interface IHasDomainEvents
    {
        public IReadOnlyList<IDomainEvent> Events { get; }
    }
}
