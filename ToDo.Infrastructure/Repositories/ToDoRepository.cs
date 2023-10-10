using Microsoft.EntityFrameworkCore;
using Shared.Infrastructure;
using Shared.Infrastructure.Data;
using ToDo.Domain.Interfaces;
using ToDo.Infrastructure.Data;

namespace ToDo.Infrastructure.Repositories;

public class ToDoRepository : GenericRepository<Domain.Models.ToDo, AppDbContext>, IToDoRepository
{
    public ToDoRepository(ToDoDbFactory dbFactory) : base(dbFactory)
    {
        
    }
}