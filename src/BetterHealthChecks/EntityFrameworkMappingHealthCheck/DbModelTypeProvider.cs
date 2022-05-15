using Microsoft.EntityFrameworkCore;

namespace BetterHealthChecks.EntityFrameworkMappingHealthCheck;

public class DbModelTypeProvider
{
  public IEnumerable<Type> GetDbModelTypes<TDbContext>() where TDbContext : DbContext
  {
    return typeof(TDbContext)
     .GetProperties()
     .Where(e => e.PropertyType.IsGenericType && e.PropertyType.Name.StartsWith("DbSet"))
     .Where(e => !e.CustomAttributes.Any(attr => attr.AttributeType == typeof(HealthCheckIgnoreAttribute)))
     .Select(e => e.PropertyType.GetGenericArguments().FirstOrDefault())
     .Where(e => e != null);
  }
}