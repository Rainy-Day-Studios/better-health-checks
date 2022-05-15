namespace BetterHealthChecks.EntityFrameworkMappingHealthCheck;

public class EntityFrameworkMappingHealthCheckOptions
{
    public string HealthCheckName { get; set; }
    public IEnumerable<string> Tags { get; set; }
}