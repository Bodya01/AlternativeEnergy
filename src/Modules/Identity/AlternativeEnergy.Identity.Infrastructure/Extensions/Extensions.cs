using AlternativeEnergy.Identity.Domain.Entities;
using AlternativeEnergy.Identity.Infrastructure.EF.DbModels;
using Mapster;

namespace AlternativeEnergy.Identity.Infrastructure.Extensions
{
    internal static class Extensions
    {
        public static AppUser AsDbObject(this User user)
            => new AppUser
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                EmailConfirmed = user.EmailConfirmed,
                PasswordHash = user.PasswordHash,
                SecurityStamp = user.SecurityStamp,
                RegionId = user.RegionId,
            };

        public static User AsEntity(this AppUser user)
            => new(user.Id, user.Email, user.UserName, user.EmailConfirmed, user.PasswordHash, user.SecurityStamp, user.RegionId);
    }
}
