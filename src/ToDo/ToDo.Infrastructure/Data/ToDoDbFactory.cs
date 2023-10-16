using Shared.Infrastructure;
using Shared.Infrastructure.Data;

namespace ToDo.Infrastructure.Data;

public class ToDoDbFactory: DbFactory<AppDbContext>
{
    public ToDoDbFactory(Func<AppDbContext> context) : base(context)
    {
    }
}