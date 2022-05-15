using Microsoft.EntityFrameworkCore;

namespace BetterHealthChecks.EntityFrameworkMappingHealthCheck;

internal class DbContextFactory
{
    private readonly  IServiceProvider _serviceProvider;

    public DbContextFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public DbContext GetDbContext<TDbContext>() where TDbContext : DbContext
    {
        var dbContext = _serviceProvider.GetService(typeof(TDbContext));

        return (DbContext)dbContext ?? throw new InvalidOperationException($"Could not find a registered DbContext of type {typeof(TDbContext).Name} for health check.");
    }
}