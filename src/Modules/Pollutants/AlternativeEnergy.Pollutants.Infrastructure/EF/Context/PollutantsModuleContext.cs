using AlternativeEnergy.Infrastructure;
using AlternativeEnergy.Pollutants.Domain.Entities;
using AlternativeEnergy.Pollutants.Infrastructure.EF.Maps;
using Microsoft.EntityFrameworkCore;

namespace AlternativeEnergy.Pollutants.Infrastructure.EF.Context
{
    internal sealed class PollutantsModuleContext : DbContext
    {
        public DbSet<Region> Regions { get; set; }
        public DbSet<Carbon> CarbonEmissions { get; set; }
        public DbSet<Transport> Transport { get; set; }
        public DbSet<TransportEmission> TransportEmissions { get; set; }
        public DbSet<Waste> Wastes { get; set; }
        public DbSet<Water> WaterEmissions { get; set; }
        public DbSet<Source> Sources { get; set; }

        public PollutantsModuleContext(DbContextOptions<PollutantsModuleContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(DbSchemas.Pollutants);

            modelBuilder.ApplyConfiguration(new RegionMap());
            modelBuilder.ApplyConfiguration(new CarbonMap());
            modelBuilder.ApplyConfiguration(new TransportMap());
            modelBuilder.ApplyConfiguration(new TransportEmissionMap());
            modelBuilder.ApplyConfiguration(new WasteMap());
            modelBuilder.ApplyConfiguration(new WaterMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
