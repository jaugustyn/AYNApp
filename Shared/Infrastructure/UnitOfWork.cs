using Microsoft.EntityFrameworkCore;
using Shared.Domain;

namespace Shared.Infrastructure;

public class UnitOfWork<TContext> : IUnitOfWork<TContext>  where TContext : DbContext
{
    private readonly IDbFactory<TContext> _dbFactory;

    public TContext Context { get; }

    public UnitOfWork(IDbFactory<TContext> dbFactory)
    {
        _dbFactory = dbFactory;
    }

    public Task<int> CommitAsync() => _dbFactory.Context.SaveChangesAsync();
}