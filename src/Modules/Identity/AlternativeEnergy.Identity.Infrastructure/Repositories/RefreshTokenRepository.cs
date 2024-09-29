using AlternativeEnergy.Identity.Domain.Entities;
using AlternativeEnergy.Identity.Domain.Repositories;
using AlternativeEnergy.Identity.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AlternativeEnergy.Identity.Infrastructure.Repositories
{
    internal sealed class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly IdentityModuleContext _context;

        public RefreshTokenRepository(IdentityModuleContext context)
        {
            _context = context;
        }

        public async Task<RefreshToken?> GetByIdAsync(string token, CancellationToken cancellationToken = default) =>
            await _context.RefreshTokens.FirstOrDefaultAsync(x => x.Id == token, cancellationToken);

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
