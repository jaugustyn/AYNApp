using Microsoft.EntityFrameworkCore;
using Shared.Domain;

namespace Shared.Infrastructure;

// Instead of directly injecting dbcontext into repositories i will use dbfactory to inject it through DI in case of having multiple databases
public class UnitOfWork<TContext> : IUnitOfWork<TContext>  where TContext : DbContext
{
    private readonly IDbFactory<TContext> _dbFactory;

    public TContext Context { get; }

    public UnitOfWork(IDbFactory<TContext> dbFactory)
    {
        _dbFactory = dbFactory;
    }

    public Task<int> CommitAsync() => _dbFactory.Context.SaveChangesAsync();
    public int Commit() => _dbFactory.Context.SaveChanges();
}