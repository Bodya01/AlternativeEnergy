using AlternativeEnergy.Identity.Domain.Repositories;
using AlternativeEnergy.Identity.Infrastructure.EF.Context;
using AlternativeEnergy.Identity.Infrastructure.EF.DbModels;
using AlternativeEnergy.Identity.Infrastructure.EF.Repositories;
using AlternativeEnergy.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AlternativeEnergy.Identity.Infrastructure.Extensions
{
    public static class Dependencies
    {
        public static IServiceCollection RegisterDbContext(this IServiceCollection services, ApplicationConfigs configs)
        {
            services.AddDbContext<IdentityModuleContext>(options =>
                options.UseSqlServer(configs.ConnectionStrings.AlternativeEnergy));

            return services;
        }

        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }

        public static IServiceCollection RegisterIdentity(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, IdentityRole<Guid>>()
                .AddEntityFrameworkStores<IdentityModuleContext>()
                .AddUserManager<UserManager<AppUser>>()
                .AddDefaultTokenProviders();

            return services;
        }
    }
}
