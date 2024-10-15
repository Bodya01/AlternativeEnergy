using AlternativeEnergy.Pollutants.Domain.Entities;

namespace AlternativeEnergy.Pollutants.Domain.Repositories
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
