using AlternativeEnergy.Infrastructure.Extensions;
using AlternativeEnergy.Pollutants.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlternativeEnergy.Pollutants.Infrastructure.EF.Maps
{
    internal sealed class CarbonMap : IEntityTypeConfiguration<Carbon>
    {
        public void Configure(EntityTypeBuilder<Carbon> builder)
        {
            builder.ToTable("CarbonEmissions");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.EmissionsPerUnit).IsRequired();

            builder.HasOne(x => x.Region)
                .WithMany()
                .HasForeignKey(x => x.RegionId)
                .HasPrincipalKey(x => x.Id);

            builder.IgnoreEntityProperties();
        }
    }
}
