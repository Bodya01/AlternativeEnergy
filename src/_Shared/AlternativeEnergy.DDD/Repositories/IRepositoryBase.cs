using AlternativeEnergy.DDD.Interfaces;

namespace AlternativeEnergy.DDD.Repositories
{
    public interface IRepositoryBase<T, TKey> where T : IEntity<TKey>
    {
        Task<IQueryable<T>> GetAllQueryAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<T> GetByIdAsync(TKey id, CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> GetRangeAsync(IEnumerable<Guid> TKey, CancellationToken cancellationToken = default);
        Task CreateAsync(T entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
        Task UpdateRangeAsync(IEnumerable<T> entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(TKey id, CancellationToken cancellationToken = default);
        Task DeleteRangeAsync(IEnumerable<TKey> ids, CancellationToken cancellationToken = default);
        Task<bool> ExistsAsync(TKey id, CancellationToken cancellationToken = default);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}