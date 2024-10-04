using AlternativeEnergy.Infrastructure;
using AlternativeEnergy.Regions.Domain.Entities;
using AlternativeEnergy.Regions.Infrastructure.EF.Maps;
using Microsoft.EntityFrameworkCore;

namespace AlternativeEnergy.Regions.Infrastructure.EF.Context
{
    internal sealed class RegionsModuleContext : DbContext
    {
        public DbSet<Region> Regions { get; set; }
        public RegionsModuleContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(DbSchemas.Regions);

            modelBuilder.ApplyConfiguration(new RegionMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
