using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Domain.Data.Models;
using TodoList.Domain.Data.Models.Request;

namespace TodoList.Domain.Data.Repositories.Interfaces.Services
{
    public class TaskDomainService : ITaskDomainService
    {
        public void AssignTaskToUser(TaskModel task, User user)
        {
            if(user == null || user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            task.User = user;
        }
    }
}
