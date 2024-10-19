using AlternativeEnergy.Bootstrapper.Extensions;
using AlternativeEnergy.Infrastructure;
using AlternativeEnergy.Messaging.Extensions;
using Bootstrapper.Middlewares;

namespace Bootstrapper
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddSwagger()
                .AddLogging()
                .AddApplicationConfigsObject(Configuration, out ApplicationConfigs configs)
                .AddApplicationModules(configs)
                .AddInMemoryMessaging()
                .AddHttpContextAccessor()
                .AddAlternativeEnergyCORSPolicy();

            services.AddMvc();
        }

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

            app.UseCors("AlternativeEnergyPolicy");

            app.UseAuthentication();
            app.UseAuthorization();

            //app.UseIdentityServer();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
