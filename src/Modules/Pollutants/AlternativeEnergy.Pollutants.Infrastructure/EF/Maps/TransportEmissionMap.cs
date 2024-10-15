using AlternativeEnergy.Infrastructure.Extensions;
using AlternativeEnergy.Pollutants.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlternativeEnergy.Pollutants.Infrastructure.EF.Maps
{
    internal sealed class TransportEmissionMap : IEntityTypeConfiguration<TransportEmission>
    {
        public void Configure(EntityTypeBuilder<TransportEmission> builder)
        {
            builder.ToTable("TransportEmissions");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.Distance).IsRequired();
            builder.Property(x => x.ConsumedFuel).IsRequired();
            builder.Property(x => x.UsageDate).IsRequired();

            builder.HasOne(x => x.Transport)
                .WithMany()
                .HasForeignKey(x => x.TransportId)
                .HasPrincipalKey(x => x.Id);

            builder.IgnoreEntityProperties();
        }
    }
}
