using AlternativeEnergy.Identity.Domain.Entities;
using AlternativeEnergy.Identity.Infrastructure.Maps;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AlternativeEnergy.Identity.Infrastructure.Context
{
    public sealed class IdentityModuleContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
    {
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public IdentityModuleContext(DbContextOptions<IdentityModuleContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("identity");
            builder.ApplyConfiguration(new RefreshTokenMap());

            base.OnModelCreating(builder);
        }
    }
}