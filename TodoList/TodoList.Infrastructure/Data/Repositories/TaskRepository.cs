using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TodoList.Domain.Data.Models;
using TodoList.Domain.Data.Models.Request;
using TodoList.Domain.Data.Repositories.Interfaces;

namespace TodoList.Infrastructure.Data.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDataContext _context;
        public TaskRepository(ApplicationDataContext context)
        {
            _context = context;
        }

        public async Task<TaskModelRequest> Add(TaskModelRequest taskRequest)
        {

            //var user = new User()
            //{
            //Name = taskRequest.User.Name,
            //Password = taskRequest.User.Password,
            //IsActive = taskRequest.User.IsActive,
            //};
            var task = new TaskModel()
            {
                Name = taskRequest.Name,
                IsCompleted = taskRequest.IsCompleted,
                User = taskRequest.User,
            };
            await _context.AddAsync(task);
            await _context.SaveChangesAsync();

            var addedTaskModelRequest = new TaskModelRequest()
            {
                Name = task.Name,
                IsCompleted = task.IsCompleted,
                User = task.User,
            };

            return addedTaskModelRequest;

            //var addedTaskModelRequest = new TaskModelRequest()
            //{
            //Name = task.Name,
            //IsCompleted = task.IsCompleted,
            //User = new UserRequest
            //{
            //Name = task.User?.Name,
            //Password = task.User?.Password,
            //IsActive = task.User?.IsActive ?? true
            //}
            //};

            //return addedTaskModelRequest;
        }

        public async Task<bool?> Delete(Guid id)
        {
            var TaskToDelete = await GetById(id);
            if (TaskToDelete == null)
            {
                return false;
            }
            _context.Tasks.Remove(TaskToDelete);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool?> Desactive(Guid id, TaskModelRequest taskRequest)
        {
            var taskToUpdate = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == id);
            taskToUpdate.IsCompleted = false;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<TaskModel>> GetAll()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<TaskModel> GetById(Guid id)
        {
            return await _context.Tasks.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool?> Update(Guid id, TaskModelRequest taskRequest)
        {
            var taskToUpdate = await _context.Tasks.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == id);

            if (taskToUpdate == null)
            {
                return null;
            }

            taskToUpdate.Name = taskRequest.Name;
            taskToUpdate.IsCompleted = taskRequest.IsCompleted;
            if(taskRequest.User != null)
            {
                taskToUpdate.User.Name = taskRequest.User.Name;
                taskToUpdate.User.Password = taskRequest.User.Password;
                taskToUpdate.User.IsActive = taskRequest.User.IsActive;
            }

            _context.Tasks.Update(taskToUpdate);

            return await _context.SaveChangesAsync() > 0;

        }
    }
}
