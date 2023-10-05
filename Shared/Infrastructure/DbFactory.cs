using Microsoft.EntityFrameworkCore;
using Shared.Domain;

namespace Shared.Infrastructure;

#nullable disable
public class DbFactory<TContext> : IDisposable, IDbFactory<TContext> where TContext : DbContext
{
    private bool _isDisposed;
    private readonly Func<TContext> _func;
    private TContext _context;
    public TContext Context => _context ?? _func.Invoke();
    public DbFactory(Func<TContext> dbContextFactory)
    {
        _func = dbContextFactory;
    }
    public void Dispose()
    {
        if (!_isDisposed && _context is not null)
        {
            _isDisposed = true;
            _context.Dispose();
        }
    }
}