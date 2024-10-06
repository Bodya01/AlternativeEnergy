using AlternativeEnergy.Sources.Domain.Entities;

namespace AlternativeEnergy.Sources.Domain.Repositories
{
    public interface IRegionRepository
    {
        Task<Region> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task CreateAsync(Region region, CancellationToken cancellationToken = default);
        Task UpdateAsync(Region region, CancellationToken cancellationToken = default);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
