using AlternativeEnergy.Pollutants.Domain.Entities;
using AlternativeEnergy.Pollutants.Domain.Repositories;
using AlternativeEnergy.Pollutants.Infrastructure.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace AlternativeEnergy.Pollutants.Infrastructure.EF.Repositories
{
    internal sealed class RegionRepository : IRegionRepository
    {
        private readonly PollutantsModuleContext _context;

        public RegionRepository(PollutantsModuleContext context)
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
