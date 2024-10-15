using AlternativeEnergy.Infrastructure.Extensions;
using AlternativeEnergy.Pollutants.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlternativeEnergy.Pollutants.Infrastructure.EF.Maps
{
    internal sealed class WasteMap : IEntityTypeConfiguration<Waste>
    {
        public void Configure(EntityTypeBuilder<Waste> builder)
        {
            builder.ToTable("Wastes");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.WasteType).IsRequired();
            builder.Property(x => x.Produced).IsRequired();
            builder.Property(x => x.CollectionTime).IsRequired();

            builder.HasOne(x => x.Region)
                .WithMany()
                .HasForeignKey(x => x.RegionId)
                .HasPrincipalKey(x => x.Id);

            builder.IgnoreEntityProperties();
        }
    }
}
