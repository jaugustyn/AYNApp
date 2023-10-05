using Microsoft.EntityFrameworkCore;

namespace Shared.Domain;

public interface IUnitOfWork<TContext> where TContext: DbContext
{
    Task<int> CommitAsync();
    TContext Context { get; }
}