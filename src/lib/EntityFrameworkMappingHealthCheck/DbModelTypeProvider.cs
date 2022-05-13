namespace lib.EntityFrameworkMappingHealthCheck;

public class DbModelTypeProvider
{
  public IEnumerable<Type> GetDbModelTypes(object context)
  {
    ArgumentNullException.ThrowIfNull(context);

    return context
     .GetType()
     .GetProperties()
     .Where(e => e.PropertyType.IsGenericType && e.PropertyType.Name.StartsWith("DbSet"))
     .Select(e => e.PropertyType.GetGenericArguments().FirstOrDefault())
     .Where(e => e != null);
  }
}