using Shared.Domain;

namespace ToDo.Domain.Interfaces;

public interface IToDoUnitOfWork
{
    Task<int> CommitAsync();
}