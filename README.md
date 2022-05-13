# Better Health Checks

This is a  project to provide _thorough_ health checks for a variety of services in the .NET ecosystem.

For general information on health checks in .NET, [check out the docs.](https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/health-checks)

## Health Checks

### Entity Framework Model Mappings
Usage: `services.AddEntityFrameworkMappingHealthCheck<MyDbContextType>();`