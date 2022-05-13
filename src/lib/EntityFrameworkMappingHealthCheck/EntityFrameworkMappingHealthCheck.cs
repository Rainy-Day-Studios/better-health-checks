using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace lib.EntityFrameworkMappingHealthCheck;

internal class EntityFrameworkMappingHealthCheck<T> : IHealthCheck where T : DbContext
{
  public EntityFrameworkMappingHealthCheck() 
  {
    
  }

public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
{
  throw new NotImplementedException();
}
}