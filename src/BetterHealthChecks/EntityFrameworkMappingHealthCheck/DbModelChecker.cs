using Microsoft.EntityFrameworkCore;

namespace BetterHealthChecks.EntityFrameworkMappingHealthCheck;

internal class DbModelChecker
{
    private readonly DbContext _dbContext;

    public DbModelChecker(DbContext context)
    {
        _dbContext = context;
    }

    public async Task CheckDbModel(Type dbModelType)
    {
        var dbSetOperation = typeof(DbContext).GetMethod("Set", new Type[] { });

        var genericSetOperation = dbSetOperation.MakeGenericMethod(dbModelType);

        await ((IQueryable<object>)genericSetOperation.Invoke(_dbContext, null))
        .OrderBy(e => e)
        .FirstOrDefaultAsync();
    }
}