using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Domain.Data.Models;
using TodoList.Domain.Data.Models.Request;

namespace TodoList.Domain.Data.Repositories.Interfaces.Services
{
    public interface ITaskDomainService
    {
        void AssignTaskToUser(TaskModel task, User user);
    }
}
