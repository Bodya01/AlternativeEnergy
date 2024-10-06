using AlternativeEnergy.Identity.Domain.Entities;
using AlternativeEnergy.Identity.Infrastructure.EF.DbModels;
using Mapster;

namespace AlternativeEnergy.Identity.Infrastructure.Extensions
{
    internal static class Extensions
    {
        public static AppUser AsDbObject(this User user)
            => user.Adapt<AppUser>();

        public static User AsEntity(this AppUser user)
            => user.Adapt<User>();
    }
}
