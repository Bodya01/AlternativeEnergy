using AlternativeEnergy.API.Extensions;
using AlternativeEnergy.API.Middleware;
using AlternativeEnergy.Application;
using AlternativeEnergy.Infrastructure;
using AlternativeEnergy.Infrastructure.EFCore.Context;
using AlternativeEnergy.Infrastructure.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace AlternativeEnergy.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(config =>
            {
                config.AddConsole();
                config.AddDebug();
            });

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

            services.AddControllers();
            services.AddMvc();

            services.AddHttpContextAccessor();

            var appConfigs = new ApplicationConfigs();
            Configuration.GetSection("ApplicationConfigurations").Bind(appConfigs);
            services.AddSingleton(appConfigs);

            services.ConfigureAuthentication(appConfigs);

            services.AddDbContext<AlternativeEnergyContext>(options =>
                options.UseSqlServer(appConfigs.ConnectionStrings.AlternativeEnergy));
            services.AddIdentity<AppUser, IdentityRole<Guid>>()
                .AddEntityFrameworkStores<AlternativeEnergyContext>()
                .AddDefaultTokenProviders();

            services.RegisterRepositories()
                .RegisterApplicationServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            app.UseMiddleware<ExceptionHandlingMiddleware>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseForwardedHeaders();

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "AlternativeEnergy");
                c.DefaultModelsExpandDepth(-1);
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Log that the application has started
            logger.LogInformation("Application has started successfully.");
        }
    }
}
