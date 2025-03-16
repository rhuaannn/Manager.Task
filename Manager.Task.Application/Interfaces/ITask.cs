using Manager.Task.Domain.DTO;
using Manager.Task.Domain.Task;

namespace Manager.Task.Application.Interfaces
{
    public interface ITask
    {
        Task<ManagerTask> CreateTaskAsync(ManagerTask managerTask);

        Task<ManagerTask> UpdateTaskAsync(ManagerTask managerTask);

        Task<bool> DeleteTaskAsync(Guid id);

        Task<ManagerTask> GetTaskByIdAsync(Guid id);

        Task<IEnumerable<ManagerTask>> GetTaskAllAsync();
    }
}
