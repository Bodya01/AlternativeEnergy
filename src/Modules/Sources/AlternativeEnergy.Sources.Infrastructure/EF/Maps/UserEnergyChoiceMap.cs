using AlternativeEnergy.Sources.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlternativeEnergy.Sources.Infrastructure.EF.Maps
{
    internal sealed class UserEnergyChoiceMap : IEntityTypeConfiguration<UserEnergyChoice>
    {
        public void Configure(EntityTypeBuilder<UserEnergyChoice> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Consumption).IsRequired();
            builder.Property(x => x.ConsumptionDate).IsRequired();

            builder.Property(x => x.RegionId).IsRequired();
            builder.Property(x => x.UserId).IsRequired();

            builder.HasOne(x => x.Source)
                .WithMany(x => x.EnergyChoices)
                .HasForeignKey(x => x.SourceId)
                .HasPrincipalKey(x => x.Id);

            builder.Ignore(x => x.Events)
                .Ignore(x => x.Version);
        }
    }
}
