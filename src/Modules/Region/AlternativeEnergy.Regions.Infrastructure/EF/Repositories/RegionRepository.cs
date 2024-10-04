using AlternativeEnergy.Regions.Domain.Entities;
using AlternativeEnergy.Regions.Domain.Repositories;
using AlternativeEnergy.Regions.Infrastructure.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace AlternativeEnergy.Regions.Infrastructure.EF.Repositories
{
    internal sealed class RegionRepository : IRegionRepository
    {
        private readonly RegionsModuleContext _context;

        public RegionRepository(RegionsModuleContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<Region>> GetQueryAsync(CancellationToken cancellationToken = default) =>
            await Task.Run(() => _context.Regions, cancellationToken);

        public async Task<IEnumerable<Region>> GetAllAsync(CancellationToken cancellationToken = default) =>
            await _context.Regions.ToListAsync(cancellationToken);

        public async Task<Region> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
            await _context.Regions.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        public async Task<Guid> CreateAsync(string name, CancellationToken cancellationToken = default)
        {
            var region = Region.Create(Guid.NewGuid(), name);

            await _context.AddAsync(region, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return region.Id;
        }

        public async Task UpdateAsync(Guid id, string name, CancellationToken cancellationToken = default)
        {
            var entity = await GetByIdAsync(id, cancellationToken);

            entity.Update(name);

            await Task.Run(() => _context.Update(entity), cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var entity = await GetByIdAsync(id, cancellationToken);

            await Task.Run(() => _context.Remove(entity), cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
