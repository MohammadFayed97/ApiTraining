namespace ApiTraining.Extensions;

using Abstractions;
using Entities;
using LoggerService;
using Microsoft.EntityFrameworkCore;

public static class ServiceExtensions
{

    public static void ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyMethod());
        });
    }

    public static void ConfigureLoggerService(this IServiceCollection services) => services.AddScoped<ILoggerManager, LoggerManager>();
    public static void ConfigureDbContext(this IServiceCollection services, ConfigurationManager configuration) 
        => services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefualtConnection"), opt 
            => opt.MigrationsAssembly("ApiTraining")));
}