using AlternativeEnergy.Pollutants.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlternativeEnergy.Pollutants.Infrastructure.EF.Maps
{
    internal sealed class TransportMap : IEntityTypeConfiguration<Transport>
    {
        public void Configure(EntityTypeBuilder<Transport> builder)
        {
            builder.ToTable("Transport");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.FuelType).IsRequired();
            builder.Property(x => x.CarbonPerUnit).IsRequired();
            builder.Property(x => x.Type).IsRequired();
        }
    }
}
