using AlternativeEnergy.Infrastructure.Extensions;
using AlternativeEnergy.Pollutants.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlternativeEnergy.Pollutants.Infrastructure.EF.Maps
{
    internal sealed class WaterMap : IEntityTypeConfiguration<Water>
    {
        public void Configure(EntityTypeBuilder<Water> builder)
        {
            builder.ToTable("WaterEmissions");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.ConsumptionDate).IsRequired();
            builder.Property(x => x.Used).IsRequired();

            builder.IgnoreEntityProperties();
        }
    }
}
