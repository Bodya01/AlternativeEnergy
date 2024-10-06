using AlternativeEnergy.DDD;
using AlternativeEnergy.Identity.Domain.Events;

namespace AlternativeEnergy.Identity.Domain.Entities
{
    public sealed class User : Entity, IAggregateRoot
    {
        public string UserName { get; private set; }
        public string Email { get; private set; }
        public bool EmailConfirmed { get; private set; }
        public string PasswordHash { get; private set; } = null!;
        public string? SecurityStamp { get; private set; }
        public Guid RegionId { get; private set; }

        private User(Guid id, string email, string userName, Guid regionId) : base(id)
        {
            Email = email;
            UserName = userName;
            RegionId = regionId;
        }

        /// <summary>
        /// Mapping purposes only
        /// </summary>
        /// <param name="id"></param>
        /// <param name="email"></param>
        /// <param name="userName"></param>
        /// <param name="emailConfirmed"></param>
        /// <param name="passwordHash"></param>
        /// <param name="securityStamp"></param>
        /// <param name="regionId"></param>
        public User(Guid id, string email, string userName, bool emailConfirmed, string passwordHash, string? securityStamp, Guid regionId) : base(id)
        {
            Email = email;
            UserName = userName;
            RegionId = regionId;
            EmailConfirmed = emailConfirmed;
            PasswordHash = passwordHash;
            SecurityStamp = securityStamp;
        }

        public static User Create(Guid id, string email, string userName, Guid regionId)
        {
            var user = new User(id, email, userName, regionId);
            user.AddEvent(new UserCreateDomainEvent());

            return user;
        }
    }
}
