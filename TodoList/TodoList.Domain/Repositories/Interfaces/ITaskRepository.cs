using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Domain.Models;
using TodoList.Domain.Models.Requests;

namespace TodoList.Domain.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<TaskModel>> GetAllAsync();
        Task<TaskModel> GetByIdAsync(Guid id);
        Task<TaskModelRequest> AddAsync(TaskModelRequest request);
        Task<bool?> UpdateAsync(Guid id, TaskModelRequest request);
        Task<bool?> DeleteAsync(Guid id);
        Task<bool?> CompletedAsync(Guid id);
    }
}
