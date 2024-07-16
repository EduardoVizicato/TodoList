using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Domain.Data.Models;
using TodoList.Domain.Data.Models.Request;
using TodoList.Domain.Data.Repositories.Interfaces;
using TodoList.Domain.Data.Repositories.Interfaces.Services;

namespace TodoList.Infrastructure.Data.Services
{
    public class TaskService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITaskRepository _taskRepository;
        private readonly ITaskDomainService _taskDomainService;

        public TaskService(IUserRepository userRepository, ITaskRepository taskRepository, ITaskDomainService taskDomainService)
        {
            _taskRepository = taskRepository;
            _userRepository = userRepository;
            _taskDomainService = taskDomainService;
        }

        public async Task AssignTaskToUserAsync(Guid taskid, Guid userid)
        {
            var task = await _taskRepository.GetById(taskid);
            if (task == null)
            {
                throw new Exception("tarefa não encontrada");
            }

            var user = await _userRepository.GetById(userid);
            if (user == null)
            {
                throw new Exception("Usuario não encontrado");
            }

            _taskDomainService.AssignTaskToUser(task, user);

            var taskRequest = new TaskModelRequest
            {
                Name = task.Name,
                IsCompleted = task.IsCompleted,
                User = new User
                {
                    Id = user.Id,
                    Name = user.Name,
                    Password = user.Password,
                    IsActive = user.IsActive,
                }
            };

            await _taskRepository.Update(taskid, taskRequest);
        }
    }
}
