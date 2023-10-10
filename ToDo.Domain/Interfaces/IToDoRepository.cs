using Shared.Domain;
using Shared.Domain.Interfaces;

namespace ToDo.Domain.Interfaces;

public interface IToDoRepository : IGenericRepository<Models.ToDo>
{
}