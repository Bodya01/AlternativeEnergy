using AlternativeEnergy.Infrastructure;
using AlternativeEnergy.Sources.Domain.Entities;
using AlternativeEnergy.Sources.Infrastructure.EF.Maps;
using Microsoft.EntityFrameworkCore;

namespace AlternativeEnergy.Sources.Infrastructure.EF.Context
{
    internal sealed class SourcesModuleContext : DbContext
    {
        public DbSet<Region> Regions { get; set; }
        public DbSet<Source> Sources { get; set; }
        public DbSet<UserEnergyChoice> UserEnergyChoices { get; set; }

        public SourcesModuleContext(DbContextOptions<SourcesModuleContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(DbSchemas.Sources);

            modelBuilder.ApplyConfiguration(new RegionMap());
            modelBuilder.ApplyConfiguration(new SourceMap());
            modelBuilder.ApplyConfiguration(new UserEnergyChoiceMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
