using Shared.Domain;
using Shared.Entities;

namespace ToDo.Domain.Interfaces;

public interface IToDoRepository : IGenericRepository<Models.ToDo>
{
}