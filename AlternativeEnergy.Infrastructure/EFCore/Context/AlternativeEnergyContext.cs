using AlternativeEnergy.Domain.Entities;
using AlternativeEnergy.Infrastructure.EFCore.Maps;
using AlternativeEnergy.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AlternativeEnergy.Infrastructure.EFCore.Context
{
    public sealed class AlternativeEnergyContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
    {
        public DbSet<Co2Emissions> Emissions { get; set; }
        public DbSet<Footprints> Footprints { get; set; }
        public DbSet<Source> Sources { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<UserEnergyChoice> UserEnergyChoices { get; set; }
        public DbSet<Infrastructure.Identity.RefreshToken> RefreshTokens { get; set; }

        public AlternativeEnergyContext(DbContextOptions<AlternativeEnergyContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RefreshTokenMap());
        }
    }
}