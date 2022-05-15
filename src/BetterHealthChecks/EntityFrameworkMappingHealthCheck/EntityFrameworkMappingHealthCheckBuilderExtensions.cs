using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;

namespace BetterHealthChecks.EntityFrameworkMappingHealthCheck;

public static class EntityFrameworkMappingHealtCheckhBuilderExtensions
{
    private const string DEFAULT_NAME = "Entity Framework Mappings";

    /// <summary>
    /// Registers an EntityFrameworkMappingHealthCheck for the provided TDbContext type. This health check 
    /// will validate mappings between entity framework models and their underlying tables.
    /// </summary>
    public static IHealthChecksBuilder AddEntityFrameworkMappingCheck<TDbContext>(
        this IHealthChecksBuilder builder) where TDbContext : DbContext
    {
        return AddEntityFrameworkMappingCheck<TDbContext>(builder, (opts) => { });
    }

    /// <summary>
    /// Registers an entity framework mapping health check for the provided TDbContext type. This health check 
    /// will validate the mappings between entity framework models and their underlying tables.
    /// </summary>
    /// <param name="optionsBuilder">Optional configuration action for the health check.</param>
    public static IHealthChecksBuilder AddEntityFrameworkMappingCheck<TDbContext>(
        this IHealthChecksBuilder builder,
        Action<EntityFrameworkMappingHealthCheckOptions> optionsBuilder) where TDbContext : DbContext
    {
        var healthCheckOptions = new EntityFrameworkMappingHealthCheckOptions();
        optionsBuilder.Invoke(healthCheckOptions);

        return builder.Add(
          new HealthCheckRegistration(
            healthCheckOptions.HealthCheckName ?? DEFAULT_NAME,
            serviceProvider => new EntityFrameworkMappingHealthCheck<TDbContext>(
              serviceProvider,
              serviceProvider.GetRequiredService<ILoggerFactory>()),
            HealthStatus.Unhealthy,
            healthCheckOptions.Tags
          )
        );
    }
}