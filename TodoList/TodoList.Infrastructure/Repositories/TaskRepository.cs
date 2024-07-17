using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Domain.Models;
using TodoList.Domain.Models.Requests;
using TodoList.Domain.Repositories.Interfaces;
using TodoList.Infrastructure.Data;

namespace TodoList.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDataContext _context;
        public TaskRepository(ApplicationDataContext context)
        {
            _context = context;
        }
        public async Task<TaskModelRequest> AddAsync(TaskModelRequest request)
        {
            var task = new TaskModel()
            {
                Name = request.Name,
                IsCompleted = request.IsCompleted,
                UserId = request.UserId,
                User = request.User,
            };
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
            return request;
        }

        public async Task<bool?> CompletedAsync(Guid id)
        {
            var taskCompleted = await GetByIdAsync(id);
            taskCompleted.IsCompleted = true;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool?> DeleteAsync(Guid id)
        {
            var taskToDelete = await GetByIdAsync(id);
            if (taskToDelete == null)
            {
                return null;
            }
            _context.Tasks.Remove(taskToDelete);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<TaskModel>> GetAllAsync()
        {
            return await _context.Tasks.ToListAsync();
            
        }

        public async Task<TaskModel> GetByIdAsync(Guid id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        public async Task<bool?> UpdateAsync(Guid id, TaskModelRequest request)
        {
            var taskToUpdate = await GetByIdAsync(id);
            if (taskToUpdate == null)
            {
                return null;
            }
            taskToUpdate.Name = request.Name;
            taskToUpdate.IsCompleted = request.IsCompleted;
            taskToUpdate.UserId = request.UserId;
            taskToUpdate.User = request.User;

            _context.Tasks.Update(taskToUpdate);
            return await _context.SaveChangesAsync() >0;
        }
    }
}
