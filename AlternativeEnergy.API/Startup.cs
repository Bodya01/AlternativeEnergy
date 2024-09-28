using AlternativeEnergy.Identity.API.Extensions;
using AlternativeEnergy.Infrastructure;
using AlternativeEnergy.Sources.API.Extensions;
using Bootstrapper.Extensions;
using Bootstrapper.Middleware;

namespace Bootstrapper
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
            services.AddSwagger();

            services.AddLogging(config =>
            {
                config.AddConsole();
                config.AddDebug();
            });

            var appConfigs = new ApplicationConfigs();
            Configuration.GetSection("ApplicationConfigurations").Bind(appConfigs);
            services.AddSingleton(appConfigs);

            /*-----module registration-----*/
            services.AddIdentityApi(appConfigs)
                .AddSourcesApi();

            services.AddControllers()
                .UseIdentityApi()
                .UseSourcesApi();
            /*-----------------------------*/

            services.AddMvc();

            services.AddHttpContextAccessor();
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
