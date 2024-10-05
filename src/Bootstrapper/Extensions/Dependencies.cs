using AlternativeEnergy.Identity.API.Extensions;
using AlternativeEnergy.Infrastructure;
using AlternativeEnergy.Regions.API;
using AlternativeEnergy.Sources.API.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

namespace Bootstrapper.Extensions
{
    internal static class Dependencies
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AlternativeEnergy", Version = "v1" });

                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "JWT Authentication",
                    Description = "Enter JWT Bearer token **_only_**",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme,
                    },
                };

                c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { securityScheme, Array.Empty<string>() },
                });
            });

            return services;
        }

        public static IServiceCollection AddApplicationModules(this IServiceCollection services, ApplicationConfigs configs)
        {
            services.AddIdentityApi(configs)
                .AddSourcesApi(configs)
                .AddRegionsApi(configs);

            services.AddControllers()
                .UseIdentityApi()
                .UseSourcesApi()
                .UseRegionsApi();

            return services;
        }

        public static ApplicationConfigs AddApplicationConfigsObject(this IServiceCollection services, IConfiguration configuration)
        {
            var configs = new ApplicationConfigs();
            configuration.GetSection("ApplicationConfigurations").Bind(configs);
            services.AddSingleton(configs);

            return configs;
        }
    }
}