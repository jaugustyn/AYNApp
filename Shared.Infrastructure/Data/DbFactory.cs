using Microsoft.EntityFrameworkCore;
using Shared.Domain.Interfaces;

namespace Shared.Infrastructure.Data;

#nullable disable
// Instead of directly injecting dbcontext into repositories i will use dbfactory to inject it through DI in case of having multiple databases
public class DbFactory<TContext> : IDisposable, IDbFactory<TContext> where TContext : DbContext
{
    private bool _isDisposed;
    private readonly Func<TContext> _func;
    private TContext _context;
    public TContext Context => _context ??= _func.Invoke();
    public DbFactory(Func<TContext> dbContextFactory)
    {
        _func = dbContextFactory;
    }
    public void Dispose()
    {
        if (!_isDisposed && _context is not null)
        {
            _context.Dispose();
            _isDisposed = true;
        }
    }
}