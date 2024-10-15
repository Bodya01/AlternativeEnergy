using AlternativeEnergy.DDD;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlternativeEnergy.Infrastructure.Extensions
{
    public static class Extensions
    {
        public static EntityTypeBuilder<T> IgnoreEntityProperties<T>(this EntityTypeBuilder<T> builder) where T : Entity
            => builder
                .Ignore(x => x.Version)
                .Ignore(x => x.Events);
    }
}
