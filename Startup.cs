
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SensoryTask.Models;
using SensoryTask.Models.DataManager;
using SensoryTask.Models.Repository;
using SensoryTask.Services;

namespace SensoryTask
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
            services.AddDbContext<SensoryTaskContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:SensoryTaskDB"]));

            services.AddScoped<IPersonRepository, PersonManager>();
            services.AddScoped<IProfessionRepository, ProfessionManager>();

            services.AddScoped<IPersonService, PersonService>();

            services.AddMvc(option => option.EnableEndpointRouting = false);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCors("CorsPolicy");
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
            });
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseMvc();

            // Handles exceptions and generates a custom response body
            app.UseExceptionHandler("/errors/500");

            // Handles non-success status codes with empty body
            app.UseStatusCodePagesWithReExecute("/errors/{0}");
        }
    }
}
