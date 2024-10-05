using AlternativeEnergy.Sources.Domain.Entities;
using AlternativeEnergy.Sources.Domain.Repositories;
using AlternativeEnergy.Sources.Infrastructure.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace AlternativeEnergy.Sources.Infrastructure.EF.Repositories
{
    internal sealed class SourceRepository : ISourceRepository
    {
        private readonly SourcesModuleContext _context;

        public SourceRepository(SourcesModuleContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<Source>> GetAllQueryAsync(CancellationToken cancellationToken = default) =>
            await Task.Run(_context.Sources.AsQueryable, cancellationToken);

        public async Task<IEnumerable<Source>> GetAllAsync(CancellationToken cancellationToken = default) =>
            await _context.Sources.ToListAsync(cancellationToken);

        public async Task<Source> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
            await _context.Sources.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        public async Task<IEnumerable<Source>> GetRangeAsync(IEnumerable<Guid> TKey, CancellationToken cancellationToken = default) =>
            await _context.Sources
                .Where(x => TKey.Contains(x.Id))
                .ToListAsync(cancellationToken);

        public async Task CreateAsync(Source entity, CancellationToken cancellationToken = default) =>
            await _context.AddAsync(entity, cancellationToken);

        public async Task UpdateAsync(Source entity, CancellationToken cancellationToken = default) =>
            await Task.Run(() => _context.Update(entity), cancellationToken);

        public async Task UpdateRangeAsync(IEnumerable<Source> entities, CancellationToken cancellationToken = default)
        {
            foreach (var entity in entities) await UpdateAsync(entity, cancellationToken);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default) =>
            await Task.Run(() => _context.Remove(id), cancellationToken);

        public async Task DeleteRangeAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default)
        {
            foreach (var id in ids) await DeleteAsync(id, cancellationToken);
        }

        public async Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default) =>
            await GetByIdAsync(id, cancellationToken) is not null;

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
            await _context.SaveChangesAsync(cancellationToken);
    }
}
