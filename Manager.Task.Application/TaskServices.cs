using Manager.Task.Application.Interfaces;
using Manager.Task.Domain.Task;
using Manager.Task.Infra.Context;
using Microsoft.EntityFrameworkCore;


namespace Manager.Task.Application
{
    public class TaskServices : ITask
    {
        private readonly DbContextApi _context;

        public TaskServices(DbContextApi context)
        {

            _context = context;
            
        }

        public async Task<ManagerTask> CreateTaskAsync(ManagerTask managerTask)
        {
            var createTask = await _context.ManagerTasks.AddAsync(managerTask);
            await _context.SaveChangesAsync();
            return managerTask;
        }

        public Task<bool> DeleteTaskAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ManagerTask>> GetTaskAllAsync()
        {
            var TaslAll = await _context.ManagerTasks.ToListAsync();
            return TaslAll;
        }

        public Task<ManagerTask> GetTaskByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ManagerTask> UpdateTaskAsync(ManagerTask managerTask)
        {
            throw new NotImplementedException();
        }
    }
}
