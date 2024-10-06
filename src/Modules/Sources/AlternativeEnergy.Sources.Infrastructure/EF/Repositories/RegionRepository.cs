using AlternativeEnergy.Sources.Domain.Entities;
using AlternativeEnergy.Sources.Domain.Repositories;
using AlternativeEnergy.Sources.Infrastructure.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace AlternativeEnergy.Sources.Infrastructure.EF.Repositories
{
    internal sealed class RegionRepository : IRegionRepository
    {
        private readonly SourcesModuleContext _context;

        public RegionRepository(SourcesModuleContext context)
            => _context = context;

        public async Task<Region> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
            => await _context.Regions.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        public async Task CreateAsync(Region region, CancellationToken cancellationToken = default)
        {
            await _context.AddAsync(region, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Region region, CancellationToken cancellationToken = default)
        {
            await Task.Run(() => _context.Update(region), cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var entity = await GetByIdAsync(id, cancellationToken);
            await Task.Run(() => _context.Regions.Remove(entity));
            await _context.SaveChangesAsync(cancellationToken);
        }

        public Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default)
            => _context.Regions.AnyAsync(x => x.Id == id, cancellationToken);
    }
}
