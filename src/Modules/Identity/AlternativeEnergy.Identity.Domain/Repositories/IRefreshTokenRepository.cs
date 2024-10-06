using AlternativeEnergy.Identity.Domain.Entities;

namespace AlternativeEnergy.Identity.Domain.Repositories
{
    public interface IRefreshTokenRepository
    {
        Task<RefreshToken?> GetByIdAsync(string token, CancellationToken cancellationToken = default);
        Task<RefreshToken> CreateAsync(RefreshToken model, CancellationToken cancellationToken = default);
        Task<RefreshToken> UpdateAsync(RefreshToken model, CancellationToken cancellationToken = default);
    }
}
