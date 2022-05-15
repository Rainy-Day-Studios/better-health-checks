namespace BetterHealthChecks.EntityFrameworkMappingHealthCheck;

public class EntityFrameworkMappingHealthCheckOptions
{
    /// <summary>
    /// Configures the health check name. If not provided, a default will be used.
    /// </summary>
    public string HealthCheckName { get; set; }

    public IEnumerable<string> Tags { get; set; }
}