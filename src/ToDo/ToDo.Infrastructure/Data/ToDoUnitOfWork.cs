using Shared.Infrastructure;
using Shared.Infrastructure.Data;
using ToDo.Domain.Interfaces;

namespace ToDo.Infrastructure.Data;

public class ToDoUnitOfWork: UnitOfWork<AppDbContext>, IToDoUnitOfWork
{
    public ToDoUnitOfWork(ToDoDbFactory dbFactory): base(dbFactory)
    {
    }
}