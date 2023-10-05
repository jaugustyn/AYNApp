using Microsoft.EntityFrameworkCore;
using Shared.Domain;

namespace Shared.Infrastructure;

public class DbFactory<TContext> : IDbFactory<TContext> where TContext : DbContext
{
    public TContext Context { get; }
}