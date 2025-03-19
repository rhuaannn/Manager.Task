﻿using Manager.Task.Application.Interfaces;
using Manager.Task.Domain.Task;
using Manager.Task.Infra.Context;
using Microsoft.EntityFrameworkCore;
using ZstdSharp;


namespace Manager.Task.Application.Services
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
            if(managerTask.Date != DateTime.Now)
            {
                throw new Exception("Task not created");
            }
            await _context.SaveChangesAsync();
            return managerTask;
        }

        public async Task<bool> DeleteTaskAsync(Guid id)
        {
            var deleteTask = await _context.ManagerTasks.FindAsync(id);
            _context.Remove(deleteTask);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ManagerTask>> GetTaskAllAsync()
        {
            var TaskAll = await _context.ManagerTasks.ToListAsync();

            if (TaskAll.Count == 0)
            {
                throw new Exception("No task found");
            }
            return TaskAll;
        }

        public async Task<ManagerTask> GetTaskByIdAsync(Guid id)
        {
           var taskById =  await _context.ManagerTasks.FindAsync(id);
           if (taskById != null)
           {
               return taskById;
           }
           throw new Exception("Task not found");
        }

        public Task<ManagerTask> UpdateTaskAsync(ManagerTask managerTask)
        {
            throw new NotImplementedException();
        }
    }
}
