using AlternativeEnergy.Regions.Domain.Entities;

namespace AlternativeEnergy.Regions.Domain.Repositories
{
    public interface IRegionRepository
    {
        Task<Region> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<Region>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<IQueryable<Region>> GetQueryAsync(CancellationToken cancellationToken = default);
        Task<Guid> CreateAsync(string name, CancellationToken cancellationToken = default);
        Task UpdateAsync(Guid id, string name, CancellationToken cancellationToken = default);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
