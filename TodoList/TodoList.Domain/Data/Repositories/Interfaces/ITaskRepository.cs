using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Domain.Data.Models;
using TodoList.Domain.Data.Models.Request;

namespace TodoList.Domain.Data.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<TaskModel>> GetAll();
        Task<TaskModel> GetById(Guid id);
        Task<TaskModelRequest> Add(TaskModelRequest taskRequest);
        Task<bool?> Delete(Guid id);
        Task<bool?> Update(Guid id, TaskModelRequest taskRequest);
        Task<bool?> Desactive(Guid id, TaskModelRequest taskRequest);
    }
}
