using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Domain.Data.Models;
using TodoList.Domain.Data.Repositories.Interfaces;

namespace TodoList.Infrastructure.Data.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        public Task<TaskModel> Add(Task task)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TaskModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<TaskModel> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Guid id, Task task)
        {
            throw new NotImplementedException();
        }
    }
}
