using AlternativeEnergy.Infrastructure.EFCore.Context;
using AlternativeEnergy.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;

namespace AlternativeEnergy.Infrastructure.EFCore.Repositories
{
    internal sealed class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly AlternativeEnergyContext _context;

        public RefreshTokenRepository(AlternativeEnergyContext context)
        {
            _context = context;
        }

        public async Task<RefreshToken?> GetByIdAsync(string token, CancellationToken cancellationToken = default) =>
            await _context.RefreshTokens.FirstOrDefaultAsync(x => x.Token == token, cancellationToken);

        public async Task<RefreshToken> CreateAsync(RefreshToken model, CancellationToken cancellationToken = default)
        {
            await _context.AddAsync(model, cancellationToken);
            return model;
        }

        public async Task<RefreshToken> UpdateAsync(RefreshToken entity, CancellationToken cancellationToken = default)
        {
            await Task.Run(() => _context.Update(entity), cancellationToken);
            return entity;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
            await _context.SaveChangesAsync(cancellationToken);
    }
}
