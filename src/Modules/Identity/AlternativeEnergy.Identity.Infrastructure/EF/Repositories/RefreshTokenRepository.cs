using AlternativeEnergy.Identity.Domain.Entities;
using AlternativeEnergy.Identity.Domain.Repositories;
using AlternativeEnergy.Identity.Infrastructure.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace AlternativeEnergy.Identity.Infrastructure.EF.Repositories
{
    internal sealed class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly IdentityModuleContext _context;

        public RefreshTokenRepository(IdentityModuleContext context)
            => _context = context;

        public async Task<RefreshToken?> GetByIdAsync(string token, CancellationToken cancellationToken = default) =>
            await _context.RefreshTokens.FirstOrDefaultAsync(x => x.Id == token, cancellationToken);

        public async Task<RefreshToken> CreateAsync(RefreshToken model, CancellationToken cancellationToken = default)
        {
            await _context.AddAsync(model, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return model;
        }

        public async Task<RefreshToken> UpdateAsync(RefreshToken entity, CancellationToken cancellationToken = default)
        {
            await Task.Run(() => _context.Update(entity), cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }
    }
}
