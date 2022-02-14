namespace ApiTraining.Extensions;

using Abstractions;
using Entities;
using LoggerService;
using Microsoft.EntityFrameworkCore;
using Repositories;

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
    public static void ConfigureDbContext(this IServiceCollection services, ConfigurationManager configuration) => services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefualtConnection"), opt => opt.MigrationsAssembly("ApiTraining"));
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            options.EnableSensitiveDataLogging();
        });

    public static void RegisterRepositoryManger(this IServiceCollection services) => services.AddScoped<IRepositoryManager, RepositoryManager>();
    public static IMvcBuilder AddCustomCsvFormatter(this IMvcBuilder builder) => builder.AddMvcOptions(config => config.OutputFormatters.Add(new CsvOutputFormatter()));
}