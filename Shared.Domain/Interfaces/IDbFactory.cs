using Microsoft.EntityFrameworkCore;

namespace Shared.Domain.Interfaces;

public interface IDbFactory<TContext> where TContext : DbContext
{
    TContext Context { get; }
}