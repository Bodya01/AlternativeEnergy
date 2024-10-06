using AlternativeEnergy.Identity.Domain.Entities;
using AlternativeEnergy.Identity.Domain.Repositories;
using AlternativeEnergy.Identity.Infrastructure.EF.Context;
using AlternativeEnergy.Identity.Infrastructure.EF.DbModels;
using AlternativeEnergy.Identity.Infrastructure.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AlternativeEnergy.Identity.Infrastructure.EF.Repositories
{
    internal sealed class UserRepository : IUserRepository
    {
        private readonly IdentityModuleContext _context;
        private readonly UserManager<AppUser> _userManager;

        public UserRepository(IdentityModuleContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

#pragma warning disable CS8604 // Possible null reference argument.
        public async Task<User> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
            => (await _context.Users.FirstOrDefaultAsync(x => x.Id == id, cancellationToken)).AsEntity();

        public async Task<User> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
            => (await _context.Users.FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower(), cancellationToken)).AsEntity();
#pragma warning restore CS8604 // Possible null reference argument.

        public async Task<Guid> CreateAsync(User user, CancellationToken cancellationToken = default)
        {
            var entity = user.AsDbObject();

            await _userManager.CreateAsync(entity);

            return entity.Id;
        }

        public async Task UpdateAsync(User user, CancellationToken cancellationToken = default)
        {
            await Task.Run(() => _context.Update(user), cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var user = await GetByIdAsync(id, cancellationToken);

            await _userManager.DeleteAsync(user.AsDbObject());
        }

        public async Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default)
            => await _context.Users.AnyAsync(x => x.Id == id, cancellationToken);

        public async Task<bool> ValidatePassword(Guid id, string password, CancellationToken cancellationToken = default)
        {
            var user = await GetByIdAsync(id, cancellationToken);
            return await _userManager.CheckPasswordAsync(user.AsDbObject(), password);
        }
    }
}
