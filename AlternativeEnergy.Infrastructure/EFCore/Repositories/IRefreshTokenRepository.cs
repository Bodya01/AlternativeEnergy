using AlternativeEnergy.Infrastructure.Identity;

namespace AlternativeEnergy.Infrastructure.EFCore.Repositories
{
    public interface IRefreshTokenRepository
    {
        Task<RefreshToken?> GetByIdAsync(string token, CancellationToken cancellationToken = default);
        Task<RefreshToken> CreateAsync(RefreshToken model, CancellationToken cancellationToken = default);
        Task<RefreshToken> UpdateAsync(RefreshToken model, CancellationToken cancellationToken = default);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
