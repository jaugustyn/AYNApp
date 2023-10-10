using Microsoft.EntityFrameworkCore;

namespace Shared.Domain.Interfaces;

public interface IUnitOfWork<TContext> where TContext: DbContext
{
    int Commit();
    Task<int> CommitAsync();
    TContext Context { get; }
}