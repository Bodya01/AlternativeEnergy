using AlternativeEnergy.Sources.Domain.Entities;
using AlternativeEnergy.Sources.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlternativeEnergy.Sources.Infrastructure.EF.Maps
{
    internal sealed class SourceMap : IEntityTypeConfiguration<Source>
    {
        public void Configure(EntityTypeBuilder<Source> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.Name).IsRequired();

            builder.Property(x => x.EnergyType).IsRequired()
                .HasConversion(
                v => v.ToString(),
                v => Enum.Parse<EnergyTypes>(v)
                );

            builder.Property(x => x.CO2Emissions).IsRequired();


            builder.Ignore(x => x.Events)
                .Ignore(x => x.Version);
        }
    }
}
