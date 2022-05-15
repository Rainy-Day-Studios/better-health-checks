using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;

namespace BetterHealthChecks.EntityFrameworkMappingHealthCheck;

internal class EntityFrameworkMappingHealthCheck<TDbContext> : IHealthCheck where TDbContext : DbContext
{
    private readonly DbModelTypeProvider _modelTypeProvider;
    private readonly DbContextFactory _dbContextFactory;
    private readonly DbModelChecker _modelChecker;

    private readonly ILogger _logger;

    public EntityFrameworkMappingHealthCheck(
        IServiceProvider serviceProvider,
        ILoggerFactory _loggerFactory)
    {
        _modelTypeProvider = new DbModelTypeProvider();
        _dbContextFactory = new DbContextFactory(serviceProvider);
        _modelChecker = new DbModelChecker(_dbContextFactory.GetDbContext<TDbContext>());

        _logger = _loggerFactory.CreateLogger<EntityFrameworkMappingHealthCheck<TDbContext>>();
    }

    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        var dbModelTypesToCheck = _modelTypeProvider.GetDbModelTypes<TDbContext>();

        foreach (var modelType in dbModelTypesToCheck)
        {
            await _modelChecker.CheckDbModel(modelType);
        }

        return HealthCheckResult.Healthy($"Successfully checked entity framework mappings for {dbModelTypesToCheck.Count()} models.");
    }
}