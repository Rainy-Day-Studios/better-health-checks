# Better Health Checks

This is a  project to provide thorough health checks for a variety of services in the .NET ecosystem.

For general information on health checks in .NET, [check out the docs.](https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/health-checks)


### Entity Framework Model Mapping Check

```dotnet
builder.Services
    .AddHealthChecks()
    .AddEntityFrameworkMappingCheck<SampleDbContext>(options =>
    {
        options.HealthCheckName = "SampleDbContext Health Check.";
        options.Tags = new[] { "database", "entity framework" };
    });
```

This health check validates that each database model in the entity framework DbContext maps properly to a table in the underlying database. It does this by iterating through all DbSet properties in the provided db context type and executing a `SELECT TOP 1` against the underlying database table to ensure all tables exist and have columns that map into the associated models.

#### Considerations

If you are using DbSet properties on the context to map to stored procedure results, you will want to add the `[HealthCheckIgnore]` attribute to those properties to exclude them from the health check. 


# Contributing

Looking to contribute? We'd be glad to have you. Here is the contribution flow we follow:
 1. Branch from main
 2. Implement your changes
    a. Include unit tests for changes
    b. If you add a health check, add usage to the sample project
    c. Update the documentation (this README) based on your changes
 3. Pull request your branch into main
 4. Wait for review/feedback
 5. Merge

All health checks include unit tests and are utilized in the sample project for testing/documentation purposes.

## Dependencies
 * .NET 6

## Running Tests

 1. Open the `/src/tests` folder
 2. Run `dotnet test`

## Running The Sample

The sample relies on having a local database to connect to and run health checks against. This database can be deployed using the `sample-database.sql` script. If you're not using (localdb)\mssqllocaldb, you can configure your own connection string in `appsettings.json`.

### Using VS Code
 1. Open the `/src/` folder
 2. Hit `F5` to begin debugging
 3. Navigate to https://localhost:7291/health to run the health checks

### Using the command line
 1. Open the `/src/sample/` folder
 2. `dotnet run`
 3. Navigate to https://localhost:7291/health to run the health checks