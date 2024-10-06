﻿namespace AlternativeEnergy.DDD.Interfaces
{
    public interface IEntity : IEntity<Guid>;

    public interface IEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}
