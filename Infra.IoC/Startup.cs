using Crosscutting.Interfaces.Log;
using Domain._Base.Interfaces;
using Domain._Base.Services;
using Infra.Data;
using Infra.Log._Base;
using Infra.Log.Interfaces;
using Infra.Log.Loggers;
using Infra.Log.Wrappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.IoC;

public static class Startup
{
    public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddMyDietDbContext(configuration);

        // Services

        
        // Repositories

        
        // Validators

        
        // Logging
        services
            .AddScoped<ILoggerDomainServices, LoggerDomainServices>()
            .AddScoped<ISingletonLoggerWrapper, SingletonLoggerWrapper>()
            .AddScoped<IStandardLogger, StandardLogger>()
            .AddScoped<ILoggerDomainServices, LoggerDomainServices>()
            .AddScoped<ILogWriter, LogWriter>();
        
        // Configs
        services
            .AddScoped<IDomainErrorHandler, DomainErrorHandler>();


    }

    private static void AddMyDietDbContext(this IServiceCollection services, IConfiguration configuration)
        => services.AddDbContext<MyDietContext>(options =>
            options.UseMySql(
                configuration.GetConnectionString("MyDietDatabase"),
                new MySqlServerVersion(new Version(8, 0, 23)),
                providerOptions => providerOptions
                    .MigrationsHistoryTable("_mydietmigrations")));
}