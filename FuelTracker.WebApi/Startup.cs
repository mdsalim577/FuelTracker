using FuelTracker.Application;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using FuelTracker.Infrastructure;
using Microsoft.Extensions.Logging;
using Serilog;

namespace FuelTracker.WebApi;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(configuration);
            
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

        // Configure PostgresSQL with Entity Framework Core
        services.AddDbContext<FuelDbContext>(options =>
            options.UseNpgsql("Host=localhost; Port=5433; Database=fueltracker; Username=postgres; Password=811911;"));

        // Configure Dependency Injection
        services.AddTransient<FuelRepository>();
        services.AddTransient<IFuelService, FuelService>();

        // Other services and configurations...

        services.AddControllers();
    }

    public void Configure(
        IApplicationBuilder app
        , IWebHostEnvironment env
        , ILoggerFactory loggerFactory
        , FuelDbContext dbContext
        )
    {
        const string seqServerUrl = "http://localhost:5341";

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Seq(seqServerUrl)
            .CreateLogger();

        loggerFactory.AddSerilog();
        
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
        
        dbContext.Database.EnsureCreated();

    }
}