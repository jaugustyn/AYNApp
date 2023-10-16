using Shared.Infrastructure.Data;
using ToDo.Domain.Interfaces;
using ToDo.Infrastructure.Data;

namespace ToDo.Infrastructure.Repositories;

public class ToDoListRepository : GenericRepository<Domain.Models.ToDoList, AppDbContext>, IToDoListRepository
{
    public ToDoListRepository(ToDoDbFactory dbFactory) : base(dbFactory)
    {
        
    }
}