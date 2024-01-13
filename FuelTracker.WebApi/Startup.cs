using FuelTracker.Application;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using FuelTracker.Infrastructure;

namespace FuelTracker.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Configure CORS
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAnyOrigin", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

            // Configure PostgreSQL with Entity Framework Core
            services.AddDbContext<FuelDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("PostgreSQL")));

            // Configure Dependency Injection
            services.AddTransient<FuelRepository>();
            services.AddTransient<IFuelService, FuelService>();

            // Other services and configurations...

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            // Enable CORS
            app.UseCors("AllowAnyOrigin");

            // Configure routing
            app.UseRouting();

            // Enable static files, if needed
            // app.UseStaticFiles();

            // Configure authorization and authentication, if needed
            // app.UseAuthorization();

            // Configure endpoints
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}