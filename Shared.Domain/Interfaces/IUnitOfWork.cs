using Microsoft.EntityFrameworkCore;

namespace Shared.Domain;

public interface IUnitOfWork<TContext> where TContext: DbContext
{
    int Commit();
    Task<int> CommitAsync();
    TContext Context { get; }
}