using AlternativeEnergy.Identity.Application.Services;
using AlternativeEnergy.Identity.Domain.Entities;
using AlternativeEnergy.Identity.Infrastructure;
using AlternativeEnergy.Identity.Infrastructure.Context;
using AlternativeEnergy.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AlternativeEnergy.Identity.Application
{
    public static class Dependencies
    {
        public static IServiceCollection RegisterIdentityDependencies(this IServiceCollection services, ApplicationConfigs configs)
        {
            services.ConfigureAuthentication(configs)
                .RegisterDbContext(configs)
                .RegisterIdentity()
                .RegisterRepositories()
                .RegisterApplicationServices();

            return services;
        }

        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IIdentityService, IdentityService>();

            return services;
        }

        public static IServiceCollection RegisterIdentity(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, IdentityRole<Guid>>()
                .AddEntityFrameworkStores<IdentityModuleContext>()
                .AddDefaultTokenProviders();

            return services;
        }
        public static IServiceCollection ConfigureAuthentication(this IServiceCollection services, ApplicationConfigs configs)
        {
            services.AddSingleton(GetValidationParameters(configs));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = GetValidationParameters(configs);
            });

            return services;
        }

        private static TokenValidationParameters GetValidationParameters(ApplicationConfigs configuration)
        {
            return new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration.JwtSettings.SecretKey)),
                ValidateIssuer = false,
                ValidateAudience = false,
                RequireExpirationTime = false,
                ValidateLifetime = false,
            };
        }
    }
}
