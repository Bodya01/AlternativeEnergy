using AlternativeEnergy.Identity.Application;
using AlternativeEnergy.Identity.Infrastructure.EF.DbModels;
using AlternativeEnergy.Identity.Infrastructure.Extensions;
using AlternativeEnergy.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

namespace AlternativeEnergy.Identity.API.Extensions
{
    public static class Extensions
    {
        public static IMvcBuilder UseIdentityApi(this IMvcBuilder builder)
        {
            builder.AddApplicationPart(Assembly.GetExecutingAssembly());
            return builder;
        }

        public static IApplicationBuilder UseIdentityServerMiddleware(this IApplicationBuilder app)
        {
            app.UseIdentityServer();

            return app;
        }

        public static IServiceCollection AddIdentityApi(this IServiceCollection services, ApplicationConfigs configs)
        {
            services
                .RegisterDbContext(configs)
                .RegisterIdentity()
                .ConfigureAuthentication(configs)
                //.AddDuendeIdentityServer(configs) //should go after identity registration
                .RegisterRepositories()
                .AddIdentityApplicationServices()
                .AddIdentityCommandHandlers();

            services.AddSingleton(GetValidationParameters(configs));

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


        public static IServiceCollection AddDuendeIdentityServer(this IServiceCollection services, ApplicationConfigs configs)
        {

            services.RegisterIdentity();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.Authority = "https://localhost:7282/";
                    options.Audience = "aeAPI";
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateAudience = true,
                        ValidateIssuer = true,
                        ValidIssuer = "https://localhost:7282/",
                        ValidAudience = "aeAPI"
                    };
                });

            services.AddIdentityServer(o =>
            {
                o.Events.RaiseErrorEvents = true;
                o.Events.RaiseInformationEvents = true;
                o.Events.RaiseFailureEvents = true;
                o.Events.RaiseSuccessEvents = true;

                //o.EmitStaticAudienceClaim = true;
            })
                .AddAspNetIdentity<AppUser>()
                .AddInMemoryIdentityResources(AuthConfig.IdentityResources)
                .AddInMemoryApiResources(AuthConfig.ApiResources)
                .AddInMemoryApiScopes(AuthConfig.ApiScopes)
                .AddInMemoryClients(AuthConfig.Clients);

            return services;
        }
    }
}
