using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Domain.Data.Models;

namespace TodoList.Domain.Data.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<TaskModel>> GetAll();
        Task<TaskModel> GetById(Guid id);
        Task<TaskModel> Add(Task task);
        Task<bool> Delete(Guid id);
        Task<bool> Update (Guid id, Task task);
    }
}
