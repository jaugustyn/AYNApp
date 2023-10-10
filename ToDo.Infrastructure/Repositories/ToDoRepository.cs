using Microsoft.EntityFrameworkCore;
using Shared.Entities;
using Shared.Infrastructure;
using ToDo.Domain.Interfaces;
using ToDo.Infrastructure.Data;

namespace ToDo.Infrastructure.Repositories;

public class ToDoRepository : GenericRepository<Domain.Models.ToDo, AppDbContext>, IToDoRepository
{
    public ToDoRepository(ToDoDbFactory dbFactory) : base(dbFactory)
    {
        
    }
}